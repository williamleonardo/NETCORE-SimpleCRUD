using SimpleCRUD.Data.Entities;
using SimpleCRUD.Data.Repositories.Interfaces;
using SimpleCRUD.Service.Interface;
using System;
using System.Collections.Generic;

namespace SimpleCRUD.Service
{
    public class StaffService : IStaffService
    {
        private IStaffRepository _staffRepository;
        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }
        public void Add(Staff staff)
        {
            _staffRepository.Insert(staff);
        }

        public void Delete(Staff staff)
        {
            _staffRepository.Delete(staff);
        }

        public IEnumerable<Staff> GetAll()
        {
            return _staffRepository.GetAll();
        }

        public Staff GetById(Guid id)
        {
            return _staffRepository.Get(id);
        }

        public void Update(Staff staff)
        {
            _staffRepository.Update(staff);
        }
    }
}
