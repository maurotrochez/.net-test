using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public decimal HourlySalary { get; set; }
        public decimal MonthlySalary { get; set; }
    }
}
