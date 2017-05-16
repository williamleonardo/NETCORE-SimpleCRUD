using SimpleCRUD.Data.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleCRUD.Data.Entities
{
    public class Staff : EntityBase
    {
        public Staff()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Department Department { get; set; }

        [ForeignKey("Department")]
        public Guid DepartmentId { get; set; }
    }
}
