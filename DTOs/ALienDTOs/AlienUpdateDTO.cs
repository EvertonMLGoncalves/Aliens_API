namespace APIALiens.DTOs.ALienDTOs
{
    public class AlienUpdateDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Especie { get; set; } = string.Empty;
        public int Altura { get; set; } = 0;
        public int Idade { get; set; } = 0;
        public string DescAlien { get; set; } = string.Empty;

        public int PlanetaId { get; set; } = 0;
    }
}
