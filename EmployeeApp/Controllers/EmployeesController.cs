using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTOs;

namespace EmployeeApp.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ApiControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        // GET api/values
        [HttpGet("", Name ="GetAllEmployees")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _employeeService.GetAllEmployees();
                return HandleSuccessResponse(response);
            }
            catch (Exception ex)
            {
                return HandleErrorResponse(ex);
            }
            
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetEmployeeById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var response = await _employeeService.GetEmployeeById(id);
                return HandleSuccessResponse(response);
            }
            catch (Exception ex)
            {
                return HandleErrorResponse(ex);
            }
        
        }

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
