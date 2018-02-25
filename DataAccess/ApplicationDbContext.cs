using System;
using System.Collections.Generic;
using System.Text;
using DatabaseMigrations;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Security;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext, IDbContext
    {
        #region DbSets

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        #endregion DbSets

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
