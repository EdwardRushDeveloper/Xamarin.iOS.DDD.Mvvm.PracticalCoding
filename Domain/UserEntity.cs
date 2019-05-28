using System;
using Domain.ValueObjects;
using Newtonsoft.Json;

namespace Domain
{
    /// <summary>
    /// User Entity Class Used for User Validation
    /// </summary>
    public class UserEntity : IUserEntity
    {
        /// <summary>
        /// JSON Constructor used for Deserialization
        /// </summary>
        /// <param name="firstName">First name.</param>
        /// <param name="lastName">Last name.</param>
        /// <param name="password">Password.</param>
        [JsonConstructor()]
        public UserEntity(
             FirstName firstName
            , LastName lastName
            , Password password)
        {

            _firstName = firstName;
            _lastName = lastName;
            _password = password;

        }

        private FirstName _firstName = null;
        private LastName _lastName = null;
        private Password _password = null;


        /// <summary>
        /// First Name Value Object
        /// </summary>
        /// <value>The first name.</value>
        public FirstName FirstName { get { return _firstName; } private set { _firstName = value; } }


        /// <summary>
        /// Last Name Value Object
        /// </summary>
        /// <value>The last name.</value>
        public LastName LastName { get { return _lastName; } private set { _lastName = value; } }


        /// <summary>
        /// Password Value Object
        /// </summary>
        /// <value>The password.</value>
        public Password Password { get { return _password; } private set { _password = value; } }

    }
}
