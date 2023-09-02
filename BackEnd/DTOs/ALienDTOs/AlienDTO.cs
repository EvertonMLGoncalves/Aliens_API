using APIALiens.DTOs.PlanetaDTOs;

namespace APIALiens.DTOs.ALienDTOs
{
    public class AlienDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Especie { get; set; } = string.Empty;
        public int Altura { get; set; } = 0;
        public int Idade { get; set; } = 0;
        public string DescAlien { get; set; } = string.Empty;
        public bool IsOnEarth { get; set; }

        public List<PoderDoAlienDTO> Poderes { get; set; }

        public PlanetaDto PlanetaNatal { get; set; }
    }
}
