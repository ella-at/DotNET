using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Produto.Domain.Entities
{
    [Table("tb_prod_produto")]
    public class ProdutoEntity
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public int CategoriaId { get; set; }
        public CategoriaEntity? Categoria { get; set; }
    }
}
