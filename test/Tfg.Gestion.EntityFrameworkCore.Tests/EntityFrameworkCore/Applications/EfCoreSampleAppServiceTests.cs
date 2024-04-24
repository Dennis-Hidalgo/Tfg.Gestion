using Tfg.Gestion.Samples;
using Xunit;

namespace Tfg.Gestion.EntityFrameworkCore.Applications;

[Collection(GestionTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<GestionEntityFrameworkCoreTestModule>
{

}
