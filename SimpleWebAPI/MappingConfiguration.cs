using AutoMapper;
using SimpleCRUD.Data.Entities;
using SimpleWebAPI.Model;

namespace SimpleWebAPI
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<Staff, StaffModel>().PreserveReferences();
            CreateMap<StaffModel, Staff>();

            CreateMap<Department, DepartmentModel>().PreserveReferences();
            CreateMap<DepartmentModel, Department>();
        }
    }
}
