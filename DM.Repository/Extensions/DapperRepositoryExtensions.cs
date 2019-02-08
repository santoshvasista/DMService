using Dapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DM.Model;
using DM.Model.BaseEntities;
using DM.Model.Entities;

namespace DM.Repository.Extensions
{
    public static class DapperRepositoryExtensions
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public static IEnumerable<T> GetList<T>(this IDbConnection connection, string sqlQuery, object parameterValues,
            CommandType commandType = CommandType.Text)
        {
            return connection.Query<T>(sqlQuery, parameterValues, commandType: commandType);
        }

        public static IEnumerable<dynamic> GetList(this IDbConnection connection, string sqlQuery,
            object parameterValues, CommandType commandType = CommandType.Text)
        {
            return connection.Query<dynamic>(sqlQuery, parameterValues, commandType: commandType);
        }

        private static T GetEntityExtension<T>(IDbConnection connection, object paramters, string selectQuery,
            CommandType commandType)
        {
            var entity = connection.Query<T, dynamic, T>(selectQuery, (e, dyna) =>
            {
                var entityExtension = e as EntityExtension;
                if (entityExtension != null) entityExtension.ExtensionFieldsObject = dyna;
                return e;
            }, paramters, commandType: commandType).FirstOrDefault();
            return entity;
        }

        public static T FindById<T>(this IDbConnection connection, string sqlQuery, object id,
            CommandType commandType = CommandType.Text, Client client = null)
        {
            var parameters = id?.ToDictionary() ?? new Dictionary<string, object>();
            if (sqlQuery.Contains("@ClientId"))
                parameters.Add("ClientId", client?.Id);

            return typeof(T).IsSubclassOf(typeof(EntityExtension))
                ? GetEntityExtension<T>(connection, parameters, sqlQuery, commandType)
                : connection.Query<T>(sqlQuery, parameters, commandType: commandType).FirstOrDefault();
        }

        public static dynamic FindById(this IDbConnection connection, string sqlQuery, object id,
            CommandType commandType = CommandType.Text)
        {
            return connection.Query(sqlQuery, new { Id = id }, commandType: commandType).FirstOrDefault();
        }

        public static Result<SpTransactionMessage> ExecuteQuery(this IDbConnection connection, string sqlQuery,
            object paramterValues, CommandType commandType, IDbTransaction transaction = null)
        {
            var result =
                connection.Query<SpTransactionMessage>(sqlQuery, paramterValues, commandType: commandType, transaction: transaction)
                    .FirstOrDefault();

            if ((result != null && result.Success) || result == null)
            {
                return Result.Ok(result ?? new SpTransactionMessage() { Success = true });
            }
            logErrorMessage(result.Message, sqlQuery, paramterValues);
            return Result.Fail(result, result.Message);
        }

        private static void logErrorMessage(string msg, string sqlQuery, object paramterValues)
        {
            try
            {
                logger.Error(string.Format("Error Executing ExecuteQuery: Msg:{0} sqlQuery:{1} parameterValues:{2}", msg, sqlQuery, paramterValues != null ? JsonConvert.SerializeObject(paramterValues) : "null"));
            }
            catch (Exception ex)
            {
                logger.Error(ex, string.Format("Error while saving logErrorMessage"));
            }
        }
        public static async Task<Result<SpTransactionMessage>> ExecuteQueryAsync(this IDbConnection connection, string sqlQuery,
            object paramterValues, CommandType commandType, IDbTransaction transaction = null)
        {
            var resultAsync = await connection.QueryAsync<SpTransactionMessage>(sqlQuery, paramterValues, commandType: commandType, transaction: transaction);
            //.FirstOrDefault();
            var result = resultAsync.FirstOrDefault();
            if ((result != null && result.Success) || result == null)
            {
                return Result.Ok(result ?? new SpTransactionMessage() { Success = true });
            }

            logErrorMessage(result.Message, sqlQuery, paramterValues);
            return Result.Fail(result, result.Message);
        }

        public static T ExecuteQuery<T>(this IDbConnection connection, string sqlQuery, object paramterValues, CommandType commandType)
        {
            return connection.Query<T>(sqlQuery, paramterValues, commandType: commandType).FirstOrDefault();
        }

        public static async Task<T> ExecuteQueryAsync<T>(this IDbConnection connection, string sqlQuery, object paramterValues, CommandType commandType)
        {
            var resultAsync = await connection.QueryAsync<T>(sqlQuery, paramterValues, commandType: commandType);
            return resultAsync.FirstOrDefault();
        }

        private static string GetTableName(string tableName, Client client)
        {
            return string.IsNullOrEmpty(client?.Name) ? tableName : tableName + "Extension" + client.Name;
        }

        const string ClientString = "Client";

        private static IEnumerable<PropertyInfo> GetPrimitiveTypeProperties<T>()
        {
            var results = new List<PropertyInfo>();
            var properties = typeof(T).GetProperties();
            properties.ToList().ForEach(p =>
            {
                if (IsPrimitive(p.PropertyType))
                    results.Add(p);
            });
            return results;
        }

        private static bool IsPrimitive(Type t)
        {
            //// quite understand what your definition of primitive type is
            //return new[]
            //{
            //    typeof(string),
            //    typeof(char),
            //    typeof(byte),
            //    typeof(sbyte),
            //    typeof(ushort),
            //    typeof(short),
            //    typeof(uint),
            //    typeof(int),
            //    typeof(ulong),
            //    typeof(long),
            //    typeof(float),
            //    typeof(double),
            //    typeof(decimal),
            //    typeof(DateTime),
            //}.Contains(t);
            return t?.Namespace?.StartsWith("System") ?? false;
        }

        private static PropertyInfo[] FilterProperties<T>(PropertyInfo[] properties)
        {
            // if (!typeof(T).IsSubclassOf(typeof(EntityExtension))) return properties;

            var filterList = new List<string> { "EXTENSIONFIELDS", "EXTENSIONFIELDSOBJECT", "COLUMNS", "RELATIONSHIPS", "CACHEKEY" };
            return properties.Where(p => !filterList.Contains(p.Name.ToUpper())).ToArray();
        }

        public static IDictionary<string, object> ToDictionary(this object obj)
        {
            IDictionary<string, object> result = new Dictionary<string, object>();
            var properties = TypeDescriptor.GetProperties(obj);
            foreach (PropertyDescriptor property in properties)
            {
                result.Add(property.Name, property.GetValue(obj));
            }
            return result;
        }
    }
}
