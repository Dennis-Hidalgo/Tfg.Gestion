using Microsoft.AspNetCore.Builder;
using Tfg.Gestion;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<GestionWebTestModule>();

public partial class Program
{
}
