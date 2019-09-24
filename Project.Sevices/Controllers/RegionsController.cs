using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Contracts;
using Project.Entities;
using Project.Sevices.Models;

namespace Project.Sevices.Controllers
{
    [Produces("application/json")]
    [Route("api/regions")]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionBusiness _business;

        public RegionsController(IRegionBusiness business)
        {
            business = _business;
        }

        [HttpPost]
        public IActionResult Post([FromBody] RegionsCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var region = Mapper.Map<Region>(model);
                    _business.Insert(region);

                    return Ok("Região cadastrado com sucesso!");
                }
                catch(Exception e)
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
        public IActionResult Put([FromBody] RegionsEdicaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var region = Mapper.Map<Region>(model);
                    _business.Update(region);

                    return Ok("Região atualizado com sucesso!");
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


        [HttpGet("{idregion}")]
        [Produces(typeof(RegionsConsultaViewModel))]
        public IActionResult GetById(int idregion)
        {
            try
            {
                var regionId = _business.GetByID(idregion);
                var model = Mapper.Map<RegionsConsultaViewModel>(regionId);

                return Ok(model);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{ddd}")]
        [Produces(typeof(RegionsConsultaViewModel))]
        public IActionResult GetByDDD(int ddd)
        {
            try
            {
                var regionDDD = _business.GetByDDD(ddd);
                var model = Mapper.Map<RegionsConsultaViewModel>(regionDDD);

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

                return Ok("Region excluída com sucesso!");
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
                     
    }
}