using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Contracts;
using Project.Entities;
using Project.Sevices.Models;
using System;
using System.Collections.Generic;

namespace Project.Sevices.Controllers
{

    [Produces("application/json")]
    [Route("api/plans")]
    public class PlansController : ControllerBase
    {
        private readonly IPlanBusiness _business;

        public PlansController(IPlanBusiness business)
        {
            _business = business;
        }

        [HttpPost]
        public IActionResult Post([FromBody] PlansCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var plan = Mapper.Map<Plan>(model);
                    if (model.RegionsAssociadas != null && model.RegionsAssociadas.Count > 0)
                    {
                        model.RegionsAssociadas.ForEach(s => plan.AddRegion(s));
                    }
                    _business.Insert(plan);

                    return Ok("Plano cadastrado com sucesso!");
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
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
                try
                {
                    var plan = Mapper.Map<Plan>(model);
                    _business.Update(plan);

                    return Ok("Plano atualizado com sucesso!");
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);

                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("getby/{idplan}")]
        [Produces(typeof(PlansConsultaViewModel))]
        public IActionResult GetById(int idplan)
        {
            try
            {
                var planId = _business.GetByID(idplan);
                var model = Mapper.Map<PlansConsultaViewModel>(planId);

                return Ok(model);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("")]
        [Produces(typeof(PlansConsultaViewModel))]
        public IActionResult GetAlll([FromQuery] string mobileOperator, string typeOfPlan)
        {
            try
            {
                var listPlans = _business.ListAll(mobileOperator, typeOfPlan);
                var returnListModel = Mapper.Map<List<PlansConsultaViewModel>>(listPlans);

                return Ok(returnListModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("getby/{DDD}")]
        [Produces(typeof(PlansConsultaViewModel))]
        public IActionResult GetPlansByDDD(int DDD)
        {
            try
            {
                var listPlans = _business.ListPlanByDDD(DDD);
                var returnListModel = Mapper.Map<List<PlansConsultaViewModel>>(listPlans);

                return Ok(returnListModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpGet("getby/{sku}")]
        [Produces(typeof(PlansConsultaViewModel))]
        public IActionResult GetBySku(string sku)
        {
            try
            {
                var planSku = _business.GetBySKU(sku);
                var model = Mapper.Map<PlansConsultaViewModel>(planSku);

                return Ok(model);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _business.Delete(id);

                return Ok("Plano excluído com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);

            }
        }

    }
}
