using Mako.Repositories;
using Mako.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace Mako.Controllers
{

    public class HomeController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public HomeController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                ProdutosPreferidos = _produtoRepository.Preferido
            };
            return View(homeViewModel);
        }

        public ViewResult AccessDenied()
        {
            return View();

        }




    }
}
