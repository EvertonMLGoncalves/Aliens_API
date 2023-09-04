using APIALiens.DTOs.ALienDTOs;
using APIALiens.DTOs.PlanetaDTOs;
using APIALiens.Models;

namespace APIALiens.Service.Interfaces
{
    public interface IAlienService
    {
        Task<IEnumerable<AlienDTO>> GetTodosAliens();
        Task<AlienDTO> GetAlienById(int id);
        Task<PlanetaDto> GetPlanetaByAlienId(int id);

        Task<string> CreateAlien(CreateAlienDTO alien);
        Task<string> DeleteAlien(int id);

        Task<string> UpdateAlien(AlienUpdateDTO alien, int id);
        Task<string> SaidaEntradaAlien(AlienSaidaEntradaDTO alien, int id);
    }
}
