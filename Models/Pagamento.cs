using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mako.Models
{
    [Table("Pagamentos")]
    public class Pagamento
    {
        public int Id { get; set; }

       
    }
}
