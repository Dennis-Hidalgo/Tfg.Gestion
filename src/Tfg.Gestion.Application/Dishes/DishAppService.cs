using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tfg.Gestion.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tfg.Gestion.Dishes
{
    public class DishAppService :
    CrudAppService<
    Dish, //The Book entity
    DishDto, //Used to show books
    Guid, //Primary key of the book entity
    PagedAndSortedResultRequestDto, //Used for paging/sorting
    CreateUpdateDishDto>, //Used to create/update a book
IDishAppService //implement the IBookAppService
    {
        public DishAppService(IRepository<Dish, Guid> repository)
        : base(repository)
        {
            GetPolicyName = GestionPermissions.Dishes.Default;
            GetListPolicyName = GestionPermissions.Dishes.Default;
            CreatePolicyName = GestionPermissions.Dishes.Create;
            UpdatePolicyName = GestionPermissions.Dishes.Edit;
            DeletePolicyName = GestionPermissions.Dishes.Delete;
        }
    }
}
