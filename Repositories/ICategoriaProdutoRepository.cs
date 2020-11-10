using Mako.Models;
using System.Collections.Generic;

namespace Mako.Repositories
{
    public interface ICategoriaProdutoRepository
    {
        IEnumerable<CategoriaProduto> CategoriaProduto { get; }

    }
}
