using Ecommerce.Produto.Data.AppData;
using Ecommerce.Produto.Domain.Entities;
using Ecommerce.Produto.Domain.Interfaces;

namespace Ecommerce.Produto.Data.Repositories
{
    public class ProdutoRepository: IProdutoRepository
    {
        private readonly ApplicationContext _context;

        public ProdutoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public ProdutoEntity? DeletarDados(int id)
        {
            var produto = _context.Produto.Find(id);

            if (produto is not null)
            {
                _context.Produto.Remove(produto);
                _context.SaveChanges();

                return produto;
            }

            return null;
        }

        public ProdutoEntity? EditarDados(ProdutoEntity entity)
        {
            var produto = _context.Produto.Find(entity.Id);

            if (produto is not null)
            {

                produto.Nome = entity.Nome;
                produto.Descricao = entity.Descricao;
                produto.Quantidade = entity.Quantidade;
                produto.CategoriaId = entity.CategoriaId;

                _context.Produto.Update(produto);
                _context.SaveChanges();

                return produto;
            }

            return null;
        }

        public ProdutoEntity? ObterPorId(int id)
        {
            var produto = _context.Produto.Find(id);

            if (produto is not null)
            {
                return produto;
            }

            return null;
        }

        public IEnumerable<ProdutoEntity> ObterTodos()
        {
            var produtos = _context.Produto.ToList();

            return produtos;
        }

        public ProdutoEntity? SalvarDados(ProdutoEntity entity)
        {
            entity.Categoria = null;

            _context.Produto.Add(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}
