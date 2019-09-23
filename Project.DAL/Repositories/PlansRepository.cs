using Dapper;
using Project.DAL.Contracts;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Project.DAL.Repositories
{
    public class PlansRepository : IPlansRepository
    {
        private readonly string connectionString;

        public PlansRepository (string connectionStrings)
        {
            this.connectionString = connectionString;
        }

        public void Delete(int idPlan)
        {
            var query = "delete from Plans where IDPlan = @IDPlan";
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Execute(query, new { IDPlan = idPlan });
            }
        }

        public void Insert(Plans plans)
        {
            var query = "insert into Plans(IDPlan, SKU, Name, Minutes, InternetFranchise, PriceOfPlan, MobileOperator, Region) values (@IDPlan, @SKU, @Name, @Minutes, @InternetFranchise, @PriceOfPlan, @MobileOperator, @Region)";

            using(var conn = new SqlConnection(connectionString))
            {
                conn.Execute(query, plans);
            }
        }

        public List<Plans> SelectAll()
        {
            var query = "select * from Plans";
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Query<Plans>(query).ToList();
            }
        }

        public Plans SelectById(int IDPlan)
        {
            var query = "select * from Plans where IDPlan = @IDPlan";
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.QuerySingleOrDefault<Plans>
                (query, new { IDPlan = IDPlan });
            }
        }

        public Plans SelectByMobileOperator(string MobileOperator)
        {
            var query = "select * from Plans where MobileOperator = @MobileOperator";
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.QuerySingleOrDefault<Plans>
                (query, new { MobileOperator = MobileOperator });
            }
        }

        public Plans SelectBySku(string SKU)
        {
            var query = "select * from Plans where SKU = @SKU";
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.QuerySingleOrDefault<Plans>
                (query, new { SKU = SKU });
            }
        }

        public void Update(Plans plans)
        {
            var query = "update Plans set SKU = @SKU, Name = @Name, Minutes = @Minutes, InternetFranchise = @InternetFranchise, PriceOfPlan = @PriceOfPlan, MobileOperator = @MobileOperator, Region = @Region where IDPlan = @IDPlan";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Execute(query, plans);
            }
        }
    }
}
