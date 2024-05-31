using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tfg.Gestion.Orders;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tfg.Gestion.Invoices
{
    public class InvoiceAppService :
    CrudAppService<
    Invoice, //The Book entity
    InvoiceDto, //Used to show books
    Guid, //Primary key of the book entity
    PagedAndSortedResultRequestDto, //Used for paging/sorting
    CreateUpdateInvoiceDto>, //Used to create/update a book
IInvoiceAppService //implement the IBookAppService
    {
        private readonly IRepository<Order, Guid> _orderRepository;
        public InvoiceAppService(IRepository<Invoice, Guid> repository, IRepository<Order, Guid> orderRepository)
        : base(repository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ListResultDto<OrderLookupDto>> GetOrderLookupAsync()
        {
            var orders = await _orderRepository.GetListAsync();

            return new ListResultDto<OrderLookupDto>(
                ObjectMapper.Map<List<Order>, List<OrderLookupDto>>(orders)
            );
        }
    }
}
