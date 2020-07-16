using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessServices.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
    }
}
