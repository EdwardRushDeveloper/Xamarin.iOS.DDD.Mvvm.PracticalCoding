using System;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public class Password : ValueObjectBase<string>
    {
        /* Requirement per document
            The following are the string validations:
            1. String must consist of a mixture of letters and numerical digits only, with at least one of each.
            2. String must be between 5 and 12 characters in length.
            3. String must not contain any sequence of characters immediately followed by the same sequence
        */

        //private static string _passwordExpression = "^(?=.*[a-zA-Z0-9])(?!.*(.)\\1).{5,12}$";
        //private static string _passwordExpression = "^(?!.*([A-Za-z0-9])\\1{2})(?=.*[a-z])(?=.*\\d)[A-Za-z0-9]+$";

        //private static string _passwordExpression = "^(?=.{5,12})(?!.*(.)\\1).*$";
        private static string _passwordExpression = "^(?=.{5,12})(?!.*[!@#$%^&*()+{}|~`<>,.?\\\\])(?=.*[a-z])(?!.*(.)\\1)(?=.*\\d)(?!.*(.)\\1)(?=.*[A-Z])(?!.*(.)\\1).*$";
        /// <summary>
        /// Gets the password expression.
        /// </summary>
        /// <value>The password expression.</value>
        public static string PasswordExpression
        {
            get
            {
                return _passwordExpression;
            }
        }

        /// <summary>
        /// The Password Constructor used to validate the Password entry. If the Password is not valid an error is raised.
        /// </summary>
        /// <param name="value">Value.</param>
        public Password(string value)
        {

            var result = Regex.Match(value, PasswordExpression);
            if (!result.Success)
            {
                throw new Exception("Invalid Password was Entered. No repeating characters, must be 5 - 12 characters, upper and lower case characters and one number.");
            }

            _value = value;
        }
    }
}
