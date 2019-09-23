using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Sevices.Models;

namespace Project.Sevices.Controllers
{
    [Produces("application/json")]
    [Route("api/regions")]
    public class RegionsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] RegionsCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok("Região cadastrado com sucesso!");
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut("{id}")]
        public IActionResult Put([FromBody] RegionsEdicaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok("Região atualizado com sucesso!");
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet("{idregion}")]
        [Produces(typeof(RegionsConsultaViewModel))]
        public IActionResult GetById(int idregion)
        {
            return Ok();
        }

        [HttpGet("{ddd}")]
        [Produces(typeof(RegionsConsultaViewModel))]
        public IActionResult GetByDDD(int ddd)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok("Região excluída com sucesso!");
        }
                     
    }
}