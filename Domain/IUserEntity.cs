using Domain.ValueObjects;

namespace Domain
{
    public interface IUserEntity
    {
        FirstName FirstName { get; }
        LastName LastName { get; }
        Password Password { get; }
    }
}