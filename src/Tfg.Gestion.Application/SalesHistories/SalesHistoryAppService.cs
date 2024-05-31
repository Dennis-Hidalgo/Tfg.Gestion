using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tfg.Gestion.SalesHistories
{
    public class SalesHistoryAppService :
    CrudAppService<
    SalesHistory, //The Book entity
    SalesHistoryDto, //Used to show books
    Guid, //Primary key of the book entity
    PagedAndSortedResultRequestDto, //Used for paging/sorting
    CreateUpdateSalesHistoryDto>, //Used to create/update a book
ISalesHistoryAppService //implement the IBookAppService
    {
        public SalesHistoryAppService(IRepository<SalesHistory, Guid> repository)
        : base(repository)
        {

        }
    }
}
