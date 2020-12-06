using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Web_Data.Model;

namespace Web_Data
{
   public class UserDbContext:DbContext
    {
        public UserDbContext()
        {

        }
        public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
