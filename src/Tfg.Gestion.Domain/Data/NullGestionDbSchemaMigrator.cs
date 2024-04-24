using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Tfg.Gestion.Data;

/* This is used if database provider does't define
 * IGestionDbSchemaMigrator implementation.
 */
public class NullGestionDbSchemaMigrator : IGestionDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
