using System;
namespace Domain.DatabaseModelInterface
{
    /// <summary>
    /// We will use the IUser Interface to create a database model at the DomainService Level
    /// We want to limit our Domain to only Interaces, Value Objects and Entities.
    /// </summary>
    public interface IUser
    {

        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Password { get; set; }

    }
}
