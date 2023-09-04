using APIALiens.Data;
using APIALiens.DTOs;
using APIALiens.DTOs.ALienDTOs;
using APIALiens.DTOs.PlanetaDTOs;
using APIALiens.EmailModule;
using APIALiens.Models;
using APIALiens.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIALiens.Service
{
    public class AlienService : IAlienService
    {
        private readonly DataContext _context;

        public AlienService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AlienDTO>> GetTodosAliens()
        {
            var alien = await _context.Aliens
                .Include(a => a.Poderes)
                .Include(a => a.PlanetaNatal)
                .Select(a => new AlienDTO
                {
                    Id = a.Id,
                    Nome = a.Nome,
                    Especie = a.Especie,
                    Altura = a.Altura,
                    Idade = a.Idade,
                    IsOnEarth = a.IsOnEarth,
                    DescAlien = a.DescAlien, 
                    Email = a.Email,
                    Poderes = (List<PoderDoAlienDTO>)a.Poderes.Select(a => new PoderDoAlienDTO { Id = a.Id, Nome = a.Nome, }),
                    PlanetaNatal = new PlanetaDto
                    {
                        Id = a.PlanetaNatal.Id,
                        Nome = a.PlanetaNatal.Nome,
                        Populacao = a.PlanetaNatal.Populacao
                    }
                }).ToListAsync();
            return alien;

        }
        public async Task<AlienDTO> GetAlienById(int id)
        {
            var alien = await _context.Aliens
                .Include(a => a.Poderes)
                .Include(a => a.PlanetaNatal)
                .Select(a => new AlienDTO
                {
                    Id = a.Id,
                    Nome = a.Nome,
                    Especie = a.Especie,
                    Altura = a.Altura,
                    Idade = a.Idade,
                    DescAlien = a.DescAlien,
                    IsOnEarth = a.IsOnEarth, 
                    Email = a.Email,
                    Poderes = a.Poderes.Select(a => new PoderDoAlienDTO { Id = a.Id, Nome = a.Nome, }).ToList(),
                    PlanetaNatal = new PlanetaDto
                    {
                        Id = a.PlanetaNatal.Id,
                        Nome = a.PlanetaNatal.Nome,
                        Populacao = a.PlanetaNatal.Populacao
                    }
                }).FirstOrDefaultAsync(a => a.Id == id);
            return alien;
        }

        public async Task<Planeta> GetPlanetaByAlien(int id)
        {
            var planeta = await _context.Aliens.Include(a => a.PlanetaNatal).Select(a => a.PlanetaNatal).FirstOrDefaultAsync(a => a.Id == id);

            if (planeta == null)
                return null;
            return planeta;
        }


        public async Task<string> CreateAlien(CreateAlienDTO alien)
        {
            var alienModel = new Alien
            {
                Especie = alien.Especie,
                Nome = alien.Nome,
                Altura = alien.Altura,
                Idade = alien.Idade,
                DescAlien = alien.DescAlien,
                PlanetaId = alien.PlanetaId,
                IsOnEarth = alien.IsOnEarth, 
                Email = alien.Email,
                DataEntradaTerra = alien.DataEntradaTerra,
                DataSaidaTerra = alien.DataSaidaTerra,
            };
            _context.Aliens.Add(alienModel);
            await _context.SaveChangesAsync(); 
            return "Alien criado com sucesso";

        }
        public async Task<string> UpdateAlien(AlienUpdateDTO request, int id)
        {
            if (request.PlanetaId == 0 || request.PlanetaId == null) return "planetanotfound";
            if (await _context.Planetas.FirstOrDefaultAsync(p => p.Id == request.PlanetaId) == null) return "planetanotfound";
            Alien alien = await _context.Aliens.FirstOrDefaultAsync(a => a.Id == id);
            if (alien == null) return null;
            alien.Nome = request.Nome;
            alien.Especie = request.Especie;
            alien.Altura = request.Altura;
            alien.Idade = request.Idade;
            alien.DescAlien = request.DescAlien;
            alien.PlanetaId = request.PlanetaId; 
            alien.Email = request.Email;

            await _context.SaveChangesAsync();
            return "Alien atualizado com sucesso";
        }
        public async Task<string> DeleteAlien(int id)
        {
            var alien = await _context.Aliens.FirstOrDefaultAsync(a => a.Id == id);
            if (alien == null)
                return null;
            _context.Aliens.Remove(alien);
            await _context.SaveChangesAsync();
            return "Alien deletado";
        }



        public async Task<string> SaidaEntradaAlien(AlienSaidaEntradaDTO request, int id)
        {
            Alien alien = await _context.Aliens.FirstOrDefaultAsync(a => a.Id == id);
            if (alien == null)
                return null;
            alien.IsOnEarth = request.IsOnEarth;
            await _context.SaveChangesAsync();

            if (alien.IsOnEarth == true)
            {
                alien.DataSaidaTerra = DateTime.MinValue; 
                return "Registrada a entrada do alien na Terra";
            }
            else
            {
                alien.DataEntradaTerra = DateTime.MinValue;
                return "Registrada a saída do alien da Terra";
            }
        }
    }
}
