using Mako.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mako.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly MakoContext _context;

        public ProdutoRepository(MakoContext contexto)
        {
            _context = contexto;
        }
        public IEnumerable<Produto> Produtos => _context.Produtos.Include(c => c.Categoria);//enumera os produtos e inclui a busca das categorias tambem

        public Produto GetProdutoById(int ProdutoId)
        {               //retorna o produto quando esse eh comparado com o produto que esta buscando no contexto
            return _context.Produtos.FirstOrDefault(p => p.ProdutoId == ProdutoId);
        }
    }
}
