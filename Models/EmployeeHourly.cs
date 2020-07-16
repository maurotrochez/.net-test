namespace Models
{
    public class EmployeeHourly : Employee
    {

        public override decimal AnnualSalary => 120 * HourlySalary * 12;

    }
}
