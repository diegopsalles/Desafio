using Project.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.Contracts
{
    public interface IPlanBusiness
    {
        void Cadastrar(Plan plan);
        void Atualizar(Plan plan);
        void Excluir(int idPlan);

        List<Plan> ConsultarTodos();
        Plan ConsultarPorID(int IdPlan);
        Plan ConsultarPorSKU(int sku);
        Plan ConsultarPorMobileOperator(string mobileOperator);


    }
}
