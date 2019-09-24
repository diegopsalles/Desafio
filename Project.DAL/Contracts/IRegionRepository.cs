using Project.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Contracts
{
    public interface IRegionRepository
    {
        void Insert(Region region);
        void Update(Region region);
        void Delete(int idRegion);

        List<Region> ListAll();
        Region GetById(int idRegion);
        Region GetByDDD(int ddd);
        
    }
}
