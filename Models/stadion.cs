using System.Collections.Generic;

namespace StadioaneDeFotbal.Models
{
    public class Stadion
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Oras { get; set; }
        public int Capacitate { get; set; }
        public ICollection<Meci> Meciuri { get; set; }

        public Stadion()
        {
            Meciuri = new List<Meci>();
        }
    }
}

