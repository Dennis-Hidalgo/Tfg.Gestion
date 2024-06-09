using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Tfg.Gestion.Orders
{
    public interface IOrderAppService :
    ICrudAppService< //Defines CRUD methods
        OrderDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateOrderDto>
    {
        Task<ListResultDto<CustomerLookupDto>> GetCustomerLookupAsync();
    }
}
