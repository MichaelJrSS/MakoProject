using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mako.Repositories;
using Mako.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Mako.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaProdutoRepository _categoriaProdutoRepository;

        public ProdutoController(IProdutoRepository produtoRepository, ICategoriaProdutoRepository categoriaProdutoRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaProdutoRepository = categoriaProdutoRepository;
        }

        public IActionResult List()
        {
            ViewBag.produto = "Produtos";
            ViewData["CategoriaProduto"] = "CategoriaProduto";


            // var produtos = _produtoRepository.Produtos;
            //return View(produtos);


            var produtosListViewModel = new ProdutoListViewModel();
            produtosListViewModel.Produtos = _produtoRepository.Produtos;
            produtosListViewModel.CategoriaAtual = "Categoria Atual";
            return View(produtosListViewModel);
        }




    }
}
