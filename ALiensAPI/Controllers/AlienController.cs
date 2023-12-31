using APIALiens.DTOs;
using APIALiens.DTOs.ALienDTOs;
using APIALiens.DTOs.PlanetaDTOs;
using APIALiens.EmailModule;
using APIALiens.Models;
using APIALiens.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIALiens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlienController : ControllerBase
    {
        private readonly IAlienService _service;
        private readonly ISmtp _smtp;
        public AlienController(IAlienService service, ISmtp smtp)
        {
            _service = service;
            _smtp = smtp;
        }

        [HttpGet]
        public async Task<ActionResult<List<Alien>>> GetAllAliens()
        {
            var aliens = await _service.GetTodosAliens();
            if (aliens == null)
                return NotFound("Aliens não encontrados!");
            return Ok(aliens);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Alien>> GetAlienById(int id)
        {
            var alien = await _service.GetAlienById(id);
            if (alien == null)
                return NotFound("Alien não encontrado!");
            return Ok(alien);
        }
        [HttpGet("{id}/planeta")]
        public async Task<ActionResult<PlanetaDto>> GetPlanetaByAlienId(int id)
        {
            var planeta = await _service.GetPlanetaByAlienId(id);
            if (planeta == null)
                return NotFound("Alien ou Planeta não encontrados");
            return Ok(planeta);
        }


        [HttpPost]
        public async Task<ActionResult<string>> CreateAlien(CreateAlienDTO alien)
        {
            if (alien.PlanetaId == 0 || alien.PlanetaId == null) return "O alien deve ter um planeta!";
            var alienCriado = await _service.CreateAlien(alien);
            if (alienCriado == null)
                return BadRequest("Erro! Alien não pode ser criado");
            if (alien.Email != null)
            {
                try
                {
                    var response = await _smtp.SendEmail(new EmailDTO
                    {
                        To = alien.Email,
                        Subject = "Alienígena cadastrado com sucesso",
                        Body = "<h1>Seu alienígena foi cadastrado com sucesso!</h1>"

                    });
                } 
                catch (Exception ex)
                {
                    ;
                }
            }
            return Ok(alienCriado);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteAlien(int id)
        {
            var mensagem = await _service.DeleteAlien(id);
            if (mensagem == null)
                return NotFound("Alien não encontrado!");
            return Ok(mensagem);
        }





        [HttpPut("alien/{id}")]
        public async Task<ActionResult<string>> UpdateAlien(AlienUpdateDTO request, int id)
        {
            var mensagem = await _service.UpdateAlien(request, id);
            if (request.Email != null)
            {
                try
                {
                    var response = await _smtp.SendEmail(new EmailDTO
                    {
                        To = request.Email,
                        Subject = "Alienígena atualizado com sucesso",
                        Body = "<h1>Seu alienígena foi atualizado com sucesso!</h1>"

                    });
                }
                catch (Exception ex)
                {
                    ;
                }
            }
            if (mensagem == null)
                return NotFound("Alien não encontrado!");
            if (mensagem == "planetanotfound") return NotFound("Planeta não encontrado ou Id do planeta está ausente");
            return Ok(mensagem);
        }

        [HttpPut("alien/saidaentrada/{id}")]
        public async Task<ActionResult<string>> SaidaEntradaAlien(AlienSaidaEntradaDTO request, int id)
        {
            var mensagem = await _service.SaidaEntradaAlien(request, id);
            if (mensagem == null)
                return NotFound("Alien não encontrado!");
            return Ok(mensagem);
        }
    }
}
