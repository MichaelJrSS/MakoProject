using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mako.Models
{
    public class CarrinhoCompra
    {
        private readonly MakoContext _context;

        public CarrinhoCompra(MakoContext contexto)
        {
            _context = contexto;

        }
        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }


        //metodo de obter o carrinho
        public static CarrinhoCompra GetCarrinho(System.IServiceProvider services)
        {

            //obtem uma sessao que foi criada no provedor de servico
                                                                                 // ?retorna nullo se a interface nao tiver sessao
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<MakoContext>();
                                                                //numero aleatorio do carrinho caso a sessao nao existir
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            session.SetString("CarrinhoId", carrinhoId);

            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };
                    
        }
        public void AdicionarAoCarrinho(Produto produto, int quantidade)
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItems.SingleOrDefault(
                s => s.Produto.ProdutoId == produto.ProdutoId && s.CarrinhoCompraId == CarrinhoCompraId);

            if(carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Produto = produto,
                    Quantidade = 1
                };
                _context.CarrinhoCompraItems.Add(carrinhoCompraItem);

            }
            else
            {
                carrinhoCompraItem.Quantidade++;

            }
            _context.SaveChanges();
        }
        public int RemoverDoCarrinho(Produto produto)
        {
            var carrinhoCompraItem =
                    _context.CarrinhoCompraItems.SingleOrDefault(
                        s => s.Produto.ProdutoId == produto.ProdutoId && s.CarrinhoCompraId == CarrinhoCompraId);

            var quantidadeLocal = 0;

            if (carrinhoCompraItem != null)
            {
                if (carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                    quantidadeLocal = carrinhoCompraItem.Quantidade;
                }
                else
                {
                    _context.CarrinhoCompraItems.Remove(carrinhoCompraItem);
                }
            }

            _context.SaveChanges();

            return quantidadeLocal;
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItems()
        {
            return CarrinhoCompraItems ??
                   (CarrinhoCompraItems = _context.CarrinhoCompraItems.Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                           .Include(s => s.Produto)
                           .ToList());
        }
        public void LimparCarrinho()
        {
            var carrinhoItems = _context.CarrinhoCompraItems
                                 .Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId);

            _context.CarrinhoCompraItems.RemoveRange(carrinhoItems);

            _context.SaveChanges();
        }

        public decimal GetCarrinhoCompraTotal()
        {
            var total = _context.CarrinhoCompraItems.Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                .Select(c => c.Produto.Preco * c.Quantidade).Sum();

            return total;
        }
    }
}
