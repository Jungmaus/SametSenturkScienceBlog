using SametSenturkScienceBlog.Model.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SametSenturkScienceBlog.Data
{
    public static class CRUD
    {
        private static SqlConnection _connection;
        private const string connString = @"Server=DESKTOP-CE1GVBQ\SQLEXPRESS;Database=SametSenturkScienceBlogDB;Trusted_Connection=True;";

        private static SqlConnection GetConn()
        {
            try
            {

                if (_connection == null)
                {
                    _connection = new SqlConnection(connString);
                }

                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();

                return _connection;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong. Exception Message => " + ex.ToString());
            }
        }

        public static OperationTypeEnum AddOrUpdateOrDelete(string query, params KeyValuePair<string, string>[] paramaters)
        {
            try
            {
                SqlCommand command = new SqlCommand(query, GetConn());
                command.CommandType = CommandType.Text;

                foreach (var paramater in paramaters)
                {
                    command.Parameters.AddWithValue(paramater.Key, paramater.Value);
                }

                int control = command.ExecuteNonQuery();

                if (control > 0)
                    return OperationTypeEnum.Success;

                return OperationTypeEnum.Failure;

            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong. Exception message => " + ex.ToString());
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }

        public static DataTable Get(string query, params KeyValuePair<string, string>[] paramaters)
        {
            try
            {
                SqlCommand command = new SqlCommand(query, GetConn());
                command.CommandType = CommandType.Text;

                foreach (var paramater in paramaters)
                {
                    command.Parameters.AddWithValue(paramater.Key, paramater.Value);
                }

                SqlDataReader reader = command.ExecuteReader();

                DataTable dataTable = new DataTable();
                dataTable.Load(command.ExecuteReader());

                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong. Exception message => " + ex.ToString());
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }
    }
}
