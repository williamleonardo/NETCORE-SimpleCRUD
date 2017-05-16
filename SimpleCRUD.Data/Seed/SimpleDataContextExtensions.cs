using CsvHelper;
using SimpleCRUD.Data.Entities;
using System.IO;
using System.Linq;
using System.Text;

namespace SimpleCRUD.Data.Seed
{
    public static class SimpleDataContextExtensions
    {
        private static string csvFolderPath = Path.Combine(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()), "SimpleCRUD.Data", "Seed", "Csv");
        private static string departmentCsvFile = "department.csv";
        private static string staffCsvFile = "staff.csv";

        public static void EnsureSeedData(this SimpleDataContext dbContext)
        {
            // Seed Master Table
            SeedDepartment(dbContext);
            SeedStaff(dbContext);
        }

        public static void SeedDepartment(SimpleDataContext context)
        {
            string csvPath = Path.Combine(csvFolderPath, departmentCsvFile);

            using (StreamReader reader = new StreamReader(File.OpenRead(csvPath), Encoding.UTF8))
            {
                CsvReader csvReader = new CsvReader(reader);
                csvReader.Configuration.WillThrowOnMissingField = false;
                csvReader.Configuration.HasHeaderRecord = true;
                csvReader.Configuration.RegisterClassMap<DepartmentClassMap>();
                var departments = csvReader.GetRecords<Department>().ToList();
                context.Departments.AddRange(departments);

                context.SaveChanges();
            }
        }

        public static void SeedStaff(SimpleDataContext context)
        {
            string csvPath = Path.Combine(csvFolderPath, staffCsvFile);

            using (StreamReader reader = new StreamReader(File.OpenRead(csvPath), Encoding.UTF8))
            {
                CsvReader csvReader = new CsvReader(reader);
                csvReader.Configuration.WillThrowOnMissingField = false;
                csvReader.Configuration.HasHeaderRecord = true;
                csvReader.Configuration.RegisterClassMap<StaffClassMap>();
                var staffs = csvReader.GetRecords<Staff>().ToList();
                context.Staffs.AddRange(staffs);

                context.SaveChanges();
            }
        }
    }
}
