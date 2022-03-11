using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace instal.Models
{
    public class Etudiant
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string cne { get; set; }
        public Etudiant()
        {

        }
        public Etudiant(string n, string p, string c)
        {
            this.nom = n;
            this.prenom = p;
            this.cne = c;
        }
        public void show()
        {
            Console.WriteLine("\n " + nom + "\t" + prenom + "\t" + cne);
        }
    }
}
