namespace APIALiens.DTOs.PlanetaDTOs
{
    public class UpdatePlanetaDTO
    {
        public required string Nome { get; set; } = string.Empty;
        public required int Populacao { get; set; } = 0;
    }
}
