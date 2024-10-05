using Ecommerce.Produto.Domain.Entities;

namespace Ecommerce.Produto.Domain.Interfaces
{
    public interface ICategoriaApplicationService
    {
        IEnumerable<CategoriaEntity> ObterTodasCategorias();
        CategoriaEntity? ObterCategoriaPorId(int id);
        CategoriaEntity? SalvarDadosCategoria(CategoriaEntity entity);
        CategoriaEntity? EditarDadosCategoria(CategoriaEntity entity);
        CategoriaEntity? DeletarDadosCategoria(int id);
    }
}