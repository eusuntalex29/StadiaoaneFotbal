namespace StadioaneDeFotbal.Models
{
    public class Spectator
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public int MeciId { get; set; }
        public Meci Meci { get; set; }
    }
}

