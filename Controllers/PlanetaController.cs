using APIALiens.DTOs.PlanetaDTOs;
using APIALiens.Models;
using APIALiens.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIALiens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetaController : ControllerBase
    {
        private readonly IPlanetaService _service;
        public PlanetaController(IPlanetaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanetaDto>>> GetPlanetas()
        {
            var planetas = await _service.GetAllPlanetas();
            return Ok(planetas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlanetaDto>> GetPlanetaById(int id)
        {
            var planeta = await _service.GetPlanetaById(id);
            if (planeta == null)
                return NotFound("Planeta não encontrado!");
            return Ok(planeta);
        }

        [HttpGet("populacao/{id}")]
        public async Task<ActionResult<int>> GetPopulacaoPlaneta(int id)
        {
            var populPlaneta = await _service.GetPopulacaoPlaneta(id);
            if (populPlaneta == -1)
                return NotFound("Planeta não encontrado!");

            return Ok(populPlaneta);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<string>> CreatePlaneta(UpdatePlanetaDTO planeta, int id)
        {
            var planetaModel = new Planeta
            {
                Id = id,
                Nome = planeta.Nome,
                Populacao = planeta.Populacao
            };
            return await _service.CreatePlaneta(planetaModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePlaneta(int id, UpdatePlanetaDTO planeta)
        {
            if (await _service.GetPlanetaById(id) == null)
                return NotFound("Planeta não encontrado!");

            var planetaModel = new Planeta
            {
                Id = id,
                Nome = planeta.Nome,
                Populacao = planeta.Populacao
            };
            await _service.UpdatePlaneta(id, planetaModel);

            return Ok("Planeta atualizado com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlaneta(int id)
        {
            if (await _service.GetPlanetaById(id) == null)
                return NotFound("Planeta não encontrado!");
            await _service.DeletePlaneta(id);
            return Ok("Planeta excluído com sucesso!");
        }
    }
}
