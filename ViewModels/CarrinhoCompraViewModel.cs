using Mako.Migrations;
using Mako.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mako.ViewModels
{
    public class CarrinhoCompraViewModel
    {
        public CarrinhoCompra CarrinhoCompra { get; set; }
        public decimal CarrinhoCompraTotal { get; set; }

    }
}
