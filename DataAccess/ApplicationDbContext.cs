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
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Privator> Privators { get; set; }
        public DbSet<Redactor> Redactors { get; set; }

        public DbSet<RegistrationToken> RegistrationTokens { get; set; }
        #endregion DbSets

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
