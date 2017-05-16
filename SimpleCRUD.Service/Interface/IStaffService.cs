using SimpleCRUD.Data.Entities;
using System;
using System.Collections.Generic;

namespace SimpleCRUD.Service.Interface
{
    public interface IStaffService
    {
        void Add(Staff staff);

        void Update(Staff staff);

        void Delete(Staff staff);

        Staff GetById(Guid id);

        IEnumerable<Staff> GetAll();        
    }
}

