using AutoMapper;
using Project.Entities;
using Project.Sevices.Models;

namespace Project.Sevices.Mappings
{
    public class EntityToViewModelMap : Profile
    {
        public EntityToViewModelMap()
        {
            CreateMap<Plan, PlansConsultaViewModel>();
            CreateMap<Region, RegionsConsultaViewModel>();
        }
    }
}
