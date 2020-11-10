using Mako.Models;
using System.Collections.Generic;

namespace Mako.Repositories
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> Produtos { get; }
        IEnumerable<Produto> Preferido { get; }
        Produto GetProdutoById(int ProdutoId);

    }
}