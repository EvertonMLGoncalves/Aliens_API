using APIALiens.Data;
using APIALiens.DTOs.PlanetaDTOs;
using APIALiens.Models;
using APIALiens.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIALiens.Service
{
    public class PlanetaService : IPlanetaService 
    {
        private readonly DataContext _context;

        public PlanetaService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PlanetaDto>> GetAllPlanetas()
        {
            var planetas = await _context.Planetas
                .Select(p => new PlanetaDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Populacao = p.Populacao,
                }).ToListAsync();
            return planetas;
        }

        public async Task<PlanetaDto> GetPlanetaById(int id)
        {
            var planeta = await _context.Planetas
                .Select(p => new PlanetaDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Populacao = p.Populacao,
                }).FirstOrDefaultAsync(p => p.Id == id);
            return planeta;
        }

        public async Task<int> GetPopulacaoPlaneta(int id)
        {
            var planeta = await _context.Planetas.FindAsync(id);
            if (planeta == null)
                return -1;
            return planeta.Populacao;
        }

        public async Task<string> CreatePlaneta(Planeta planeta)
        {
            _context.Planetas.Add(planeta);
            await _context.SaveChangesAsync();
            return "Planeta criado com sucesso";
        }

        public async Task UpdatePlaneta(int id, Planeta planeta)
        {

            _context.Entry(planeta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePlaneta(int id)
        {
            var planeta = await _context.Planetas.FindAsync(id);
            if (planeta == null) return;
            _context.Planetas.Remove(planeta);
            await _context.SaveChangesAsync();
        }
    }
}
