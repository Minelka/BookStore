using BookStore.AspNetCoreMvc.Context.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using BookStore.AspNetCoreMvc.Context.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BookStore.AspNetCoreMvc.Context
{
    public class BaseStoreDbContext : DbContext
    {
        #region eski construct
        //private static string _connectionString;

        //public BookStoreDbContext(IConfiguration configuration)
        //{
        //    _connectionString = configuration.GetConnectionString("BookStoreDbBilkent");

        //    //var test = configuration.GetSection("Ogrenciler:Ank18:Mustafa").Value;

        //    //Console.WriteLine("ConStr:" + _connectionString);
        //    //Console.WriteLine("test:" + test);
        //} 
        #endregion

        public BaseStoreDbContext(DbContextOptions contextOptions) : base(contextOptions)
        {

        }

        public DbSet<City> Cities { get; set; }

        #region Eski Configuration
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_connectionString);
        //} 
        #endregion
    }
}
