using System;
using System.IO;
using SQLite;


namespace DomainServices.Database
{
    public class DatabaseManager 
    {

        public const string APPLICATION_DATABASE_NAME = "MySpectrum.db";
        //private constructor requiring parameterized construction.
        private DatabaseManager() { }


        string _databaseFileLocation;
        string _databaseFullPath;
        SQLiteConnection _connection;

        /// <summary>
        /// The Location of the Database File on the Device.
        /// </summary>
        /// <value>The database file location.</value>
        public string DatabaseFileLocation { get => _databaseFileLocation; private set => _databaseFileLocation = value; }

        /// <summary>
        /// The full path of the Database
        /// </summary>
        /// <value>The database full path.</value>
        public string DatabaseFullPath { get => _databaseFullPath; private set => _databaseFullPath = value; }


        /// <summary>
        /// The Current Connection Object for the operation repository.
        /// </summary>
        /// <value>The connection.</value>
        public SQLiteConnection Connection { get => _connection; private set => _connection = value; }




        /// <summary>
        /// Required Constructor
        /// </summary>
        /// <param name="databaseFileLocation">Database file location.</param>
        public DatabaseManager(string databaseFileLocation)
        {

            _databaseFullPath = Path.Combine(databaseFileLocation, APPLICATION_DATABASE_NAME);
            _databaseFileLocation = databaseFileLocation;

            CreateConnection();


        }
        /// <summary>
        /// Creates the connection to the database. If the database does not exist with this call,it creates it.
        /// </summary>
        private void CreateConnection()
        {
            _connection = new SQLiteConnection(_databaseFullPath);

        }

        /// <summary>
        /// Closes and Disposes of the Current Connection
        /// </summary>
        public void CloseConnection()
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }
    }
}
