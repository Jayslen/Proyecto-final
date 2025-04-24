using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaDatos
{
    internal class DBConnections
    {
        private static readonly DBConnections _instance = new DBConnections();
        private SqlConnection _connection;
        private readonly string _connectionString = "Server=JAYSLEN\\MSSQLSERVER01;Database=reservations;Trusted_Connection=True;";
        private DBConnections()
        {
            _connection = new SqlConnection(_connectionString);
        }

        public static DBConnections Instance
        {
            get { return _instance; }
        }

        public SqlConnection Connection
        {
            get
            {
                if (_connection.State == System.Data.ConnectionState.Closed ||
                    _connection.State == System.Data.ConnectionState.Broken)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }

        // Optional: Close the connection
        public void CloseConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}
