using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Tfg.Gestion.Permissions;
using Tfg.Gestion.RawMaterials;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Tfg.Gestion.Inventories
{
    public class InventoryAppService :
    CrudAppService<
    Inventory, //The Inventory entity
    InventoryDto, //Used to show inventories
    Guid, //Primary key of the inventory entity
    PagedAndSortedResultRequestDto, //Used for paging/sorting
    CreateUpdateInventoryDto>, //Used to create/update a inventory
IInventoryAppService //implement the IInventoryAppService
    {
        private readonly IRepository<RawMaterial, Guid> _rawMaterialRepository;
        public InventoryAppService(IRepository<Inventory, Guid> repository, IRepository<RawMaterial, Guid> rawMaterialRepository)
        : base(repository)
        {
            _rawMaterialRepository = rawMaterialRepository;
            GetPolicyName = GestionPermissions.Inventories.Default;
            GetListPolicyName = GestionPermissions.Inventories.Default;
            CreatePolicyName = GestionPermissions.Inventories.Create;
            UpdatePolicyName = GestionPermissions.Inventories.Edit;
            DeletePolicyName = GestionPermissions.Inventories.Delete;
        }

        public override async Task<InventoryDto> GetAsync(Guid id)
        {
            //Get the IQueryable<Inventory> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join inventories and rawMaterials
            var query = from inventory in queryable
                        join rawMaterial in await _rawMaterialRepository.GetQueryableAsync() on inventory.RawMaterialId equals rawMaterial.Id
                        where inventory.Id == id
                        select new { inventory, rawMaterial };

            //Execute the query and get the inventory with rawMaterial
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Inventory), id);
            }

            var inventoryDto = ObjectMapper.Map<Inventory, InventoryDto>(queryResult.inventory);
            inventoryDto.RawMaterialName = queryResult.rawMaterial.Name;
            return inventoryDto;
        }

        public override async Task<PagedResultDto<InventoryDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            //Get the IQueryable<Inventory> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join inventories and rawMaterials
            var query = from inventory in queryable
                        join rawMaterial in await _rawMaterialRepository.GetQueryableAsync() on inventory.RawMaterialId equals rawMaterial.Id
                        select new { inventory, rawMaterial };
            //Paging
            query = query
                .OrderBy(NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            //Execute the query and get a list
            var queryResult = await AsyncExecuter.ToListAsync(query);

            //Convert the query result to a list of InventoryDto objects
            var inventoryDtos = queryResult.Select(x =>
            {
                var inventoryDto = ObjectMapper.Map<Inventory, InventoryDto>(x.inventory);
                inventoryDto.RawMaterialName = x.rawMaterial.Name;
                return inventoryDto;
            }).ToList();

            //Get the total count with another query
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<InventoryDto>(
                totalCount,
                inventoryDtos
            );
        }

        public async Task<ListResultDto<RawMaterialLookupDto>> GetRawMaterialLookupAsync()
        {
            var rawMaterials = await _rawMaterialRepository.GetListAsync();

            return new ListResultDto<RawMaterialLookupDto>(
                ObjectMapper.Map<List<RawMaterial>, List<RawMaterialLookupDto>>(rawMaterials)
            );
        }

        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"inventory.{nameof(Inventory.Id)}";
            }

            if (sorting.Contains("rawMaterialName", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace(
                    "rawMaterialName",
                    "rawMaterial.Name",
                    StringComparison.OrdinalIgnoreCase
                );
            }

            return $"inventory.{sorting}";
        }
    }
}
