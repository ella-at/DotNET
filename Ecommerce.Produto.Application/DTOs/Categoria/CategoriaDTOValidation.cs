using Ecommerce.Produto.Application.DTOs;
using FluentValidation;

namespace Ecommerce.Produto.Application.DTOs.Categoria
{

    public class CategoriaDTOValidator : AbstractValidator<CategoriaDTO>
    {
        public CategoriaDTOValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("É obrigatório informar o nome da categoria.")
                .MaximumLength(100).WithMessage("O nome da categoria pode ter no máximo 100 caracteres.");


            RuleFor(p => p.Descricao)
                .NotEmpty().WithMessage("É obrigatório preencher a descrição da categoria.")
                .MaximumLength(250).WithMessage("A descrição da categoria pode ter no máximo 250 caracteres.");


        }
    }
}