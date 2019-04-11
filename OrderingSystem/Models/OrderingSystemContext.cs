using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSystem.Models 
{
    public class OrderingSystemContext : DbContext
    {
        public OrderingSystemContext(DbContextOptions<OrderingSystemContext> options) : base(options)
        {

        }

        public OrderingSystemContext()
        {

        }
        //Tables DBsets
        public DbSet<User_Registration> User_Registration { get; set; }
        public DbSet<Category_Detail> Category_Detail { get; set; }
    }
}
