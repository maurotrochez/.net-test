using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public abstract class EmployeeFactory
    {
        public abstract Employee GetEmployee(EmployeeDTO employee);
    }
}
