using Mako.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mako.Repositories
{
    interface IProdutoRepository
    {
        IEnumerable<Produto> Produtos { get; }
        Produto GetProdutoById(int ProdutoId);
    }
}