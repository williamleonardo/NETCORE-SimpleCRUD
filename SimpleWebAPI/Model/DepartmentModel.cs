using System;
using System.Collections.Generic;

namespace SimpleWebAPI.Model
{
    public class DepartmentModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<StaffModel> Staffs { get; set; }
    }
}
