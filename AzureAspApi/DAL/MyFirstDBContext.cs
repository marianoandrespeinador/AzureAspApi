using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using AzureAspApi.Models;

namespace AzureAspApi.DAL
{
    public class MyFirstDBContext : DbContext
    {
        public MyFirstDBContext() : base("DefaultConnection")
        {
        }

        public DbSet<Associate> Associates { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}