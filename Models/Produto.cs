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

        [MinLength(0)]
        public int Estoque { get; set; }


        [Required]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public float Valor { get; set; }
        
        public byte[] Imagens { get; set; }



    }
}
