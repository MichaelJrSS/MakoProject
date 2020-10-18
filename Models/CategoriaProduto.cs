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

        [StringLength(100)]
        public string CategoriaNome { get; set; }


        [StringLength(200)]
        public string Descricao { get; set; }



        public List<Produto> Produtos { get; set; }
        //definicao da lista para produtos, relacionamento 1:N


    }
}
