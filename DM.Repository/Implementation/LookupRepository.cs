using Dapper;
using System.Collections.Generic;
using System.Data;
using DM.Model;
using DM.Repository.Implementation;
using DM.Repository.Interfaces;
using DM.Model.Entities;
using System;

namespace DM.Repository.Implementation
{
    public class LookupRepository : BaseRepository<Lookup>, ILookupRepository
    {
        public static readonly string StoreProcGetServicePreferences = "spGetServicePreferences";
        public static readonly string StoreProcGetServicePreferencesLookupConstant = "spLookupContantGetValueById";
        public static readonly string StoreProcGetLookupsByType = "spLookupsSelectByTypeId";
        private readonly IDbHelper _dbHelper;

        public LookupRepository(IDbHelper dbHelper) : base(dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public IEnumerable<Lookup> GetServiceLookups(string ServiceId)
        {
            var dapper = _dbHelper.GetDbConnection(_dbHelper.DatabaseThmDB);
            var items = dapper.Query<Lookup>(StoreProcGetServicePreferences,
               new { @ServiceId = ServiceId },
                null, true, null, CommandType.StoredProcedure);
            return items;
        }
        public IEnumerable<Lookup> GetLookupsByTypeId(Guid Id)
        {
            var dapper = _dbHelper.GetDbConnection(_dbHelper.DatabaseThmDB);
            var items = dapper.Query<Lookup>(StoreProcGetLookupsByType,
               new { @LookupTypeId = Id },
                null, true, null, CommandType.StoredProcedure);
            return items;
        }
    }
}