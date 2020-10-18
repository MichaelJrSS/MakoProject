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
        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(100)]
        public string Descricao { get; set; }

        [StringLength(255)]
        public string Detalhamento { get; set; }

         //criado o grupo de categoria para ter multiplos tipos
        public virtual CategoriaProduto Categoria { get; set; }
        
        public int CategoriaId { get; set; }
           // apagado a quantidade pois cada faca sera unica mesmo
        public bool Estoque { get; set; }

        //[Required]
       //[Display(Name = "Preco do Produto")]>>>>>tentativa 1
        //[DisplayFormat(DataFormatString = "{0,c}")]>>>>>>tentativa 2
        [Column(TypeName ="decimal(18,2)")]   /// esse ta ok ;)
        public decimal Preco { get; set; }

        [StringLength(200)]
        public string ImagemUrl { get; set; }

        [StringLength(200)]
        public string ImagemMiniatura { get; set; }



    }
}
