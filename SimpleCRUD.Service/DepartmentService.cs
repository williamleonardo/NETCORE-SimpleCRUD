using SimpleCRUD.Data.Entities;
using SimpleCRUD.Data.Repositories.Interfaces;
using SimpleCRUD.Service.Interface;
using System;
using System.Collections.Generic;

namespace SimpleCRUD.Service
{
    public class DepartmentService : IDepartmentService
    {
        private IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public void Add(Department department)
        {
            _departmentRepository.Insert(department);
        }

        public void Delete(Guid id)
        {
            Department department = _departmentRepository.Get(id);
            _departmentRepository.Delete(department);
        }

        public IEnumerable<Department> GetAll()
        {
            return _departmentRepository.GetAll();
        }

        public Department GetById(Guid id)
        {
            return _departmentRepository.Get(id);
        }

        public void Update(Department department)
        {
            _departmentRepository.Update(department);
        }
    }
}
