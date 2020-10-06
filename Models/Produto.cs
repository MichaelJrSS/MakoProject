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
        public int ProdutoId { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Detalhamento { get; set; }

        public virtual Categoria Categoria { get; set; }
        
        public int CategoriaId { get; set; }


        [Required]
        public int Quantidade { get; set; }

        public bool Estoque { get; set; }

        [Required]
        [Display(Name = "Preco do Produto")]
        //[DisplayFormat(DataFormatString = "{0,c}")]
        public decimal Preco { get; set; }

        public string ImagemUrl { get; set; }

        public string ImagemMiniatura { get; set; }



    }
}
