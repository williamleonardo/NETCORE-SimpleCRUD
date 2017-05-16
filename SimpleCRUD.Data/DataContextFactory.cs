using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace SimpleCRUD.Data
{
    public class DataContextFactory : IDbContextFactory<SimpleDataContext>
    {
        public SimpleDataContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<SimpleDataContext>();
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Company;Trusted_Connection=True;");
            return new SimpleDataContext(builder.Options);
        }
    }
}