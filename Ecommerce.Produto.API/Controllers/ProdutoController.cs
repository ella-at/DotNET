using Ecommerce.Produto.Domain.Entities;
using Ecommerce.Produto.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Produto.Application.DTOs;
using FluentValidation.Results;
using Ecommerce.Produto.Application.DTOs.Produto;

namespace Ecommerce.Produto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoApplicationService _produtoApplicationService;
        private readonly ProdutoDTOValidator _produtoDTOValidator;

        public ProdutoController(IProdutoApplicationService produtoApplicationService)
        {
            _produtoApplicationService = produtoApplicationService;
            _produtoDTOValidator = new ProdutoDTOValidator();
        }

        /// <summary>
        /// Metodo para obter todos os dados do produto
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces<IEnumerable<ProdutoEntity>>]
        public IActionResult Get()
        {
            var produtos = _produtoApplicationService.ObterTodosProdutos();

            if (produtos is not null)
                return Ok(produtos);

            return BadRequest("Não foi possivel obter os dados");
        }

        /// <summary>
        /// Metodo para obter um produto
        /// </summary>
        /// <param name="id"> Identificado do produto</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces<ProdutoEntity>]
        public IActionResult GetPorId(int id)
        {
            var produto = _produtoApplicationService.ObterProdutoPorId(id);

            if (produto is not null)
                return Ok(produto);

            return BadRequest("Não foi possivel obter os dados");
        }


        /// <summary>
        /// Metodos para salvar o produto
        /// </summary>
        /// <param name="produtoDTO"> Modelo de dados de produtos</param>
        /// <returns></returns>
        [HttpPost]
        [Produces<ProdutoEntity>]
        public IActionResult Post([FromBody] ProdutoDTO produtoDTO) 
        {
            ValidationResult result = _produtoDTOValidator.Validate(produtoDTO);

            if (!result.IsValid)
                return BadRequest(result.Errors);


            var entity = new ProdutoEntity
            {
                Nome = produtoDTO.Nome,
                Descricao = produtoDTO.Descricao,
                Quantidade = produtoDTO.Quantidade,
                CategoriaId = produtoDTO.CategoriaId,
            };

            var produto = _produtoApplicationService.SalvarDadosProduto(entity);

            if (produto is not null)
                return Ok(produto);

            return BadRequest("Não foi possivel salvar os dados");
        }

        /// <summary>
        /// Metodos para editar a produto
        /// </summary>
        /// <param name="produtoDTO"> </param>
        /// <param name="id"> Modelo de dados de produtos</param>
        /// <returns></returns>
        [HttpPut]
        [Produces<ProdutoEntity>]
        public IActionResult Put([FromBody] ProdutoDTO produtoDTO, [FromQuery] int id)
        {
            ValidationResult result = _produtoDTOValidator.Validate(produtoDTO);

            if (!result.IsValid)
                return BadRequest(result.Errors);

            var entity = new ProdutoEntity
            {
                Id = id,
                Nome = produtoDTO.Nome,
                Descricao = produtoDTO.Descricao
            };


            var produto = _produtoApplicationService.EditarDadosProduto(entity);

            if (produto is not null)
                return Ok(produto);

            return BadRequest("Não foi possível editar os dados");
        }

        /// <summary>
        /// Metodo para deletar um produto
        /// </summary>
        /// <param name="id"> Identificado do produto</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Produces<ProdutoEntity>]
        public IActionResult Delete(int id)
        {
            var produto = _produtoApplicationService.DeletarDadosProduto(id);

            if (produto is not null)
                return Ok(produto);

            return BadRequest("Não foi possivel deletar os dados");
        }
    }
}
