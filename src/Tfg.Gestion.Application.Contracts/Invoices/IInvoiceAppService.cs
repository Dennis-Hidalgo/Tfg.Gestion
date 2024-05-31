using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Tfg.Gestion.Invoices
{
    public interface IInvoiceAppService :
    ICrudAppService< //Defines CRUD methods
        InvoiceDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateInvoiceDto>
    {
        Task<ListResultDto<OrderLookupDto>> GetOrderLookupAsync();
    }
}
