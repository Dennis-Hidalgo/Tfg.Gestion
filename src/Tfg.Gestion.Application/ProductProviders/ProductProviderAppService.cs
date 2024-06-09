using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tfg.Gestion.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tfg.Gestion.ProductProviders
{
    public class ProductProviderAppService :
    CrudAppService<
    ProductProvider, //The Book entity
    ProductProviderDto, //Used to show books
    Guid, //Primary key of the book entity
    PagedAndSortedResultRequestDto, //Used for paging/sorting
    CreateUpdateProductProviderDto>, //Used to create/update a book
IProductProviderAppService //implement the IBookAppService
    {
        public ProductProviderAppService(IRepository<ProductProvider, Guid> repository)
        : base(repository)
        {
            GetPolicyName = GestionPermissions.ProductProviders.Default;
            GetListPolicyName = GestionPermissions.ProductProviders.Default;
            CreatePolicyName = GestionPermissions.ProductProviders.Create;
            UpdatePolicyName = GestionPermissions.ProductProviders.Edit;
            DeletePolicyName = GestionPermissions.ProductProviders.Delete;
        }
    }
}
