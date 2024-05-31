using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Tfg.Gestion.ProductProviders;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Tfg.Gestion.RawMaterials
{
    public class RawMaterialAppService :
    CrudAppService<
    RawMaterial, //The RawMaterial entity
    RawMaterialDto, //Used to show rawMaterials
    Guid, //Primary key of the rawMaterial entity
    PagedAndSortedResultRequestDto, //Used for paging/sorting
    CreateUpdateRawMaterialDto>, //Used to create/update a rawMaterial
IRawMaterialAppService //implement the IRawMaterialAppService
    {
        private readonly IRepository<ProductProvider, Guid> _productProviderRepository;
        public RawMaterialAppService(IRepository<RawMaterial, Guid> repository, IRepository<ProductProvider, Guid> productProviderRepository)
        : base(repository)
        {
            _productProviderRepository = productProviderRepository;
        }

        public override async Task<RawMaterialDto> GetAsync(Guid id)
        {
            //Get the IQueryable<RawMaterial> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join rawMaterials and productProviders
            var query = from rawMaterial in queryable
                        join productProvider in await _productProviderRepository.GetQueryableAsync() on rawMaterial.ProductProviderId equals productProvider.Id
                        where rawMaterial.Id == id
                        select new { rawMaterial, productProvider };

            //Execute the query and get the rawMaterial with productProvider
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(RawMaterial), id);
            }

            var rawMaterialDto = ObjectMapper.Map<RawMaterial, RawMaterialDto>(queryResult.rawMaterial);
            rawMaterialDto.ProductProviderName = queryResult.productProvider.Name;
            return rawMaterialDto;
        }

        public override async Task<PagedResultDto<RawMaterialDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            //Get the IQueryable<RawMaterial> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join rawMaterials and productProviders
            var query = from rawMaterial in queryable
                        join productProvider in await _productProviderRepository.GetQueryableAsync() on rawMaterial.ProductProviderId equals productProvider.Id
                        select new { rawMaterial, productProvider };

            //Paging
            query = query
                .OrderBy(NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            //Execute the query and get a list
            var queryResult = await AsyncExecuter.ToListAsync(query);

            //Convert the query result to a list of RawMaterialDto objects
            var rawMaterialDtos = queryResult.Select(x =>
            {
                var rawMaterialDto = ObjectMapper.Map<RawMaterial, RawMaterialDto>(x.rawMaterial);
                rawMaterialDto.ProductProviderName = x.productProvider.Name;
                return rawMaterialDto;
            }).ToList();

            //Get the total count with another query
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<RawMaterialDto>(
                totalCount,
                rawMaterialDtos
            );
        }

        public async Task<ListResultDto<ProductProviderLookupDto>> GetProductProviderLookupAsync()
        {
            var productProviders = await _productProviderRepository.GetListAsync();

            return new ListResultDto<ProductProviderLookupDto>(
                ObjectMapper.Map<List<ProductProvider>, List<ProductProviderLookupDto>>(productProviders)
            );
        }

        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"rawMaterial.{nameof(RawMaterial.Name)}";
            }

            if (sorting.Contains("productProviderName", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace(
                    "productProviderName",
                    "productProvider.Name",
                    StringComparison.OrdinalIgnoreCase
                );
            }

            return $"rawMaterial.{sorting}";
        }
    }
}
