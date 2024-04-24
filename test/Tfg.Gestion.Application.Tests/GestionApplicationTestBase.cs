using Volo.Abp.Modularity;

namespace Tfg.Gestion;

public abstract class GestionApplicationTestBase<TStartupModule> : GestionTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
