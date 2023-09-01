namespace APIALiens.DTOs.ALienDTOs
{
    public class AlienSaidaEntradaDTO
    {
        public int Id { get; set; }

        public bool IsOnEarth { get; set; }
        public DateTime DataEntradaTerra { get; set; } = DateTime.MinValue;
        public DateTime DataSaidaTerra { get; set; } = DateTime.MinValue;
    }
}
