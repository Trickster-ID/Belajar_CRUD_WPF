using belajarCRUDWPF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace belajarCRUDWPF.MyContext
{
    public class MyContext : DbContext
    {
        public MyContext() : base("BelajarCRUDWPF") { }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
