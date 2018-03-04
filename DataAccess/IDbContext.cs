using System;

namespace DataAccess
{
    public interface IDbContext : IDisposable
    {
        int SaveChanges();
    }
}
