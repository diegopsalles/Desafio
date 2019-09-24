using Project.BLL.Contracts;
using Project.DAL.Contracts;
using Project.Entities;
using System.Collections.Generic;

namespace Project.BLL.Business
{
    public class RegionBusiness : IRegionBusiness
    {
        private readonly IRegionRepository _repository;

        public RegionBusiness(IRegionRepository repository)
        {
            repository = _repository;
        }
        public void Update(Region region)
        {
            _repository.Update(region);
        }

        public void Insert(Region region)
        {
            _repository.Insert(region);
        }

        public Region GetByDDD(int DDD)
        {
            return _repository.GetByDDD(DDD);
        }

        public Region GetByID(int IdRegion)
        {
            return _repository.GetById(IdRegion);
        }

        public List<Region> ListAll()
        {
            return _repository.ListAll();
        }

        public void Delete(int IdRegion)
        {
            _repository.Delete(IdRegion);
        }
    }
}
