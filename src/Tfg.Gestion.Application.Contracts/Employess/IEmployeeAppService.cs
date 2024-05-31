using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;


namespace Tfg.Gestion.Employess
{
    public interface IEmployeeAppService :
    ICrudAppService< //Defines CRUD methods
        EmployeeDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateEmployeeDto>
    {
    }
}
