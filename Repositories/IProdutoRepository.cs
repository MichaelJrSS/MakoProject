using Mako.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mako.Repositories
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> Produtos { get; }
        IEnumerable<Produto> Preferido { get; }
        Produto GetProdutoById(int ProdutoId);

    }
}