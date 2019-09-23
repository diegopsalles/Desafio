using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Entities;
using Project.Sevices.Models;

namespace Project.Sevices.Controllers
{
    [Produces("application/json")]
    [Route("api/Plans")]
    public class PlansController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] PlansCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok("Plano cadastrado com sucesso!");
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        public IActionResult Put([FromBody] PlansEdicaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok("Plano atualizado com sucesso!");
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Produces(typeof(PlansConsultaViewModel))]
        public IActionResult GetById(int id, string ddd)
        {
            return Ok();
        }

        [HttpGet]
        [Produces(typeof(PlansConsultaViewModel))]
        public IActionResult GetByMobileOperator(string opertor)
        {
            return Ok();
        }

        [HttpGet]
        [Produces(typeof(PlansConsultaViewModel))]
        public IActionResult GetBySku(string sku)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok("Cliente excluído com sucesso!");
        }

    }
}