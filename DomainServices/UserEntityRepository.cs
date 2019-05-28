using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.DatabaseModelInterface;
using Domain.ValueObjects;
using DomainServices.DatabaseModel;

namespace DomainServices
{
    public class UserEntityRepository
    {
        private const string TABLE_VALIDATE_SQL = "SELECT name FROM sqlite_master WHERE type='table' AND name='User';";
        string _databaseFileLocation;

        private UserEntityRepository(){}

        /// <summary>
        /// Initializes an instance of the current UserEntityRepository
        /// </summary>
        /// <param name="databaseFileLocation">Database file location.</param>
        public UserEntityRepository(string databaseFileLocation)
        {
            _databaseFileLocation = databaseFileLocation;


            RegisterTable();


        }

        /// <summary>
        /// Registers the UserEntity Table with the Current Database.
        /// </summary>
        private void RegisterTable()
        {
            Database.DatabaseManager db = null;
            try
            {


                db = new Database.DatabaseManager(_databaseFileLocation);
                var result = db.Connection.ExecuteScalar<string>(TABLE_VALIDATE_SQL);

                if(result == null)
                {
                    db.Connection.CreateTable<User>();
                    GenerateTestData();

                }

            }
            finally
            {
                db.CloseConnection();
            }

     
        }

        /// <summary>
        /// Generates the test data.
        /// </summary>
        private void GenerateTestData()
        {
            List<IUserEntity> saveList = new List<IUserEntity>();
            IUserEntity current = CreateUser("Edward", "Rush", "123PWd");
            saveList.Add(current);
            current = CreateUser("Eric", "Evans", "456PWd");
            saveList.Add(current);
            current = CreateUser("Martin", "Fowler", "789PWd");
            saveList.Add(current);
            current = CreateUser("James", "Montemagno", "1012PWd");
            saveList.Add(current);
            current = CreateUser("Frank", "Krueger", "1213PWd");
            saveList.Add(current);
            current = CreateUser("Nat", "Friedman", "1415PWs");
            saveList.Add(current);
            current = CreateUser("Miguel", "Icaza", "1617PWd");
            saveList.Add(current);

            SaveUsers(saveList);
        }


        private IUserEntity CreateUser(string fn, string ln, string pwd)
        {
            FirstName firstName = new FirstName(fn);
            LastName lastName = new LastName(ln);
            Password password = new Password(pwd);

            IUserEntity returnValue = new UserEntity(firstName, lastName, password);

            return returnValue;
        }

        /// <summary>
        /// Gets all Current Users from our Repository
        /// </summary>
        /// <returns>The all users.</returns>
        public List<IUser> GetAllUsers()
        {
            List<IUser> returnValue = new List<IUser>();

            Database.DatabaseManager db = null;
            try
            {

                db = new Database.DatabaseManager(_databaseFileLocation);
                var result = db.Connection.Table<User>();

                if (result != null)
                {
                    foreach (var user in result)
                    {
                        returnValue.Add(user);
                    }

                }

            }
            finally
            {
                db.CloseConnection();
            }

            return returnValue;

        }
        /// <summary>
        /// Saves a User to the Repository
        /// </summary>
        /// <param name="users">User Collection to save</param>
        public void SaveUsers(List<IUserEntity> users)
        {
            Database.DatabaseManager db = null;
            try
            {


                db = new Database.DatabaseManager(_databaseFileLocation);
                db.Connection.BeginTransaction();

                foreach (var current in users)
                {
                    User insertUser = new User();
                    insertUser.FirstName = current.FirstName.Value;
                    insertUser.LastName = current.LastName.Value;
                    insertUser.Password = current.Password.Value;

                    db.Connection.Insert(insertUser);

                }

                db.Connection.Commit();
            }
            catch
            {
                db.Connection.Rollback();
            }
            finally
            {
                db.CloseConnection();
            }


        }

        /// <summary>
        /// Adds a new user to the database
        /// </summary>
        /// <param name="user">IUserEntity containing the validated ValueObjects.</param>
        public bool AddUser(IUserEntity user)
        {
            bool returnValue = true;

            Database.DatabaseManager db = null;
            try
            {


                db = new Database.DatabaseManager(_databaseFileLocation);

                db.Connection.BeginTransaction();


                    User insertUser = new User();
                    insertUser.FirstName = user.FirstName.Value;
                    insertUser.LastName = user.LastName.Value;
                    insertUser.Password = user.Password.Value;

                    db.Connection.Insert(insertUser);

                    


                db.Connection.Commit();
            }
            catch
            {
                db.Connection.Rollback();
                returnValue = false;
            }
            finally
            {
                db.CloseConnection();
            }

            return returnValue;

        }

    }
}
