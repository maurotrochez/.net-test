using Models.DTOs;

namespace Models
{
    public class ConcreteEmployeeFactory : EmployeeFactory
    {
        public override Employee GetEmployee(EmployeeDTO employee)
        {
            switch (employee.ContractTypeName)
            {
                case "HourlySalaryEmployee":
                    {
                        return new EmployeeHourly
                        {
                            Id = employee.Id,
                            Name = employee.Name,
                            ContractTypeName = employee.ContractTypeName,
                            RoleId = employee.RoleId,
                            RoleName = employee.RoleName,
                            Description = employee.Description,
                            HourlySalary = employee.HourlySalary,
                            MonthlySalary = employee.MonthlySalary
                        };
                    }
                case "MonthlySalaryEmployee":
                    {

                        return new EmployeeMonthly
                        {
                            Id = employee.Id,
                            Name = employee.Name,
                            ContractTypeName = employee.ContractTypeName,
                            RoleId = employee.RoleId,
                            RoleName = employee.RoleName,
                            Description = employee.Description,
                            HourlySalary = employee.HourlySalary,
                            MonthlySalary = employee.MonthlySalary
                        };
                    }
                default:
                    return null;
            }
        }
    }
}
