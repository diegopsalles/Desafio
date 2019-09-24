using Project.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.Contracts
{
    public interface IPlanBusiness
    {
        void Insert(Plan plan);
        void Update(Plan plan);
        void Delete(int idPlan);

        List<Plan> ListAll();
        Plan GetByID(int IdPlan);
        Plan GetBySKU(string sku);
        Plan GetByTypeOfPlan(string typeOfPlan);
        Plan GetByMobileOperator(string mobileOperator);


    }
}
