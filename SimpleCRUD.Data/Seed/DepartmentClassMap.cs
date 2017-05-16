using CsvHelper.Configuration;
using SimpleCRUD.Data.Entities;

namespace SimpleCRUD.Data.Seed
{
    public sealed class DepartmentClassMap : CsvClassMap<Department>
    {
        public DepartmentClassMap()
        {
            Map(m => m.Id).Name("Id");
            Map(m => m.Name).Name("Name");
        }
    }
}
