using Volo.Abp.Modularity;

namespace Tfg.Gestion;

[DependsOn(
    typeof(GestionDomainModule),
    typeof(GestionTestBaseModule)
)]
public class GestionDomainTestModule : AbpModule
{

}
