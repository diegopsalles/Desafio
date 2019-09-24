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

        public void Atualizar(Plan plan)
        {
            _repository.Update(plan);
        }

        public void Cadastrar(Plan plan)
        {
            _repository.Insert(plan);
        }

        public Plan ConsultarPorID(int IdPlan)
        {
            return _repository.GetById(int idPlan);
        }

        public Plan ConsultarPorMobileOperator(string mobileOperator)
        {
            return _repository.GetByMobileOperator(mobileOperator);
        }

        public Plan ConsultarPorSKU(int sku)
        {
            return _repository.GetBySku(sku);
        }

        public List<Plan> ConsultarTodos()
        {
            return _repository.ListAll();
        }

        public void Excluir(int idPlan)
        {
            _repository.Delete(int idPlan);
        }
    }
}
