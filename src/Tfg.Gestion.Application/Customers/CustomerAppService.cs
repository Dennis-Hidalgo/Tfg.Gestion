using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tfg.Gestion.Customers
{
    public class CustomerAppService :
        CrudAppService<
        Customer, //The Book entity
        CustomerDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateCustomerDto>, //Used to create/update a book
    ICustomerAppService //implement the IBookAppService
    {
        public CustomerAppService(IRepository<Customer, Guid> repository)
        : base(repository)
        {

        }
    }
}
