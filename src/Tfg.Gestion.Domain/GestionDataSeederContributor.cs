using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tfg.Gestion.Products;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Tfg.Gestion
{
    public class GestionDataSeederContributor
        : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Product, Guid> _productRepository;

        public GestionDataSeederContributor(IRepository<Product, Guid> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _productRepository.GetCountAsync() <= 0)
            {
                await _productRepository.InsertAsync(
                    new Product
                    {
                        Title = "Testing product",
                        Description = "Description 1",
                        Price = 10.0f,
                        MyCategory = ProductCategory.Electronics,
                        Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ee/.NET_Core_Logo.svg/2048px-.NET_Core_Logo.svg.png",
                        Stock = 50
                    },
                    autoSave: true
                );

                await _productRepository.InsertAsync(
                    new Product
                    {
                        Title = "Testing product 2",
                        Description = "Description 2",
                        Price = 20.0f,
                        MyCategory = ProductCategory.Electronics,
                        Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ee/.NET_Core_Logo.svg/2048px-.NET_Core_Logo.svg.png",
                        Stock = 50
                    },
                    autoSave: true
                );
            }
        }
    }
}
