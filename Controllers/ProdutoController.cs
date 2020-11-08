using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mako.Models;
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

        public IActionResult List(string categoria)
        {
            // ViewBag.produto = "Produtos";
            //ViewData["CategoriaProduto"] = "CategoriaProduto";
            // var produtos = _produtoRepository.Produtos;
            //return View(produtos);

            string _categoria = categoria;
            IEnumerable<Produto> produtos;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                produtos = _produtoRepository.Produtos.OrderBy(p => p.ProdutoId);
                categoria = "Todos os Produtos";
            }
            else
            {
                if (string.Equals("Facas", _categoria, StringComparison.OrdinalIgnoreCase))
                {
                    produtos = _produtoRepository.Produtos.Where(p => p.Categoria.CategoriaNome.Equals("Facas")).OrderBy(p => p.Nome);
                }
                else
                {
                    produtos = _produtoRepository.Produtos.Where(p => p.Categoria.CategoriaNome.Equals("Martelos")).OrderBy(p => p.Nome);
                }
                //outras comparacoes podem ser definidas de acordo com as categorias que forem criadas com o tempo

                categoriaAtual = _categoria;
            }


            //var produtosListViewModel = new ProdutoListViewModel();
            //produtosListViewModel.Produtos = _produtoRepository.Produtos;
            // produtosListViewModel.CategoriaAtual = "Categoria Atual";



            var produtosListViewModel = new ProdutoListViewModel
            {
                Produtos = produtos,
                CategoriaAtual = categoriaAtual
            };
          return View(produtosListViewModel);
        }
        
        public IActionResult Details(int produtoId)
        {
            var produto = _produtoRepository.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            if(produto == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(produto);
        }

    }
}
