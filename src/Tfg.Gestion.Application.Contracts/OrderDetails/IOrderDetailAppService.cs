using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Tfg.Gestion.OrderDetails
{
    public interface IOrderDetailAppService :
    ICrudAppService< //Defines CRUD methods
        OrderDetailDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateOrderDetailDto>
    {
    }
}
