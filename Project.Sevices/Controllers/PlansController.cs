﻿using System;
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
    [Route("api/plans")]
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


        [HttpPut("{id}")]
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


        [HttpGet("{idplan}")]
        [Produces(typeof(PlansConsultaViewModel))]
        public IActionResult GetById(int idplan)
        {
            return Ok();
        }

        [HttpGet("{mobileoperator}")]
        [Produces(typeof(PlansConsultaViewModel))]
        public IActionResult GetByMobileOperator(string mobileoperator)
        {
            return Ok();
        }

        [HttpGet("{sku}")]
        [Produces(typeof(PlansConsultaViewModel))]
        public IActionResult GetBySku(string sku)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Delete(int id)
        {
            return Ok("Cliente excluído com sucesso!");
        }




    }
}