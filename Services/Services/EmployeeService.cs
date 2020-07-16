using DataAccess.Interfaces;
using BusinessServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using System.Linq;
using BusinessServices.Interfaces.Validators;

namespace BusinessServices.Repositories
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeValidator _employeeValidator;

        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeValidator employeeValidator)
        {
            _employeeRepository = employeeRepository;
            _employeeValidator = employeeValidator;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            try
            {
                EmployeeFactory factory = new ConcreteEmployeeFactory();
                List<Employee> employees = new List<Employee>();

                //Get all employees
                var dtos = await _employeeRepository.GetAllEmployees();
                foreach (var item in dtos)
                {
                    //Crete concrete employee type
                    employees.Add(factory.GetEmployee(item));
                }
                return employees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            try
            {
                EmployeeFactory factory = new ConcreteEmployeeFactory();
                Employee employee = null;

                //Get all employees
                var dtos = await _employeeRepository.GetAllEmployees();

                //Validate employee exists
                _employeeValidator.EntityNotNull(dtos.FirstOrDefault(x => x.Id == id));

                //Create concrete employee type
                employee = factory.GetEmployee(dtos.FirstOrDefault(x => x.Id == id));

                //Validate contract type exits
                _employeeValidator.ContractNotNull(employee);

                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
