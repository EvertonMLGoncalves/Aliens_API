namespace APIALiens.Models
{
    public class Poder
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public List<Alien> AliensQuePossuem { get; set; }
    }
}
