using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tfg.Gestion.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tfg.Gestion.OrderDetails
{
    public class OrderDetailAppService :
    CrudAppService<
    OrderDetail, //The Book entity
    OrderDetailDto, //Used to show books
    Guid, //Primary key of the book entity
    PagedAndSortedResultRequestDto, //Used for paging/sorting
    CreateUpdateOrderDetailDto>, //Used to create/update a book
IOrderDetailAppService //implement the IBookAppService
    {
        public OrderDetailAppService(IRepository<OrderDetail, Guid> repository)
        : base(repository)
        {
            GetPolicyName = GestionPermissions.OrderDetails.Default;
            GetListPolicyName = GestionPermissions.OrderDetails.Default;
            CreatePolicyName = GestionPermissions.OrderDetails.Create;
            UpdatePolicyName = GestionPermissions.OrderDetails.Edit;
            DeletePolicyName = GestionPermissions.OrderDetails.Delete;
        }
    }
}
