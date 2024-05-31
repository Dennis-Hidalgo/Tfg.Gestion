using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tfg.Gestion.Employess
{
    public class EmployeeAppService :
    CrudAppService<
    Employee, //The Book entity
    EmployeeDto, //Used to show books
    Guid, //Primary key of the book entity
    PagedAndSortedResultRequestDto, //Used for paging/sorting
    CreateUpdateEmployeeDto>, //Used to create/update a book
IEmployeeAppService //implement the IBookAppService
    {
        public EmployeeAppService(IRepository<Employee, Guid> repository)
        : base(repository)
        {

        }
    }
}
