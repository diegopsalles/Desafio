using Project.DAL.Contracts;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Repositories
{
    class RegionRepository : IRegionRepository

    {
        private readonly string _connectionString;

        public RegionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Delete(int idRegion)
        {
            throw new NotImplementedException();
        }

        public Region GetByDDD(string ddd)
        {
            throw new NotImplementedException();
        }

        public Region GetById(int idRegion)
        {
            throw new NotImplementedException();
        }

        public void Insert(Region region)
        {
            throw new NotImplementedException();
        }

        public List<Region> ListAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Region region)
        {
            throw new NotImplementedException();
        }
    }
}
