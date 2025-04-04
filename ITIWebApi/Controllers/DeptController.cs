using AutoMapper;
using ITIWebApi.DTO;
using ITIWebApi.Filters;
using ITIWebApi.IRepo;
using ITIWebApi.Models;
using ITIWebApi.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ITIWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DeptController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;
        private readonly IRepo<Departmment> _deptRepo;
        public DeptController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _deptRepo = _unitOfWork.Repos<Departmment>();
            this.mapper=mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(mapper.Map<List<DepartmentDto>>(_deptRepo.GetAll(p=>p.Students)));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var a = _deptRepo.GetById(id,p=>p.Students);
            if(a==null)
                return NotFound();
            return Ok(mapper.Map<DepartmentDto>(a));
        }


        [HttpPost("{id}")]
        public void Post(int id,[FromBody] DepartmentDto departmentDto)
        {
            //mapper.Map<Departmment>(departmentDto)
            Departmment d = _deptRepo.GetById(id);
            d.Location = departmentDto.Location;
            d.Name = departmentDto.Name;
            _deptRepo.Update(d);
            _unitOfWork.SaveAsync();
        }

        [HttpPut]
        public void Put([FromBody] DepartmentDto departmentDto)
        {
            Departmment d = mapper.Map<Departmment>(departmentDto);
            d.Location = "Egypt";
            _deptRepo.Add(d);
            _unitOfWork.SaveAsync();
        }
        [HttpPut("Put2")]
        [LocationFilter]
        public void Put2([FromBody] DepartmentDto departmentDto)
        {
            Departmment d = mapper.Map<Departmment>(departmentDto);
            _deptRepo.Add(d);
            _unitOfWork.SaveAsync();
        }

        // DELETE api/<DeptController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _deptRepo.Delete(id);
            _unitOfWork.SaveAsync();
        }
    }
}
