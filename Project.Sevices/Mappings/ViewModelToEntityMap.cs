using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Project.Entities;
using Project.Sevices.Models;

namespace Project.Sevices.Mappings
{
    public class ViewModelToEntityMap : Profile
    {
        public ViewModelToEntityMap()
        {
            CreateMap<PlansCadastroViewModel, Plan>();
            CreateMap<PlansEdicaoViewModel, Plan>();
            CreateMap<RegionsCadastroViewModel, Region>();
            CreateMap<RegionsEdicaoViewModel, Region>();
        }
    }
}
