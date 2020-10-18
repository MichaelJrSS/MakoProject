using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mako.Models
{
    [Table("CategoriaProduto")]
    public class CategoriaProduto
    {

        public int Id { get; set; }
        public string CategoriaNome { get; set; }
        public string Descricao { get; set; }



        public List<Produto> Produtos { get; set; }
        //definicao da lista para produtos, relacionamento 1:N


    }
}
