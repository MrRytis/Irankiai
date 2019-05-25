using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.DAL
{
    public class DBcontext: DbContext
    {
        public DBcontext() : base("NewContext")
        {
            Database.SetInitializer<DBcontext>(new CreateDatabaseIfNotExists<DBcontext>());
        }

        public DbSet<InvoiceModel> Invoices { get; set; }
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<RentModel> Rents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}