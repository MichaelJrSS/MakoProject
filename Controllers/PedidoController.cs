using Mako.Models;
using Mako.Repositories;
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
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
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
                _carrinhoCompra.LimparCarrinho();

                //return RedirectToAction("CheckoutCompleto");
                return View("~/Views/Pedido/CheckoutCompleto.cshtml", pedido);
            }

            return View(pedido);
        }

       public IActionResult CheckoutCompleto()
        {
            ViewBag.CheckoutCompletoMensagem = "Seu Pedido foi Enviado com sucesso! ";
            return View();
        }
        
        //public IActionResult CheckoutCompleto(Pedido pedido)
        //{
         //   ViewBag.Cliente = TempData["Cliente"];
           // ViewBag.DataPedido = TempData["DataPedido"];
         //   ViewBag.NumeroPedido = TempData["NumeroPedido"];
          //  ViewBag.TotalPedido = TempData["TotalPedido"];
          //  ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu pedido :) ";

            //return View(pedido);
        //}
    }
}
