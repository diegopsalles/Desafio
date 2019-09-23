using Project.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Contracts
{
    public interface IPlansRepository
    {
        void Insert(Plans plans);
        void Update(Plans plans);

        void Delete(int idPlan);

        List<Plans> SelectAll();
        Plans SelectById(int IDPlan);
        Plans SelectBySku(string SKU);
        Plans SelectByMobileOperator(string MobileOperator);
    }
}
