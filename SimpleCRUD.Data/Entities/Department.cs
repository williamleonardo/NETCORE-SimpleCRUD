using SimpleCRUD.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleCRUD.Data.Entities
{
    public class Department : EntityBase
    {
        public Department()
        {
            Staffs = new List<Staff>();
        }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Staff> Staffs { get; set; }
    }
}
