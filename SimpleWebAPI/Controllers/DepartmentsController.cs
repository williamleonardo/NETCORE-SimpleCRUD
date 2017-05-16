using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleCRUD.Data.Entities;
using SimpleCRUD.Service.Interface;
using SimpleWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class DepartmentsController : Controller
    {
        private IMapper _mapper;

        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService service, IMapper mapper)
        {
            _mapper = mapper;
            _departmentService = service;
        }
        
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return _departmentService.GetAll();
        }
        
        [Route("getbyid/{id}")]
        [HttpGet]
        public IActionResult GetById(string id)
        {
            Guid departmentId = Guid.Parse(id);
            var department = _departmentService.GetById(departmentId);

            if (department == null) return NotFound();

            return new ObjectResult(_mapper.Map<Department, DepartmentModel>(department));
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] DepartmentModel department)
        {
            if (department == null) return BadRequest();

            department.Id = Guid.NewGuid();
            _departmentService.Add(_mapper.Map<DepartmentModel, Department>(department));

            return new NoContentResult();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(string id)
        {
            Guid departmentId = Guid.Parse(id);
            var department = _departmentService.GetById(departmentId);
            if (department == null)
            {
                return NotFound();
            }

            _departmentService.Delete(departmentId);
            return new NoContentResult();
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] DepartmentModel department)
        {
            if (department == null)
                return BadRequest();

            _departmentService.Update(_mapper.Map<DepartmentModel, Department>(department));

            return new ObjectResult(_mapper.Map<DepartmentModel, Department>(department));
        }
    }
}
