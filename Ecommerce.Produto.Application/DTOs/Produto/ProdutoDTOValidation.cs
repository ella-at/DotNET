using Ecommerce.Produto.Application.DTOs;
using FluentValidation;

namespace Ecommerce.Produto.Application.DTOs.Produto
{
    public class ProdutoDTOValidator : AbstractValidator<ProdutoDTO>
    {
        public ProdutoDTOValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("É obrigatório informar o nome do produto.")
                .MaximumLength(100).WithMessage("O nome do produto pode ter no máximo 100 caracteres.");


            RuleFor(p => p.Descricao)
                .NotEmpty().WithMessage("É obrigatório preencher a descrição do produto.")
                .MaximumLength(250).WithMessage("A descrição do produto pode ter no máximo 250 caracteres.");


            RuleFor(p => p.Quantidade)
                .GreaterThanOrEqualTo(0).WithMessage("É proibido que a quantidade em estoque seja negativa.");


            RuleFor(p => p.CategoriaId)
                .GreaterThan(0).WithMessage("É obrigatório que cada categoria tenha um ID e ele deve ser maior que zero.");
        }
    }

}