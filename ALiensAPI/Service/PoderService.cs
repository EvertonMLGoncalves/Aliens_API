using APIALiens.Data;
using APIALiens.DTOs.PoderDTOs;
using APIALiens.Models;
using APIALiens.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIALiens.Service
{
    public class PoderService : IPoderService
    {
        private readonly DataContext _dataContext;
        public PoderService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<PoderDTO>> GetAllPoderes()
        {
            /*return await _dataContext.Poderes.Include(p => p.AliensQuePossuem).ToListAsync(); */
            var poderes = await _dataContext.Poderes
                .Include(p => p.AliensQuePossuem)
                .Select(p => new PoderDTO
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Descricao = p.Descricao,
                    AliensQuePossuem = p.AliensQuePossuem.Select(a => new AliensQuePossuemDTO { Id = a.Id, Nome = a.Nome }).ToList(),
                }).ToListAsync();
            return poderes;

        }

        public async Task<PoderDTO> GetPoderById(int id)
        {
            var poder = await _dataContext.Poderes
                .Include(p => p.AliensQuePossuem)
                .Select(p => new PoderDTO
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Descricao = p.Descricao,
                    AliensQuePossuem = p.AliensQuePossuem.Select(a => new AliensQuePossuemDTO { Id = a.Id, Nome = a.Nome }).ToList(),
                }).FirstOrDefaultAsync(p => p.Id == id);
            return poder;
        }

        public async Task<PoderDTO> GetPoderByNome(string nome)
        {
            var poder = await _dataContext.Poderes
                .Include(p => p.AliensQuePossuem)
                .Select(p => new PoderDTO
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Descricao = p.Descricao,
                    AliensQuePossuem = p.AliensQuePossuem.Select(a => new AliensQuePossuemDTO { Id = a.Id, Nome = a.Nome }).ToList(),
                }).FirstOrDefaultAsync(p => p.Nome.ToLower() == nome.ToLower());
            return poder;
        }

        public async Task<string> CreatePoderAsync(CreatePoderDTO poder)
        {
            var poderModel = new Poder
            {
                Nome = poder.Nome,
                Descricao = poder.Descricao,
            };
            _dataContext.Poderes.Add(poderModel);
            await _dataContext.SaveChangesAsync();
            return "Poder criado com sucesso";

        }

        public async Task<string> UpdatePoder(int id, CreatePoderDTO request)
        {
            Poder poder = await _dataContext.Poderes.FindAsync(id);
            if (poder == null)
            {
                return "PoderNotFound";
            }
            poder.Nome = request.Nome;
            poder.Descricao = request.Descricao;

            await _dataContext.SaveChangesAsync();
            return "Poder atualizado com sucesso";
        }

        public async Task<string> UpdateAliensPoder(int poderId, AlienIdsDTO alienIDs)
        {
            var update = await _dataContext.Poderes.FindAsync(poderId);
            if (update == null) return "PoderNotFound";

            update.AliensQuePossuem = alienIDs.AlienIds.Select(id => new Alien { Id = id }).ToList();


            return "Lista de aliens atualizada com sucesso";
        }

        public async Task<string> DeletePoder(int id)
        {
            var poder = await _dataContext.Poderes.FindAsync(id);
            if (poder == null) return null;
            _dataContext.Poderes.Remove(poder);
            await _dataContext.SaveChangesAsync();
            return "Poder deletado com sucesso";
        }
    }
}
