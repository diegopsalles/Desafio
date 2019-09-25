using Dapper;
using Project.DAL.Contracts;
using Project.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Project.DAL.Repositories
{
    public class PlanRepository : IPlanRepository
    {
        private readonly string _connectionString;

        public PlanRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Insert(Plan plans)
        {
            var query = "insert into Plans(SKU, Name, Minutes, InternetFranchise, PriceOfPlan, TypeOfPlan, MobileOperator, Region) values (@SKU, @Name, @Minutes, @InternetFranchise, @PriceOfPlan, @TypeOfPlan, @MobileOperator, @Region)";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Execute(query, plans);
            }
        }
        public void Update(Plan plans)
        {
            var query = "update Plans set SKU = @SKU, Name = @Name, Minutes = @Minutes, InternetFranchise = @InternetFranchise, PriceOfPlan = @PriceOfPlan, MobileOperator = @MobileOperator, Region = @Region where IdPlan = @IdPlan";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Execute(query, plans);
            }
        }
        public void Delete(int idPlan)
        {
            var query = "delete from Plans where IdPlan = @IdPlan";
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Execute(query, new { IdPlan = idPlan });
            }
        }
        public Plan GetByID(int idPlan)
        {
            var query = "select * from Plans where IdPlan = @IdPlan";
            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.QuerySingleOrDefault<Plan>
                (query, new { IdPlan = idPlan });
            }
        }
        public Plan GetByMobileOperator(string mobileOperator)
        {
            var query = "select * from Plans where MobileOperator = @MobileOperator";
            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.QuerySingleOrDefault<Plan>
                (query, new { MobileOperator = mobileOperator });
            }
        }
        public Plan GetBySKU(string sku)
        {
            var query = "select * from Plans where SKU = @SKU";
            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.QuerySingleOrDefault<Plan>
                (query, new { SKU = sku });
            }
        }
        public List<Plan> ListAll()
        {
            var query = "select * from Plans";
            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Query<Plan>(query).ToList();
            }
        }
        public Plan GetByTypeOfPlan(string typeOfPlan)
        {
            var query = "select * from Plans where TypeOfPlan = @TypeOfPlan";
            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.QuerySingleOrDefault<Plan>
                (query, new { TypeOfPlan = typeOfPlan });
            }
        }
    }
}
