using Dapper;
using System.Collections.Generic;
using System.Data;
using DM.Model;
using DM.Repository.Implementation;
using DM.Repository.Interfaces;
using DM.Model.Entities;
using System;
using System.Linq;

namespace DM.Repository.Implementation
{
    public class LookupConstantRepository : BaseRepository<LookupConstant>, ILookupConstantRepository
    {
        public static readonly string StoreProcGetAll = "spLookupConstantSelectAll";
        public static readonly string StoreProcGetById = "spLookupConstantSelectById";
        private readonly IDbHelper _dbHelper;

        public LookupConstantRepository(IDbHelper dbHelper) : base(dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public IEnumerable<LookupConstantViewModel> GetAll()
        {
            var dapper = _dbHelper.GetDbConnection(_dbHelper.DatabaseThmDB);
            return dapper.Query<LookupConstantViewModel>(StoreProcGetAll,
               null,
                null, true, null, CommandType.StoredProcedure);
        }
        public LookupConstantViewModel GetById(Guid id)
        {
            var dapper = _dbHelper.GetDbConnection(_dbHelper.DatabaseThmDB);
            return dapper.Query<LookupConstantViewModel>(StoreProcGetById,
               new { @lookupConstantId = id },
                null, true, null, CommandType.StoredProcedure).FirstOrDefault();
        }
    }
}