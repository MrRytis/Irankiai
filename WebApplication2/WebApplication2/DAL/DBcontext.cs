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
        public DBcontext() : base("MVCDB")
        {
            Database.SetInitializer<DBcontext>(new CreateDatabaseIfNotExists<DBcontext>());
        }

        public DbSet<InvoiceModel> Invoices { get; set; }
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<RentModel> Rents { get; set; }
        public DbSet<BidModel> Bids { get; set; }
        public DbSet<AuctionModel> Auctions { get; set; }
        public DbSet<AdvertModel> Adverts { get; set; }
        public DbSet<TransportRequestModel> TransportRequests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}