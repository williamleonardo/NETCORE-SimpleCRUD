using CsvHelper.Configuration;
using SimpleCRUD.Data.Entities;

namespace SimpleCRUD.Data.Seed
{
    public sealed class StaffClassMap : CsvClassMap<Staff>
    {
        public StaffClassMap()
        {
            Map(m => m.Id).Name("Id");
            Map(m => m.FirstName).Name("FirstName");
            Map(m => m.LastName).Name("LastName");
            Map(m => m.DepartmentId).Name("DepartmentId");
        }
    }
}
