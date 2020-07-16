using Models.DTOs;

namespace BusinessServices.Interfaces.Validators
{
    public interface ICommonValidator
    {
        bool IdGreaterThanZero(int id);
        bool EntityNotNull(object entity);
    }
}
