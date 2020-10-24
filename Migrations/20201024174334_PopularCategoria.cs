using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mako.Migrations
{
    public partial class PopularCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migracao inicial apenas para ver se a estrutura do banco esta correta
            migrationBuilder.Sql("INSERT INTO CategoriaProduto(CategoriaNome,Descricao) VALUES('Facas','tipos de facas')");
            migrationBuilder.Sql("INSERT INTO CategoriaProduto(CategoriaNome,Descricao) VALUES('Martelos','tipos de martelo')");


            migrationBuilder.Sql("INSERT INTO Produtos(Nome,Descricao,Detalhamento,CategoriaId,Estoque,Preco,ImagemUrl,ImagemMIniatura)" +
                                             " VALUES('faca 1','Descrição breve da faca1','Descrição detalhada da Faca1',(select Id from CategoriaProduto where CategoriaNome='facas'),1,100.99,'https://images.madeiramadeira.com.br/product/images/98293474-faca-de-aco-damasco-padrao-mosaico-120-camadas-8-gaucha-para-churrasco49damasco28-42-3-600x600.jpg','https://img.olx.com.br/thumbs256x256/41/415030777408423.jpg')");
           
            migrationBuilder.Sql("INSERT INTO Produtos(Nome,Descricao,Detalhamento,CategoriaId,Estoque,Preco,ImagemUrl,ImagemMIniatura)" +
                                             " VALUES('faca 2','Descrição breve da faca2','Descrição detalhada da Faca2',(select Id from CategoriaProduto where CategoriaNome='facas'),1,10.99,'https://images.madeiramadeira.com.br/product/images/98293474-faca-de-aco-damasco-padrao-mosaico-120-camadas-8-gaucha-para-churrasco49damasco28-42-3-600x600.jpg','https://img.olx.com.br/thumbs256x256/41/415030777408423.jpg')");
           
            migrationBuilder.Sql("INSERT INTO Produtos(Nome,Descricao,Detalhamento,CategoriaId,Estoque,Preco,ImagemUrl,ImagemMIniatura)" +
                                             " VALUES('martelo','Descrição breve do martelo','Descrição detalhada do martelo',(select Id from CategoriaProduto where CategoriaNome='Martelos'),1,1000.99,'https://images.madeiramadeira.com.br/product/images/98293474-faca-de-aco-damasco-padrao-mosaico-120-camadas-8-gaucha-para-churrasco49damasco28-42-3-600x600.jpg','https://img.olx.com.br/thumbs256x256/41/415030777408423.jpg')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM CategoriaProduto");
            migrationBuilder.Sql("DELETE FROM Produtos");

        }
    }
}
