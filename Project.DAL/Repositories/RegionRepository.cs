using Dapper;
using Project.DAL.Contracts;
using Project.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Project.DAL.Repositories
{
    public class RegionRepository : IRegionRepository

    {
        private readonly string _connectionString;

        public RegionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Delete(int idRegion)
        {
            var query = "delete from Region where IdRegion = @IdRegion";
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Execute(query, new { IdRegion = idRegion });
            }
        }

        public Region GetByDDD(int ddd)
        {
            var query = "select * from Region where DDD = @DDD";
            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.QuerySingleOrDefault<Region>(query, new { DDD = ddd });
            }
        }

        public Region GetById(int idRegion)
        {
            var query = "select * from Region where IdRegion = @IdRegion";
            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.QuerySingleOrDefault<Region>(query, new { idRegion = idRegion });
            }
        }

        public void Insert(Region region)
        {
            var query = "insert into Region(IdRegion, DDD, State) values (@IdRegion, @DDD, @State)";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Execute(query, region);
            }
        }

        public List<Region> ListAll()
        {
            var query = "select * from Region";
            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Query<Region>(query).ToList();
            }
        }

        public void Update(Region region)
        {
            var query = "update Plans set IdRegion = @IdRegion, DDD = @DDD, State = @State where IdRegion = @IdRegion";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Execute(query, region);
            }
        }
    }
}
