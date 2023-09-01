namespace APIALiens.DTOs.PlanetaDTOs
{
    public class PlanetaDto
    {
        public int Id { get; set; }
        public required string Nome { get; set; } = string.Empty;
        public required int Populacao { get; set; } = 0;
    }
}
