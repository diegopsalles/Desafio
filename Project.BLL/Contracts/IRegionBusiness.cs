using Project.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.Contracts
{
    public interface IRegionBusiness
    {
        void Insert(Region region);
        void Update(Region region);
        void Delete(int IdRegion);

        List<Region> ListAll();
        Region GetByID(int IdRegion);
        Region GetByDDD(int DDD);
    }
}
