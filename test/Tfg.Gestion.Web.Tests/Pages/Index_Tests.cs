using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Tfg.Gestion.Pages;

public class Index_Tests : GestionWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
