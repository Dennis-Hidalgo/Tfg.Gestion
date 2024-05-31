using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Tfg.Gestion.Inventories
{
    public interface IInventoryAppService :
    ICrudAppService< //Defines CRUD methods
        InventoryDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateInventoryDto>
    {
        Task<ListResultDto<RawMaterialLookupDto>> GetRawMaterialLookupAsync();
    }
}
