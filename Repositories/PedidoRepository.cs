using Mako.Models;
using System;

namespace Mako.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly MakoContext _makoContext;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(MakoContext makoContext, CarrinhoCompra carrinhoCompra)
        {
            _makoContext = makoContext;
            _carrinhoCompra = carrinhoCompra;
        }
        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _makoContext.Pedidos.Add(pedido);

            var carrinhoCompraItems = _carrinhoCompra.CarrinhoCompraItems;

            foreach(var carrinhoItem in carrinhoCompraItems)
            {
                var pedidoDetalhe = new PedidoDetalhe()
                {
                    Quantidade = carrinhoItem.Quantidade,
                    ProdutoId = carrinhoItem.Produto.ProdutoId,
                    PedidoId = pedido.PedidoId,
                    Preco = carrinhoItem.Produto.Preco
                };

                _makoContext.PedidoDetalhes.Add(pedidoDetalhe);
            }

            _makoContext.SaveChanges();

        }
    }
}
