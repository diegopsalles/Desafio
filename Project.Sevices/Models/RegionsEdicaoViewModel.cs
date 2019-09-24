using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Sevices.Models
{
    public class RegionsEdicaoViewModel
    {
        [Required(ErrorMessage="Campo obrigatório")]
        public int DDD { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string State { get; set; }
    }
}
