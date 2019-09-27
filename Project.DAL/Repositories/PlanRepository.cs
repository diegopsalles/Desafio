using Dapper;
using Project.DAL.Contracts;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Data;
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
            var query = @"insert into Plans(SKU, Name, Minutes, InternetFranchise, PriceOfPlan, TypeOfPlan, MobileOperator) values 
                            (@SKU, @Name, @Minutes, @InternetFranchise, @PriceOfPlan, @TypeOfPlan, @MobileOperator)" + "SELECT CAST(scope_identity() AS int)";
                      

            using (var conn = new SqlConnection(_connectionString))
            {

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.Add("@SKU", SqlDbType.VarChar);
                cmd.Parameters["@SKU"].Value = plans.SKU;

                cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                cmd.Parameters["@Name"].Value = plans.Name;

                cmd.Parameters.Add("@Minutes", SqlDbType.Int);
                cmd.Parameters["@Minutes"].Value = plans.Minutes;

                cmd.Parameters.Add("@InternetFranchise", SqlDbType.VarChar);
                cmd.Parameters["@InternetFranchise"].Value = plans.InternetFranchise;

                cmd.Parameters.Add("@PriceOfPlan", SqlDbType.Decimal);
                cmd.Parameters["@PriceOfPlan"].Value = plans.PriceOfPlan;

                cmd.Parameters.Add("@TypeOfPlan", SqlDbType.VarChar);
                cmd.Parameters["@TypeOfPlan"].Value = plans.TypeOfPlan;

                cmd.Parameters.Add("@MobileOperator", SqlDbType.VarChar);
                cmd.Parameters["@MobileOperator"].Value = plans.MobileOperator;

                conn.Open();

                var _idPlan = (int)cmd.ExecuteScalar();

                conn.Close();

                //conn.Execute(query, plans));                

                if (_idPlan > 0 && plans.Regions.Count() > 0)
                {
                    var queryPlanRegion = "insert into PlanRegion (IdPlan, IdRegion) values (@IdPlan, @IdRegion)";

                    foreach (var region in plans.Regions)
                    {
                        bool status = Convert.ToBoolean(conn.Execute(queryPlanRegion, new { IdPlan = _idPlan, IdRegion = region.IdRegion }));
                    }
                }
            }
        }

        public void Update(Plan plans)
        {
            var query = "update Plans set SKU = @SKU, Name = @Name, Minutes = @Minutes, InternetFranchise = @InternetFranchise, PriceOfPlan = @PriceOfPlan, TypeOfPlan = @TypeOfPlan, MobileOperator = @MobileOperator, Region = @Region where IdPlan = @IdPlan";

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

        public Plan GetBySKU(string sku)
        {
            var query = "select * from Plans where SKU = @SKU";
            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.QuerySingleOrDefault<Plan>
                (query, new { SKU = sku });
            }
        }

        public List<Plan> ListAll(string mobileOperator, string typeOfPlan)
        {
            var retorno = new List<Plan>();
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "select * from Plans";
                if (!string.IsNullOrEmpty(mobileOperator) && !string.IsNullOrEmpty(typeOfPlan))
                {
                    query += " where MobileOperator = @mobileOperator and TypeOfPlan = @TypeOfPlan";
                    retorno = conn.Query<Plan>(query, new { MobileOperator = mobileOperator, TypeOfPlan = typeOfPlan }).ToList();
                }
                else if (!string.IsNullOrEmpty(mobileOperator))
                {
                    query += " where MobileOperator = @mobileOperator";
                    retorno = conn.Query<Plan>(query, new { MobileOperator = mobileOperator }).ToList();
                }
                else if (!string.IsNullOrEmpty(typeOfPlan))
                {
                    query += " where TypeOfPlan = @TypeOfPlan";
                    retorno = conn.Query<Plan>(query, new { TypeOfPlan = typeOfPlan }).ToList();
                }
            }
            return retorno;
        }

        public List<Plan> GetPlansByDDD(int ddd)
        {
            var retorno = new List<Plan>();
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = @"select * from Plans as P
                                join PlanRegion as PR on PR.IdPlan = P.IdPlan
                                join Region as R on R.IdRegion = PR.IdRegion
                                where R.DDD = @DDD";
                                    
                retorno = conn.Query<Plan>(query, new { DDD = ddd }).ToList();
                
            }
            return retorno;
        }


    }
}

