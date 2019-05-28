using System;
using Domain.DatabaseModelInterface;
using SQLite;

namespace DomainServices.DatabaseModel
{
    public class User : IUser
    {
        public User()
        {
        }


       [PrimaryKey, AutoIncrement]
       public int Id { get; set; }

         
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public string Password { get; set; }

    }
}
