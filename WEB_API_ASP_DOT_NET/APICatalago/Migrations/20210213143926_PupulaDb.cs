using Microsoft.EntityFrameworkCore.Migrations;

namespace APICatalago.Migrations
{
    public partial class PupulaDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(Nome, ImagemUrl) VALUES('Bebidas', 'http://macoratti.net/Imagens/1.jpg')");
            migrationBuilder.Sql("INSERT INTO Categorias(Nome, ImagemUrl) VALUES('Lanches', 'http://macoratti.net/Imagens/2.jpg')");
            migrationBuilder.Sql("INSERT INTO Categorias(Nome, ImagemUrl) VALUES('Sobremesas', 'http://macoratti.net/Imagens/3.jpg')");

            migrationBuilder.Sql("INSERT INTO Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) VALUES('Coca_cola Diet', 'Refrigerante de Cola 350ml', 5.45,'http://macoratti.net/Imagens/coca.jpg', 50, GETDATE(), (SELECT CategoriaId FROM Categorias WHERE Nome = 'Bebidas') )");

            migrationBuilder.Sql("INSERT INTO Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) VALUES('Lanche de Atum', 'Lanche de Atum com Maionese', 8.50,'http://macoratti.net/Imagens/atum.jpg', 10, GETDATE(), (SELECT CategoriaId FROM Categorias WHERE Nome = 'Lanches') )");

            migrationBuilder.Sql("INSERT INTO Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) VALUES('Pudim 100g', 'Pudim de Leite COndensado 100g', 6.75,'http://macoratti.net/Imagens/pudim.jpg', 20, GETDATE(), (SELECT CategoriaId FROM Categorias WHERE Nome = 'Sobremesas') )");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE Categorias");
            migrationBuilder.Sql("DELETE Produtos");
        }
    }
}
