using Microsoft.EntityFrameworkCore;
using SimpleCRUD.Data.Entities;
using SimpleCRUD.Data.Infrastructure;
using SimpleCRUD.Data.Repositories.Interfaces;
using System.Collections.Generic;

namespace SimpleCRUD.Data.Repositories
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        private SimpleDataContext _context;

        public DepartmentRepository(SimpleDataContext context)
            : base(context)
        {
            _context = context;
        }

        public override IEnumerable<Department> GetAll()
        {
            return _context.Departments
                .Include(x => x.Staffs);
        }
    }
}