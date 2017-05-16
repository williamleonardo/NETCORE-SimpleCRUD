using Microsoft.EntityFrameworkCore;
using SimpleCRUD.Data.Entities;
using SimpleCRUD.Data.Seed;

namespace SimpleCRUD.Data
{
    public class SimpleDataContext : DbContext
    {
        public SimpleDataContext(DbContextOptions<SimpleDataContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Department>()
                .HasMany(i => i.Staffs)
                .WithOne(i => i.Department)
                .HasForeignKey(i => i.DepartmentId);
        }

        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}