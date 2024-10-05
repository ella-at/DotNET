using Ecommerce.Produto.Domain.Entities;
using Ecommerce.Produto.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Produto.Application.DTOs;
using FluentValidation.Results;
using Ecommerce.Produto.Application.DTOs.Categoria;

namespace Ecommerce.Produto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaApplicationService _categoriaApplicationService;
        private readonly CategoriaDTOValidator _categoriaDTOValidator;

        public CategoriaController(ICategoriaApplicationService categoriaApplicationService)
        {
            _categoriaApplicationService = categoriaApplicationService;
            _categoriaDTOValidator = new CategoriaDTOValidator();
        }

        /// <summary>
        /// Metodo para obter todos os dados de categoria
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces<IEnumerable<CategoriaEntity>>]
        public IActionResult Get()
        {
            var categorias = _categoriaApplicationService.ObterTodasCategorias();

            if(categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel obter os dados");
        }

        /// <summary>
        /// Metodo para obter uma categoria
        /// </summary>
        /// <param name="id"> Identificado da categoria</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces<CategoriaEntity>]
        public IActionResult GetPorId(int id)
        {
            var categoria = _categoriaApplicationService.ObterCategoriaPorId(id);

            if (categoria is not null)
                return Ok(categoria);

            return BadRequest("Não foi possivel obter os dados");
        }


        /// <summary>
        /// Metodos para salvar a categoria
        /// </summary>
        /// <param name="categoriaDTO"> Modelo de dados da Categoria</param>
        /// <returns></returns>
        [HttpPost]
        [Produces<CategoriaEntity>]
        public IActionResult Post([FromBody] CategoriaDTO categoriaDTO)
        {
            ValidationResult result = _categoriaDTOValidator.Validate(categoriaDTO);
            if (!result.IsValid)
                return BadRequest(result.Errors);

            var entity = new CategoriaEntity
            {
                Nome = categoriaDTO.Nome,
                Descricao = categoriaDTO.Descricao
            };


            var categoria = _categoriaApplicationService.SalvarDadosCategoria(entity);

            if (categoria is not null)
                return Ok(categoria);

            return BadRequest("Não foi possivel salvar os dados");
        }

        /// <summary>
        /// Metodos para editar a categoria
        /// </summary>
        /// <param name="categoriaDTO"> </param>
        /// <param name="id"> Modelo de dados da Categoria</param>
        /// <returns></returns>
        [HttpPut]
        [Produces<CategoriaEntity>]
        public IActionResult Put([FromBody] CategoriaDTO categoriaDTO, [FromQuery] int id)
        {

            ValidationResult result = _categoriaDTOValidator.Validate(categoriaDTO);
            if (!result.IsValid)
                return BadRequest(result.Errors);

            var entity = new CategoriaEntity
            {
                Id = id,
                Nome = categoriaDTO.Nome,
                Descricao = categoriaDTO.Descricao
            };


            var categoria = _categoriaApplicationService.EditarDadosCategoria(entity);

            if (categoria is not null)
                return Ok(categoria);

            return BadRequest("Não foi possivel editar os dados");
        }

        /// <summary>
        /// Metodo para deletar uma categoria
        /// </summary>
        /// <param name="id"> Identificado da categoria</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Produces<CategoriaEntity>]
        public IActionResult Delete(int id)
        {
            var categoria = _categoriaApplicationService.DeletarDadosCategoria(id);

            if (categoria is not null)
                return Ok(categoria);

            return BadRequest("Não foi possivel deletar os dados");
        }
    }
}
