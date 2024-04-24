using Tfg.Gestion.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Tfg.Gestion.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(GestionEntityFrameworkCoreModule),
    typeof(GestionApplicationContractsModule)
    )]
public class GestionDbMigratorModule : AbpModule
{
}
