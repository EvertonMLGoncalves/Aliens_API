namespace APIALiens.DTOs.PoderDTOs
{
    public class PoderDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public List<AliensQuePossuemDTO> AliensQuePossuem { get; set; }
    }
}
