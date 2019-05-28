using System;
using Domain;
using Domain.ValueObjects;
using Xunit;

namespace DomainTests
{
    public class UserEntityTests
    {
        [Fact]
        public void ValueObjectCreationValidation()
        {

            string stringResult = CreateUserEntity();

            Assert.Same(string.Empty, stringResult);

        }


        [Fact]
        public void PasswordValidTest()
        {
            bool resultValue = true;

            try
            {
                //if the value is invalid, it will faile
                Password pw = new Password("Thisi1");

            } catch
            {
                resultValue = false;
            }

            Assert.True(resultValue);

        }

        /// <summary>
        /// Conducts a test against each of the value objects that are used to 
        /// make up the User Entity. Each Value Object has it own validation during creation to 
        /// insure proper format of the values for the instance,
        /// 
        /// For example: FirstName ValueObject should allow AlphaNumeric characters but reject special characters such as #
        /// 
        /// If the Value object validation fails, an error is raised on the Value Object that is being created.
        /// 
        /// If an Empty string is not returned, the test has failed.
        /// </summary>
        /// <returns>The user entity.</returns>
        string CreateUserEntity()
        {
            string returnValue = string.Empty;
            try
            {
                //validate that FirstName works
                returnValue = "FirstName";
                FirstName fn = new FirstName("Edward");

                //validate that LastName works
                returnValue = "LastName";
                LastName ln = new LastName("Rush");

                //validate that Password works
                returnValue = "Password";
                Password pw = new Password("ThisThis");

                //create the entity
                IUserEntity userEntity = new UserEntity(fn, ln, pw);


                //set our string to emtpy here, if any test above fails then the return value will be the
                //last test conducted.
                returnValue = string.Empty;

            }
            catch
            {
                //catch our error but do nothing with it.
            }

            return returnValue;

        }


    }
}
