using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tfg.Gestion.RawMaterialDetails
{
    public class RawMaterialDetailAppService :
    CrudAppService<
    RawMaterialDetail, //The Book entity
    RawMaterialDetailDto, //Used to show books
    Guid, //Primary key of the book entity
    PagedAndSortedResultRequestDto, //Used for paging/sorting
    CreateUpdateRawMaterialDetailDto>, //Used to create/update a book
IRawMaterialDetailAppService //implement the IBookAppService
    {
        public RawMaterialDetailAppService(IRepository<RawMaterialDetail, Guid> repository)
        : base(repository)
        {

        }
    }
}
