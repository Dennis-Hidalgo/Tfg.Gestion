using Xunit;

namespace Tfg.Gestion.EntityFrameworkCore;

[CollectionDefinition(GestionTestConsts.CollectionDefinitionName)]
public class GestionEntityFrameworkCoreCollection : ICollectionFixture<GestionEntityFrameworkCoreFixture>
{

}
