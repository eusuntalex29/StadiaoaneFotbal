using System.Collections.Generic;

namespace StadioaneDeFotbal.Models
{
    public class Echipa
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Oras { get; set; }
        public ICollection<Meci> MeciuriAcasa { get; set; }
        public ICollection<Meci> MeciuriDeplasare { get; set; }

        public Echipa()
        {
            MeciuriAcasa = new List<Meci>();
            MeciuriDeplasare = new List<Meci>();
        }
    }
}

