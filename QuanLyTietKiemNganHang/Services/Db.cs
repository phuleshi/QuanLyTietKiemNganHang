using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyTietKiemNganHang.Services
{
    internal static class Db
    {
        private const string ConnectionStringName = "QuanLyTietKiemDb";

        public static SqlConnection CreateConnection()
        {
            var settings = ConfigurationManager.ConnectionStrings[ConnectionStringName];
            var connectionString = settings != null ? settings.ConnectionString : string.Empty;
            return new SqlConnection(connectionString);
        }

        public static DataTable ExecuteDataTable(string queryOrProc, CommandType commandType, params SqlParameter[] parameters)
        {
            using (var connection = CreateConnection())
            using (var command = new SqlCommand(queryOrProc, connection))
            using (var adapter = new SqlDataAdapter(command))
            {
                command.CommandType = commandType;
                if (parameters != null && parameters.Length > 0)
                {
                    command.Parameters.AddRange(parameters);
                }

                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public static object ExecuteScalar(string queryOrProc, CommandType commandType, params SqlParameter[] parameters)
        {
            using (var connection = CreateConnection())
            using (var command = new SqlCommand(queryOrProc, connection))
            {
                command.CommandType = commandType;
                if (parameters != null && parameters.Length > 0)
                {
                    command.Parameters.AddRange(parameters);
                }

                connection.Open();
                return command.ExecuteScalar();
            }
        }

        public static int ExecuteNonQuery(string queryOrProc, CommandType commandType, params SqlParameter[] parameters)
        {
            using (var connection = CreateConnection())
            using (var command = new SqlCommand(queryOrProc, connection))
            {
                command.CommandType = commandType;
                if (parameters != null && parameters.Length > 0)
                {
                    command.Parameters.AddRange(parameters);
                }

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }
}
