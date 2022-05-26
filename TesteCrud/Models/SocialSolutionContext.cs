using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace TesteCrud.Models
{
    public class SocialSolutionContext : DbContext
    {
        public SocialSolutionContext() : base("SocialSolution")
        {
            Database.SetInitializer<SocialSolutionContext>(new CreateDatabaseIfNotExists<SocialSolutionContext>());
            //Database.SetInitializer<SocialSolutionContext>(null);

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        public DbSet<Imovel> Imoveis { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}