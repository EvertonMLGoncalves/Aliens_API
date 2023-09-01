namespace APIALiens.Models
{
    public class Planeta
    {
        public int Id { get; set; }
        public required string Nome { get; set; } = string.Empty;
        public required int Populacao { get; set; } = 0;
        public IEnumerable<Alien> AliensHabitantes { get; set; }
    }
}
