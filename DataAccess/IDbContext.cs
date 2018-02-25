using System;

namespace DatabaseMigrations
{
    public interface IDbContext : IDisposable
    {
        int SaveChanges();
    }
}
