using Project.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Contracts
{
    interface IRegionRepository
    {
        void Insert(Region plan);
        void Update(Region plan);
        void Delete(int idPlan);

        List<Region> ListAll();
        Region GetById(int idPlan);
        Region GetByDDD(int ddd);
        
    }
}
