using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Produto.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_tb_prod_produto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_prod_produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Quantidade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CategoriaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_prod_produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_prod_produto_tb_prod_categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "tb_prod_categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_prod_produto_CategoriaId",
                table: "tb_prod_produto",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_prod_produto");
        }
    }
}
