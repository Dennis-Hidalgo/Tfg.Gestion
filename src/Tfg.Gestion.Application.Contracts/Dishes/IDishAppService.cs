using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Tfg.Gestion.Dishes
{
    public interface IDishAppService :
    ICrudAppService< //Defines CRUD methods
        DishDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateDishDto>
    {
    }
}