using SimpleCRUD.Data.Entities;
using System;
using System.Collections.Generic;

namespace SimpleCRUD.Service.Interface
{
    public interface IDepartmentService
    {
        void Add(Department department);

        void Update(Department department);

        void Delete(Guid id);

        Department GetById(Guid id);

        IEnumerable<Department> GetAll();
    }
}

