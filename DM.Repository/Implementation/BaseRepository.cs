using Dapper;
//using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DM.Model;
using DM.Model.BaseEntities;
using DM.Model.Entities;
using DM.Model.Interfaces;
using DM.Repository.Extensions;
using DM.Repository.Interfaces;

namespace DM.Repository.Implementation
{
    public class BaseRepository : IBaseRepository
    {
        protected readonly IDbHelper DbHelper;
        protected IDbConnection DbConnection { get; }

        public BaseRepository(IDbHelper dbHelper)
        {
            DbHelper = dbHelper;
            DbConnection = DbHelper.GetDbConnection();
        }

        public virtual IEnumerable<dynamic> GetAll(string sqlQuery, object parameterValues, CommandType commandType)
            => DbConnection.GetList(sqlQuery, parameterValues, commandType);

        public virtual dynamic FindById(string sqlQuery, object id, CommandType commandType)
            => DbConnection.FindById(sqlQuery, id, commandType);

        public virtual Result<SpTransactionMessage> ExecuteQuery(string sqlQuery, object paramterValues,
            CommandType commandType)
            => DbConnection.ExecuteQuery(sqlQuery, paramterValues, commandType);
    }

    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly IDbHelper DbHelper;
        protected IDbConnection DbConnection { get; }

        public BaseRepository(IDbHelper dbHelper)
        {
            DbHelper = dbHelper;
            DbConnection = DbHelper.GetDbConnection();
        }

        protected DM.Repository.Interfaces.DatabaseEnum DatabaseThmDB
        {
            get
            {
                return DM.Repository.Interfaces.DatabaseEnum.ThmDB;
            }
        }

        //public virtual IEnumerable<T> GetAll(object parameterValues) => DbConnection.GetList<T>(parameterValues);

        public virtual IEnumerable<T> GetAll(string sqlQuery, object parameterValues, CommandType commandType)
            => DbConnection.GetList<T>(sqlQuery, parameterValues, commandType);

        //public virtual T FindById(object id, Client client = null) => DbConnection.FindById<T>(id, client);

        
        public virtual T FindById(string sqlQuery, object id, CommandType commandType, Client client = null)
            => DbConnection.FindById<T>(sqlQuery, id, commandType, client);

        public virtual Result<SpTransactionMessage> ExecuteQuery(string sqlQuery, object paramterValues,
            CommandType commandType)
            => DbConnection.ExecuteQuery(sqlQuery, paramterValues, commandType);

        //public virtual Guid Insert(T t) => DbConnection.Insert(t);

        public bool Exists(string sql, object param = null, IDbTransaction transaction = null,
            int? commandTimeout = null, CommandType? commandType = null)
        {
            var count = DbConnection.ExecuteScalar<int>(sql, param, transaction, commandTimeout, commandType);
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public object ExecuteScalar(string sql, object param = null, IDbTransaction transaction = null,
            int? commandTimeout = null, CommandType? commandType = null)
        {
            return DbConnection.ExecuteScalar<object>(sql, param, transaction, commandTimeout, commandType);
        }

        public T ExecuteQuery<T1>(string sqlQuery, object paramterValues, CommandType commandType) => DbConnection.ExecuteQuery<T>(sqlQuery, paramterValues, commandType);

       
        
        public virtual Result<SpTransactionMessage> InsertEntity(T t)
        {
            //DbConnection.Insert(t);
            return Result.Ok(new SpTransactionMessage() { Success = true });
        }

        public Result<SpTransactionMessage> UpdateEntity(T t)
        {
            //DbConnection.Update(t);
            return Result.Ok(new SpTransactionMessage() { Success = true });
        }

        public Result<SpTransactionMessage> DeleteEntity(T t)
        {
            //DbConnection.Delete(t);
            return Result.Ok(new SpTransactionMessage() { Success = true });
        }

        public Result<SpTransactionMessage> DeleteEntity(Guid id)
        {
            //var predicate = Predicates.Field<T>(f => (f as IEntity).Id, Operator.Eq, id);
            //DbConnection.Delete(predicate);
            return Result.Ok(new SpTransactionMessage() { Success = true });
        }

        public void ExecuteQuery(object formSchemaFormSchemaCategoryMapQueries)
        {
            throw new NotImplementedException();
        }
    }
}
