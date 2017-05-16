using Microsoft.EntityFrameworkCore;
using SimpleCRUD.Data.Entities;
using SimpleCRUD.Data.Infrastructure;
using SimpleCRUD.Data.Repositories.Interfaces;
using System.Collections.Generic;

namespace SimpleCRUD.Data.Repositories
{
    public class StaffRepository : RepositoryBase<Staff>, IStaffRepository
    {
        private SimpleDataContext _context;

        public StaffRepository(SimpleDataContext context)
            : base(context)
        {
            _context = context;
        }

        public override IEnumerable<Staff> GetAll()
        {
            return _context.Staffs
                .Include(x => x.Department);
        }
    }
}