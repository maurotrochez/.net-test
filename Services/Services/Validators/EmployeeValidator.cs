using BusinessServices.Interfaces.Validators;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.Services.Validators
{
    public class EmployeeValidator : IEmployeeValidator
    {
        public bool ContractNotNull(object entity)
        {
            if (entity == null)
            {
                throw new Exception("Contract type not found");
            }
            return true;
        }

        public bool EntityNotNull(object entity)
        {
            if (entity == null)
            {
                throw new Exception("Employe not found");
            }
            return true;
        }

        public bool IdGreaterThanZero(int id)
        {
            if (id == 0)
            {
                throw new Exception("Employee id must be greater than 0");
            }
            return true;
        }
    }
}
