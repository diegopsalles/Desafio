using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Sevices.Models
{
    public class PlansConsultaViewModel
    {
        public int IdPlan { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public int Minutes { get; set; }
        public string InternetFranchise { get; set; }
        public decimal PriceOfPlan { get; set; }
        public string TypeOfPlan { get; set; }
        public string MobileOperator { get; set; }
        public List<Region> Region { get; set; }
    }

}
