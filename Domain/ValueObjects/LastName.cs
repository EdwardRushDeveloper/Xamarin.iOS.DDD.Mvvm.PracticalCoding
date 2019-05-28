using System;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public class LastName : ValueObjectBase<string>
    {
        //Note on Regular Expression for Names
        //https://regex101.com/r/ic0UPr/1
        //changed this to salesforce supplied expression
        //private static string _lastNameExpression = "^(?=.{1,40}$)[a-zA-Z]+(?:[-' ][a-zA-Z]+)*$";
        private static string _lastNameExpression = "^[a-zA-Z._ ^%$#!~@,\\''-]+$";

        /// <summary>
        /// The Last Name Regular Expression used to validate the Last Name Characters.
        /// </summary>
        /// <value>The last name expression.</value>
        public static string LastNameExpression
        {
            get
            {
                return _lastNameExpression;
            }
        }

        /// <summary>
        /// The Construtor used to Validate the Last Name. If the Last Name is invalid an error is raised.
        /// </summary>
        /// <param name="value">Value.</param>
        public LastName(string value)
        {

            var result = Regex.Match(value, LastNameExpression);
            if (!result.Success)
            {
                throw new Exception("Invalid Last Name Entered.");
            }

            _value = value;
        }
    }
}
