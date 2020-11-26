using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mako.Models;

namespace Mako.ViewModels
{
    public class PedidoProdutoViewModel
    {

        public Pedido Pedido { get; set; }

        public IEnumerable<PedidoDetalhe> PedidoDetalhes { get; set; }


    }
}
