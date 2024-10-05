using Ecommerce.Produto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Produto.Data.AppData
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }

        public DbSet<CategoriaEntity> Categoria { get; set; }
        public DbSet<ProdutoEntity> Produto { get; set; }
    }
}
