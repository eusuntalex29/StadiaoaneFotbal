using System;
using System.Collections.Generic;

namespace StadioaneDeFotbal.Models
{
    public class Meci
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int StadionId { get; set; }
        public Stadion Stadion { get; set; }
        public int EchipaGazdaId { get; set; }
        public Echipa EchipaGazda { get; set; }
        public int EchipaOaspetiId { get; set; }
        public Echipa EchipaOaspeti { get; set; }
        public ICollection<Spectator> Spectatori { get; set; }

        public Meci()
        {
            Spectatori = new List<Spectator>();
        }
    }
}

