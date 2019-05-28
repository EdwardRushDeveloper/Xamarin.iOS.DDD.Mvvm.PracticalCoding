using System;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public class FirstName : ValueObjectBase<string>
    {
        //Note on Regular Expression for Names
        //https://regex101.com/r/ic0UPr/1

        //changed the below to match salesforce supplied regular expression

        //private static string _firstNameExpression = "^(?=.{1,40}$)[a-zA-Z]+(?:[-' ][a-zA-Z]+)*$";
        private static string _firstNameExpression = "^[a-zA-Z._ ^%$#!~@,\\''-]+$";

        /// <summary>
        /// The First Name Regular Expression used to validate the First Name Characters.
        /// </summary>
        /// <value>The first name expression.</value>
        public static string FirstNameExpression
        {
            get
            {
                return _firstNameExpression;
            }
        }

        /// <summary>
        /// Constructor to validate the First Name Characters. If the name submitted is not valid,and error is raised.
        /// </summary>
        /// <param name="value">Value.</param>
        public FirstName(string value)
        {

            var result = Regex.Match(value, FirstNameExpression);
            if (!result.Success)
            {
                throw new Exception("Invalid First Name Entered.");
            }

            _value = value;
        }
    }
}
