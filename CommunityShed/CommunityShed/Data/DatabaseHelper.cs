using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CommunityShed.Data
{
    public static class DatabaseHelper
    {
        private const string ConnectionStringName = "Database";

        public static DataTable Retrieve(string sql, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();

            using (var connection = new SqlConnection(GetConnectionString()))
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }

                    using (var dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dt);
                    }
                }
            }

            return dt;
        }

        public static void Execute(string sql, params SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }

                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public static int? Insert(string sql, params SqlParameter[] parameters)
        {
            // Append a query to the passed in insert query
            // to get the last inserted ID primary key value.
            sql += @"
                select cast(scope_identity() as int) as 'id';
            ";

            int? id = null;

            using (var connection = new SqlConnection(GetConnectionString()))
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }

                    command.Connection.Open();
                    id = (int?)command.ExecuteScalar();
                }
            }

            return id;
        }

        public static void Update(string sql, params SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }

                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public static SqlParameter GetNullableStringSqlParameter(string parameterName, string value)
        {
            return new SqlParameter(parameterName, string.IsNullOrEmpty(value) ? (object)DBNull.Value : value);
        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
        }


        public static void Execute(string sql, params SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }

                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}