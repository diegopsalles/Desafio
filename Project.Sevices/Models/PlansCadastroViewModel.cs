using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Sevices.Models
{
    public class PlansCadastroViewModel
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public string SKU { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public int Minutes { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string InternetFranchise { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public decimal PriceOfPlan { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string TypeOfPlan { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string MobileOperator { get; set; }
    }
}