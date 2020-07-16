using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public interface IEmployee
    {
        int Id { get; set; }
        string Name { get; set; }
        string ContractTypeName { get; set; }
        int RoleId { get; set; }
        string RoleName { get; set; }
        string Description { get; set; }
        decimal HourlySalary { get; set; }
        decimal MonthlySalary { get; set; }
    }
}
