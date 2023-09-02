using APIALiens.DTOs.PoderDTOs;

namespace APIALiens.Service.Interfaces
{
    public interface IPoderService
    {
        Task<IEnumerable<PoderDTO>> GetAllPoderes();
        Task<PoderDTO> GetPoderById(int id);
        Task<PoderDTO> GetPoderByNome(string nome);
        Task<string> CreatePoderAsync(CreatePoderDTO poder);
        Task<string> UpdatePoder(int id, CreatePoderDTO poder);
        Task<string> DeletePoder(int id);
        Task<string> UpdateAliensPoder(int poderId, AlienIdsDTO alienIDs);
    }
}
