using Mako.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mako.Components
{
    public class CategoriaMenu :ViewComponent
    {
        private readonly ICategoriaProdutoRepository _categoriaProdutoRepository;

            public CategoriaMenu(ICategoriaProdutoRepository categoriaProdutoRepository)
            {
                _categoriaProdutoRepository = categoriaProdutoRepository;
            }
        public IViewComponentResult Invoke()
        {
            var categorias = _categoriaProdutoRepository.CategoriaProduto.OrderBy(c => c.CategoriaNome);

            return View(categorias);
        }

    }
}
