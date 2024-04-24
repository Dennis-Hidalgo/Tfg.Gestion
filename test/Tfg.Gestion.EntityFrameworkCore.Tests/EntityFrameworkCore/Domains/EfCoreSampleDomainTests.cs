using Tfg.Gestion.Samples;
using Xunit;

namespace Tfg.Gestion.EntityFrameworkCore.Domains;

[Collection(GestionTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<GestionEntityFrameworkCoreTestModule>
{

}
