using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
//using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using DM.Model;
using DM.Repository.Extensions;
using DM.Repository.Interfaces;

namespace DM.Repository.Implementation
{


    public class DbHelper : IDbHelper
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        private string GetConnectionString(string database)
        {
            var connectionString = Environment.GetEnvironmentVariable("ZipeCodeAPIDatabase");
            if (!string.IsNullOrEmpty(connectionString)) return connectionString;
            else return "Data Source=duplothmcorp.database.windows.net;Initial Catalog=apa;;User Id=thmcorp; Password=hvsujB3a3uKs01!;Persist Security Info=False;MultipleActiveResultSets=True;";
            throw new Exception("ConnectionString for not found");
        }

        public string GetConnectionString(DatabaseEnum db)
        {
            string connString = String.Empty;
            switch (db)
            {
                case DatabaseEnum.ThmDB:
                    connString = GetConnectionString("ZipeCodeAPIDatabase");
                    break;
                default:
                    throw new ArgumentException("No connection string for this database");
            }
            return connString;
        }

        private const string PROVIDER_NAME = "System.Data.SqlClient";

        public DatabaseEnum DatabaseThmDB
        {
            get
            {
                return DatabaseEnum.ThmDB;
            }
        }

        public IDbConnection GetDbConnection(DatabaseEnum database)
        {

            //DbProviderFactory factory = DbProviderFactories.GetFactory(PROVIDER_NAME);
            //DbConnection connection = factory.CreateConnection();
            //connection.ConnectionString = GetConnectionString(database);
            return new SqlConnection(GetConnectionString(database));
        }

        public IDbConnection GetDbConnection()
        {
            return GetDbConnection(DatabaseEnum.ThmDB);
        }

        private SqlConnection GetConnection(DatabaseEnum database)
        {
            return new SqlConnection(GetConnectionString(database));
        }

        public IDbCommand GetDbCommand(DatabaseEnum database)
        {
            return GetDbConnection(database).CreateCommand();
        }

        //public DbDataAdapter GetDbDataAdapter(Database database)
        //{
        //    DbProviderFactory factory = DbProviderFactories.GetFactory(PROVIDER_NAME);
        //    return factory.CreateDataAdapter();
        //}

        //public DbCommandBuilder GetDbCommandBuilder(Database database)
        //{
        //    DbProviderFactory factory = DbProviderFactories.GetFactory(PROVIDER_NAME);
        //    return factory.CreateCommandBuilder();
        //}

        public CommandType GetCommandTypeForSqlString(string sqlString)
        {
            string sqlUpper = sqlString.ToUpper();

            if (sqlUpper.StartsWith("SELECT") ||
                sqlUpper.StartsWith("UPDATE") ||
                sqlUpper.StartsWith("INSERT") ||
                sqlUpper.StartsWith("DELETE") ||
                sqlUpper.StartsWith("EXEC ") ||
                sqlUpper.StartsWith("IF EXISTS") ||
                sqlUpper.StartsWith("IF NOT EXISTS") ||
                sqlUpper.StartsWith("WITH") ||
                sqlUpper.StartsWith("SET "))
            {
                return CommandType.Text;
            }
            else
            {
                return CommandType.StoredProcedure;
            }

        }

        public void ExecuteNonQuery(DatabaseEnum database, string sqlString, int timeout, params DbParameter[] parameters)
        {
            using (IDbConnection oSqlConnection = GetDbConnection(database))
            {
                oSqlConnection.Open();

                DbCommandWithTrace oSqlCommand = new DbCommandWithTrace(sqlString, oSqlConnection);
                oSqlCommand.CommandType = GetCommandTypeForSqlString(sqlString);
                oSqlCommand.CommandTimeout = timeout;

                foreach (DbParameter parameter in parameters)
                {
                    oSqlCommand.Parameters.Add(parameter);
                }

                oSqlCommand.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// This will execute the specified query on a background thread - i.e. caller does not need to wait for it to finish
        /// </summary>
        /// <param name="db"></param>
        /// <param name="sqlString"></param>
        /// <param name="timeout"></param>
        /// <param name="parameters"></param>
        /// <remarks></remarks>
        //public void ExecuteNonQueryAndForget(Database db, string sqlString, int timeout, params DbParameter[] parameters)
        //{
        //    ExecuteNonQueryAndForgetWrapper taskParams = new ExecuteNonQueryAndForgetWrapper()
        //    {
        //        Db = db,
        //        SqlString = sqlString,
        //        Timeout = timeout,
        //        Parameters = parameters,
        //        Context = HttpContext.Current
        //    };

        //    ThreadPool.QueueUserWorkItem(new WaitCallback(ExecuteNonQueryAndForgetCallback), taskParams);
        //}

        //private class ExecuteNonQueryAndForgetWrapper
        //{
        //    public Database Db { get; set; }
        //    public String SqlString { get; set; }
        //    public int Timeout { get; set; }
        //    public DbParameter[] Parameters { get; set; }
        //    public HttpContext Context { get; set; }
        //}

        //private void ExecuteNonQueryAndForgetCallback(object stateInfo)
        //{
        //    ExecuteNonQueryAndForgetWrapper wrapper = stateInfo as ExecuteNonQueryAndForgetWrapper;

        //    if (HttpContext.Current == null && wrapper.Context != null)
        //    {
        //        HttpContext.Current = wrapper.Context;
        //    }

        //    try
        //    {
        //        ExecuteNonQuery(wrapper.Db, wrapper.SqlString, wrapper.Timeout, wrapper.Parameters);
        //    }
        //    catch (Exception)
        //    {
        //        // ignore
        //    }
        //}

        public DbParameter CreateParameter(string name, object value)
        {
            if (value == null)
            {
                return new SqlParameter(name, DBNull.Value);
            }
            else
            {
                return new SqlParameter(name, value);
            }
        }

        public Result<SpTransactionMessage> ExecuteQuery(string sqlQuery, object paramterValues, CommandType commandType)
        {
            return GetConnection(DatabaseThmDB).ExecuteQuery(sqlQuery, paramterValues, commandType);
        }

        public async Task<Result<SpTransactionMessage>> ExecuteQueryAsync(string sqlQuery, object paramterValues, CommandType commandType)
        {
            return await GetConnection(DatabaseThmDB).ExecuteQueryAsync(sqlQuery, paramterValues, commandType);
        }
    }
}
