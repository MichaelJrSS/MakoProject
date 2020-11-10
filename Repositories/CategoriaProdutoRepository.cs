using Mako.Models;
using System.Collections.Generic;

namespace Mako.Repositories
{
    public class CategoriaProdutoRepository : ICategoriaProdutoRepository
    {
        private readonly MakoContext _context;

        public CategoriaProdutoRepository(MakoContext contexto)//vinculo do contexto com o repositorio para ele poder ser substituido
        {
            _context = contexto;

        }
        public IEnumerable<CategoriaProduto> CategoriaProduto => _context.CategoriaProduto;
    }
}
