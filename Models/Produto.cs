using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Mako.Models
{
    [Table("Produtos")]
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Categoria { get; set; }

        [Required]
        public int Quantidade { get; set; }

        public int Estoque { get; set; }

        [Required]
        [Display(Name = "Preco do Produto")]
        [DisplayFormat(DataFormatString = "{0,c}")]
        public decimal Valor { get; set; }

        public string Imagens { get; set; }



    }
}
