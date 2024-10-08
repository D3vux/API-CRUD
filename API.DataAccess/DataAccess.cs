using API.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataAccess
{
    public interface IDataAccess
    {
        DataTable SelectStoredProcedure(string name, string query, List<SqlParameter> parameters);
        bool ExecuteStoredProcedure(string name, string query, List<SqlParameter> parameters);
    }
    public class DataAccess : IDataAccess
    {
        private SettingsDataAccess _dataAccess;

        public DataAccess(SettingsDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        private string connectionString(SettingsConnection dataBase)
        {
            return @"Persist Security Info=True;User ID=" + dataBase.user + ";Pwd=" + dataBase.pass + ";Server=" + dataBase.server + ";DataBase=" + dataBase.database + ";Application Name=" + dataBase.name;
        }

        #region SqlServer
        public DataTable SelectStoredProcedure(string name, string query, List<SqlParameter> parameters)
        {
            DataTable result = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString(_dataAccess.connections.Find(x => x.name == name)));
            try
            {
                SqlConnection.ClearAllPools();
                SqlDataAdapter command = new SqlDataAdapter(query, connection);
                command.SelectCommand.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        if (item.Value == null)
                            item.Value = DBNull.Value;
                        command.SelectCommand.Parameters.Add(item);
                    }
                }

                connection.Open();
                command.Fill(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearAllPools();
            }
            return result;
        }
        public bool ExecuteStoredProcedure(string name, string query, List<SqlParameter> parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString(_dataAccess.connections.Find(x => x.name == name)));
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        if (item.Value == null)
                            item.Value = DBNull.Value;
                        command.Parameters.Add(item);
                    }
                }

                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearAllPools();
            }
        }
        #endregion

    }
}
