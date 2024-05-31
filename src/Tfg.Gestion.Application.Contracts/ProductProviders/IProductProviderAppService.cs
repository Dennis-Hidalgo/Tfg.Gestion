using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Tfg.Gestion.ProductProviders
{
    public interface IProductProviderAppService :
    ICrudAppService< //Defines CRUD methods
        ProductProviderDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateProductProviderDto>
    {
    }
}
