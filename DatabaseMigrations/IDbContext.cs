using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseMigrations
{
    public interface IDbContext : IDisposable
    {
        int SaveChanges();
    }
}
