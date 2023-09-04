using APIALiens.DTOs.PlanetaDTOs;
using APIALiens.Models;

namespace APIALiens.Service.Interfaces
{
    public interface IPlanetaService
    {
        Task<IEnumerable<PlanetaDto>> GetAllPlanetas();
        Task<PlanetaDto> GetPlanetaById(int id);
        Task<int> GetPopulacaoPlaneta(int id);
        Task<string> CreatePlaneta(Planeta planeta);
        Task UpdatePlaneta(int id, Planeta planeta);
        Task DeletePlaneta(int id);
    }
}
