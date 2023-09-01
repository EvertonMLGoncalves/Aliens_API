using APIALiens.DTOs.PoderDTOs;
using APIALiens.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIALiens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoderController : ControllerBase
    {
        private readonly IPoderService _service;
        public PoderController(IPoderService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PoderDTO>>> GetAllPoderes()
        {
            var poderes = await _service.GetAllPoderes();
            if (poderes == null || !poderes.Any()) return NotFound("Nenhum poder foi encontrado");
            return Ok(poderes);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<PoderDTO>> GetPoderById(int id)
        {
            var poder = await _service.GetPoderById(id);
            if (poder == null) return NotFound("Poder não encontrado");
            return Ok(poder);
        }

        [HttpGet("nome/{nome}")]
        public async Task<ActionResult<PoderDTO>> GetPoderByName(string nome)
        {
            var poder = await _service.GetPoderByNome(nome);
            if (poder == null) return NotFound("Poder não encontrado");
            return Ok(poder);
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreatePoderAsync(CreatePoderDTO poder)
        {
            return Ok(await _service.CreatePoderAsync(poder));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdatePoder(int id, CreatePoderDTO poder)
        {
            var response = await _service.UpdatePoder(id, poder);
            if (response == "PoderNotFound")
                return NotFound("Poder não encontrado");
            return Ok(response);
        }

        [HttpPut("{poderId}/aliens")]
        public async Task<ActionResult<string>> UpdateAliensPoder(int poderId, [FromBody] AlienIdsDTO alienIds)
        {
            var response = await _service.UpdateAliensPoder(poderId, alienIds);
            if (response == "PoderNotFound")
                return NotFound("Poder não encontrado");
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeletePoder(int id)
        {
            var response = await _service.DeletePoder(id);
            if (response == null) return NotFound("Poder não encontrado");
            return Ok(response);
        }
    }
}
