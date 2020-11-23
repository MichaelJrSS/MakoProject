using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mako.Models
{
    public class MakoContext : IdentityDbContext<IdentityUser>
        //DbContext
    {
        public MakoContext(DbContextOptions<MakoContext> options) : base(options) //definicao do banco padrao
        {

        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<CategoriaProduto> CategoriaProduto { get; set; }

        public DbSet<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoDetalhe> PedidoDetalhes { get; set; }
        
        
        
        //public DbSet<Cliente> Clientes { get; set; }


        //public DbSet<Pagamento> Pagamentos { get; set; }


    }

}
