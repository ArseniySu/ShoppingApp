using Microsoft.EntityFrameworkCore;
using ShoppingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=E:\\ShoppingApp\\Model\\ShopBD.db"); // Путь к файлу базы данных
            }
        }
    }
}

