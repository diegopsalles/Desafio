using Project.Entities;
using System.Collections.Generic;

namespace Project.DAL.Contracts
{
    public interface IPlanRepository
    {
        void Insert(Plan plan);
        void Update(Plan plan);
        void Delete(int idPlan);

        List<Plan> ListAll(string mobileOperator, string typeOfPlan);
        Plan GetByID(int idPlan);
        Plan GetBySKU(string sku);

        List<Plan> GetPlansByDDD(int ddd);
    }
}
