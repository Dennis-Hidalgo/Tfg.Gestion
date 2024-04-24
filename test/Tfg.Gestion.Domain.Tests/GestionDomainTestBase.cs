using Volo.Abp.Modularity;

namespace Tfg.Gestion;

/* Inherit from this class for your domain layer tests. */
public abstract class GestionDomainTestBase<TStartupModule> : GestionTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
