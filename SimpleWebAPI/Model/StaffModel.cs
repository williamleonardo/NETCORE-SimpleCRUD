using System;

namespace SimpleWebAPI.Model
{
    public class StaffModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DepartmentModel Department { get; set; }

        public Guid DepartmentId { get; set; }
    }
}
