using Ecommerce.Produto.Domain.Entities;
using Ecommerce.Produto.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Produto.Application.Services
{
    public class CategoriaApplicationService : ICategoriaApplicationService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaApplicationService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public CategoriaEntity? DeletarDadosCategoria(int id)
        {
            return _categoriaRepository.DeletarDados(id);  
        }

        public CategoriaEntity? EditarDadosCategoria(CategoriaEntity entity)
        {
            return _categoriaRepository.EditarDados(entity);
        }

        public CategoriaEntity? ObterCategoriaPorId(int id)
        {
            return _categoriaRepository.ObterPorId(id);
        }

        public IEnumerable<CategoriaEntity> ObterTodasCategorias()
        {
            return _categoriaRepository.ObterTodos();
        }

        public CategoriaEntity? SalvarDadosCategoria(CategoriaEntity entity)
        {
            return _categoriaRepository.SalvarDados(entity);
        }
    }
}
