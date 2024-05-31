using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Tfg.Gestion.RawMaterialDetails
{
    public interface IRawMaterialDetailAppService :
    ICrudAppService< //Defines CRUD methods
        RawMaterialDetailDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateRawMaterialDetailDto>
    {
    }
}
