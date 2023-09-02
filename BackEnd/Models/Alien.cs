namespace APIALiens.Models
{
    public class Alien
    {
        public int Id { get; set; }

        public string Especie { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public int Altura { get; set; } = 0;
        public int Idade { get; set; } = 0;
        public string DescAlien { get; set; } = string.Empty;
        public int PlanetaId { get; set; }
        public bool IsOnEarth { get; set; }
        public DateTime? DataEntradaTerra { get; set; } = DateTime.MinValue;
        public DateTime? DataSaidaTerra { get; set; } = DateTime.MinValue;

        public List<Poder> Poderes { get; set; }
        public Planeta PlanetaNatal { get; set; }
    }
}
