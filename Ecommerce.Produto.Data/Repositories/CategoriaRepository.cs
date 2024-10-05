using Ecommerce.Produto.Data.AppData;
using Ecommerce.Produto.Domain.Entities;
using Ecommerce.Produto.Domain.Interfaces;

namespace Ecommerce.Produto.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ApplicationContext _context;

        public CategoriaRepository(ApplicationContext context)
        {
            _context = context;
        }

        public CategoriaEntity? DeletarDados(int id)
        {
            var categoria = _context.Categoria.Find(id);

            if(categoria is not null)
            {
                _context.Categoria.Remove(categoria);
                _context.SaveChanges();

                return categoria;
            }

            return null;
        }

        public CategoriaEntity? EditarDados(CategoriaEntity entity)
        {
            var categoria = _context.Categoria.Find(entity.Id);

            if (categoria is not null)
            {

                categoria.Nome = entity.Nome;
                categoria.Descricao = entity.Descricao;

                _context.Categoria.Update(categoria);
                _context.SaveChanges();

                return categoria;
            }

            return null;
        }

        public CategoriaEntity? ObterPorId(int id)
        {
            var categoria = _context.Categoria.Find(id);

            if (categoria is not null)
            { 
                return categoria;
            }

            return null;
        }

        public IEnumerable<CategoriaEntity> ObterTodos()
        {
            var categorias = _context.Categoria.ToList();

            return categorias;
        }

        public CategoriaEntity? SalvarDados(CategoriaEntity entity)
        {
            _context.Categoria.Add(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}
