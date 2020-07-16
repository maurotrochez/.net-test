namespace Models
{
    public class EmployeeMonthly : Employee
    {

        public override decimal AnnualSalary => MonthlySalary * 12;

    }
}
