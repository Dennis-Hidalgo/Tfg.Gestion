using System.Threading.Tasks;

namespace Tfg.Gestion.Data;

public interface IGestionDbSchemaMigrator
{
    Task MigrateAsync();
}
