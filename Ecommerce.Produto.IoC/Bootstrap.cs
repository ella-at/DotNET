using Ecommerce.Produto.Application.Services;
using Ecommerce.Produto.Data.AppData;
using Ecommerce.Produto.Data.Repositories;
using Ecommerce.Produto.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Ecommerce.Produto.IoC
{
    public static class Bootstrap
    {
        public static void Start(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options => {
                options.UseOracle(configuration["ConnectionStrings:Oracle"]);
            });


            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();


            services.AddTransient<ICategoriaApplicationService, CategoriaApplicationService>();
            services.AddTransient<IProdutoApplicationService, ProdutoApplicationService>();
        }
    }
}
