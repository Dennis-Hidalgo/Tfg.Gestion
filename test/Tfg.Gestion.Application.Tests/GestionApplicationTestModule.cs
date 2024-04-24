using Volo.Abp.Modularity;

namespace Tfg.Gestion;

[DependsOn(
    typeof(GestionApplicationModule),
    typeof(GestionDomainTestModule)
)]
public class GestionApplicationTestModule : AbpModule
{

}
