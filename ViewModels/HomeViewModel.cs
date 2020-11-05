using Mako.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mako.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Produto> ProdutosPreferidos { get; set; }

    }
}
