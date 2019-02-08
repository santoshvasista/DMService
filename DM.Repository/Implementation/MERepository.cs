using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DM.Model;
using DM.Model.Entities;
using DM.Model.ViewModel;
using DM.Repository.Implementation;
using DM.Repository.Interfaces;

namespace DM.Repository.Implementation
{
    public class MERepository
    {
        public static readonly string StoreProcGetZipCode = "spGetZipCodesInRadius";

        private string connectionString;

        public MERepository()
        {
            connectionString = "Data Source=duploDMcorp.database.windows.net;Initial Catalog=apa;;User Id=DMcorp; Password=hvsujB3a3uKs01!;Persist Security Info=False;MultipleActiveResultSets=True;";
            //connectionString = @"Server=localhost;Database=DapperDemo;Trusted_Connection=true;";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public ZipCodesStates GetZipCodesWithInRadius(int ZipCode)
        {
            //using (IDbConnection dbConnection = Connection)
            //{
            //string sQuery = "INSERT INTO Products (Name, Quantity, Price)"
            //                + " VALUES(@Name, @Quantity, @Price)";
            //dbConnection.Open();
            //dbConnection.Execute(sQuery, prod);
            //}
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT [Zipcode] as zipcode,[Latitude] as latitude,[Longitude] as longitude,[City] as city,[StateCode] as state,[County] as county,[Data] as data FROM [ZipCodesStates]"
                               + " WHERE [Zipcode] = @ZipCode";
                dbConnection.Open();
                var obj = dbConnection.Query<ZipCodesStates>(sQuery, new { ZipCode = ZipCode }).FirstOrDefault();
                return obj;
            }
        }
    }
}