using CafeManagementSystem.Common;
using CafeSystemManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagementSystem.DataLayer
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public DataContext(DbContextOptions<DataContext> options)
             : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Category> Categories { get; set; }

         
    }
}

     
