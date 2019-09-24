using Project.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.Contracts
{
    public interface IRegionBusiness
    {
        void Cadastrar(Region region);
        void Atualizar(Region region);
        void Excluir(int IdRegion);

        List<Region> ConsultarTodos();
        Region ConsultarPorID(int IdRegion);
        Region ConsultarPorDDD(int DDD);
    }
}
