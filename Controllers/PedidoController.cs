using Mako.Models;
using Mako.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mako.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra)
        {
            _pedidoRepository = pedidoRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        [HttpGet]
        [Authorize]    //annotation para validar autenticacao, os metodos actions com essa tag nao irao ser chamados a nao ser que o usuario tenha feito login
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Checkout(Pedido pedido)
        {
            var items = _carrinhoCompra.GetCarrinhoCompraItems();

            _carrinhoCompra.CarrinhoCompraItems = items;

            if (_carrinhoCompra.CarrinhoCompraItems.Count == 0) //vai validar se o carrinho esta vazio
            {
                ModelState.AddModelError("", "Seu carrinho esta vazio!");
            }

            if (ModelState.IsValid)
            {
                _pedidoRepository.CriarPedido(pedido);
                /*TempData["Cliente"] = pedido.Nome;
                TempData["NumeroPedido"] = pedido.PedidoId;
                TempData["DataPedido"] = pedido.PedidoEnviado;*/
                TempData["TotalPedido"] = _carrinhoCompra.GetCarrinhoCompraTotal();
                
                ViewBag.CheckoutCompletoMensagem = "Seu Pedido foi criado com sucesso! ";
                ViewBag.TotalPedido = TempData["TotalPedido"];

                _carrinhoCompra.LimparCarrinho();
                
                //return RedirectToAction("CheckoutCompleto");
                return View("~/Views/Pedido/CheckoutCompleto.cshtml", pedido);
            }

            return View(pedido);
        }

                public IActionResult CheckoutCompleto()
                {

                    ViewBag.Cliente = TempData["Cliente"];
                    ViewBag.DataPedido = TempData["DataPedido"];
                    ViewBag.NumeroPedido = TempData["NumeroPedido"];
                    
                    
                    return View();
                }
        
      /* public IActionResult CheckoutCompleto(Pedido pedido)
       {

            // aqui vai a integracao com a API do MERCADO PAGO, por hora apenas mostra 
            //um resumo do pedido que foi alimentado dentro das tabelas

           ViewBag.Cliente = TempData["Cliente"];
           ViewBag.DataPedido = TempData["DataPedido"];
           ViewBag.NumeroPedido = TempData["NumeroPedido"];
           ViewBag.TotalPedido = TempData["TotalPedido"];
           ViewBag.CheckoutCompletoMensagem = "Seu Pedido foi enviado TESTE ";

           return View(pedido);
        }*/
    }
}
