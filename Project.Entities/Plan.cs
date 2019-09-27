using System;
using System.Collections.Generic;

namespace Project.Entities
{
    public class Plan
    {
        public Plan()
        {
            Regions = new List<PlanRegion>();
        }

        public int IdPlan { get; set; }
        public string  SKU { get; set; }
        public string Name { get; set; }
        public int Minutes { get; set; }
        public string InternetFranchise { get; set; }
        public decimal PriceOfPlan { get; set; }
        public string TypeOfPlan { get; set; }
        public string MobileOperator { get; set; }
        public List<PlanRegion> Regions { get; set; }

        public virtual void AddRegion(Region region)
        {
            var planRegion = new PlanRegion
            {
                IdPlan = IdPlan,
                IdRegion = region.IdRegion
            };
            Regions.Add(planRegion);


        }
    }
}
