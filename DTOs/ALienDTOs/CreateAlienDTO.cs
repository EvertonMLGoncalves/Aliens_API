namespace APIALiens.DTOs.ALienDTOs
{
    public class CreateAlienDTO
    {
        public string Especie { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public int Altura { get; set; } = 0;
        public int Idade { get; set; } = 0;
        public string DescAlien { get; set; } = string.Empty;
        public int PlanetaId { get; set; }
        public bool IsOnEarth { get; set; }
        public DateTime? DataEntradaTerra { get; set; } = DateTime.MinValue;
        public DateTime? DataSaidaTerra { get; set; } = DateTime.MinValue;
    }
}
