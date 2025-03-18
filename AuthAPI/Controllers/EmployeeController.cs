using AuthAPI.Data;
using AuthAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
   
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var employees = _context.Employees.ToList();
                if (employees.Count == 0)
                {
                    return NotFound("Employee Not available");
                }
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id) {

            try
            {
                var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
                if (employee == null)
                {
                    return NotFound("Employee Not available");
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post (Employee model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                return Ok("Employee added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Employee model)
        {
            if (model == null)
            {
                return BadRequest("Employee data is invalid");
            }
            if (model.Id == 0)
            {
                return BadRequest($"Employee Id {model.Id} is required");
            }

            try
            {
                var employee = _context.Employees.Find(model.Id);
                if (employee == null)
                {
                    return BadRequest($"Employee not found with Id {model.Id} ");
                }
                employee.Name = model.Name;
                employee.Department = model.Department;
                employee.Designation = model.Designation;
                _context.Update(employee);
                _context.SaveChanges();
                return Ok("Employee updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var employee = _context.Employees.Find(id);
                if (employee == null)
                {
                    return NotFound("Employee not found");
                }
                _context.Remove(employee);
                _context.SaveChanges();
                return Ok("Employee deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        }
}
