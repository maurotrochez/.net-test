using DataAccess.Interfaces;
using Microsoft.Extensions.Configuration;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class EmployeeRepository : Repository<EmployeeDTO>, IEmployeeRepository
    {
        public EmployeeRepository(IConfiguration config) : base(config)
        {
        }

        public async Task<List<EmployeeDTO>> GetAllEmployees()
        {
            return await GetAllAsync();
        }

        public async Task<EmployeeDTO> GetEmployeeById(int id)
        {
            return await GetByIdAsync(id);
        }
    }
}
