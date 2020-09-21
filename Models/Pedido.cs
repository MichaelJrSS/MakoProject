using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mako.Models
{
    [Table("Pedidos")]
    public class Pedido
    {
        public int Id { get; set; }

        [Display(Name = "Data do Pedido")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime Datapedido { get; set; }
        [Required]
        public int ClienteId { get; set; }
     
        [Required]
        public int ProdutoId { get; set; }

        [Required]
        public int PagamentoId { get; set; }

    }
}
