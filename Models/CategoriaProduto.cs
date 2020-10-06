using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mako.Models
{
    public class CategoriaProduto
    {
        public int CategoriaId { get; set; }
        public string CategoriaNome { get; set; }
        public string Descricao { get; set; }



        public List<Produto> Produtos { get; set; }
        //definicao da lista para produtos, relacionamento 1:N


    }
}
