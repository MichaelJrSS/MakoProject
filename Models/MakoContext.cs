using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mako.Models
{
    public class MakoContext : DbContext
    {
        public MakoContext(DbContextOptions<MakoContext> options) : base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }

         
    }

}
