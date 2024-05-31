using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Tfg.Gestion.SalesHistories
{
    public interface ISalesHistoryAppService :
    ICrudAppService< //Defines CRUD methods
        SalesHistoryDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateSalesHistoryDto>
    {
    }
}
