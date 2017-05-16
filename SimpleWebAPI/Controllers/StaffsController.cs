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
    public class StaffsController : Controller
    {
        private IMapper _mapper;

        private readonly IStaffService _staffService;

        //private IList<Staff> _staffs;

        public StaffsController(IStaffService service, IMapper mapper)
        {
            _mapper = mapper;
            _staffService = service;
        }
        
        [HttpGet]
        public IEnumerable<Staff> Get()
        {
            return _staffService.GetAll();
        }
        
        [Route("getbyid/{id}")]
        [HttpGet]
        public IActionResult GetById(string id)
        {
            Guid staffId = Guid.Parse(id);
            var staff = _staffService.GetById(staffId);
            //var staff = _staffs.SingleOrDefault(x => x.Id == staffId);

            if (staff == null) return NotFound();

            return new ObjectResult(_mapper.Map<Staff, StaffModel>(staff));
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] StaffModel staff)
        {
            if (staff == null) return BadRequest();

            staff.Id = Guid.NewGuid();
            _staffService.Add(_mapper.Map<StaffModel, Staff>(staff));

            return new NoContentResult();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(string id)
        {
            Guid staffId = Guid.Parse(id);
            var staff = _staffService.GetById(staffId);
            if (staff == null)
            {
                return NotFound();
            }

            _staffService.Delete(staff);
            return new NoContentResult();
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] StaffModel staff)
        {
            if (staff == null)
                return BadRequest();

            _staffService.Update(_mapper.Map<StaffModel, Staff>(staff));

            return new ObjectResult(_mapper.Map<StaffModel, Staff>(staff));
        }
    }
}
