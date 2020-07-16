using Models.DTOs;

namespace BusinessServices.Interfaces.Validators
{
    public interface IEmployeeValidator : ICommonValidator
    {
        bool ContractNotNull(object entity);
    }
}
