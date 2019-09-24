using Project.BLL.Contracts;
using Project.Entities;
using System;
using System.Collections.Generic;
using Project.DAL.Contracts;

namespace Project.BLL.Business
{
    public class PlanBusiness : IPlanBusiness
    {
        private readonly IPlanRepository _repository;

        public PlanBusiness(IPlanRepository repository)
        {
            repository = _repository;
        }

        public void Delete(int idPlan)
        {
            _repository.Delete(idPlan);
        }

        public Plan GetByID(int IdPlan)
        {
            return _repository.GetByID(IdPlan);
        }

        public Plan GetByMobileOperator(string mobileOperator)
        {
            return _repository.GetByMobileOperator(mobileOperator);
        }

        public Plan GetBySKU(string sku)
        {
            return _repository.GetBySKU(sku);
        }

        public Plan GetByTypeOfPlan(string typeOfPlan)
        {
            return _repository.GetByTypeOfPlan(typeOfPlan);
        }

        public void Insert(Plan plan)
        {
            _repository.Insert(plan);
        }

        public List<Plan> ListAll()
        {
            return _repository.ListAll();
        }

        public void Update(Plan plan)
        {
            _repository.Update(plan);
        }
    }
}
