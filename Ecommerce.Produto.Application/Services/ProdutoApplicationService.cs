using Ecommerce.Produto.Domain.Entities;
using Ecommerce.Produto.Domain.Interfaces;

namespace Ecommerce.Produto.Application.Services
{
    public class ProdutoApplicationService: IProdutoApplicationService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoApplicationService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public ProdutoEntity? DeletarDadosProduto(int id)
        {
            return _repository.DeletarDados(id);
        }

        public ProdutoEntity? EditarDadosProduto(ProdutoEntity entity)
        {
            return _repository.EditarDados(entity);
        }

        public ProdutoEntity? ObterProdutoPorId(int id)
        {
            return _repository.ObterPorId(id);  
        }

        public IEnumerable<ProdutoEntity> ObterTodosProdutos()
        {
            return _repository.ObterTodos();
        }

        public ProdutoEntity? SalvarDadosProduto(ProdutoEntity entity)
        {
            return _repository.SalvarDados(entity);
        }
    }
}
