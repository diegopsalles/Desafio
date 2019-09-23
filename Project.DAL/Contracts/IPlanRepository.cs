using Project.Entities;
using System.Collections.Generic;

namespace Project.DAL.Contracts
{
    public interface IPlanRepository
    {
        void Insert(Plan plan);
        void Update(Plan plan);
        void Delete(int idPlan);

        List<Plan> ListAll();
        Plan GetById(int idPlan);
        Plan GetBySku(string sku);
        Plan GetByMobileOperator(string mobileOperator);
    }
}
