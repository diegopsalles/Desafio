using Project.BLL.Contracts;
using Project.Entities;
using System;
using System.Collections.Generic;
using Project.DAL.Contracts;

namespace Project.BLL.Business
{
    public class RegionBusiness : IRegionBusiness
    {
        private readonly IRegionRepository _repository;

        public RegionBusiness (IRegionRepository repository)
        {
            repository = _repository
        }
        public void Atualizar(Region region)
        {
            _repository.Atualizar(region);
        }

        public void Cadastrar(Region region)
        {
            _repository.Cadastrar(region);   
        }

        public Region ConsultarPorDDD(int DDD)
        {
            return _repository.GetByDDD(DDD);
        }

        public Region ConsultarPorID(int IdRegion)
        {
            return _repository.GetById(IdRegion);
        }

        public List<Region> ConsultarTodos()
        {
            return _repository.ListAll();
        }

        public void Excluir(int IdRegion)
        {
            _repository.Delete(IdRegion);
        }
    }
}
