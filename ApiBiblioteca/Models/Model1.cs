using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ApiBiblioteca.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=ModeloBiblioteca")
        {
        }

        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<t01_libro> t01_libro { get; set; }
        public virtual DbSet<t02_autor> t02_autor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
