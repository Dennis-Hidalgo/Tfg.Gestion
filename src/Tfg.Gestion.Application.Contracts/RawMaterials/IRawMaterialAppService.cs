using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Tfg.Gestion.RawMaterials
{
    public interface IRawMaterialAppService :
    ICrudAppService< //Defines CRUD methods
        RawMaterialDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateRawMaterialDto>
    {
        Task<ListResultDto<ProductProviderLookupDto>> GetProductProviderLookupAsync();
    }
}
