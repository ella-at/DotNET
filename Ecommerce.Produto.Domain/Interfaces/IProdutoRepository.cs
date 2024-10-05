using Ecommerce.Produto.Domain.Entities;

namespace Ecommerce.Produto.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        IEnumerable<ProdutoEntity> ObterTodos();
        ProdutoEntity? ObterPorId(int id);
        ProdutoEntity? SalvarDados(ProdutoEntity entity);
        ProdutoEntity? EditarDados(ProdutoEntity entity);
        ProdutoEntity? DeletarDados(int id);
    }
}