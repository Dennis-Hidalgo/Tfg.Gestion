using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tfg.Gestion.Orders
{
    public class OrderAppService :
    CrudAppService<
    Order, //The Book entity
    OrderDto, //Used to show books
    Guid, //Primary key of the book entity
    PagedAndSortedResultRequestDto, //Used for paging/sorting
    CreateUpdateOrderDto>, //Used to create/update a book
IOrderAppService //implement the IBookAppService
    {
        public OrderAppService(IRepository<Order, Guid> repository)
        : base(repository)
        {

        }
    }
}
