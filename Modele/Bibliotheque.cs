using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele
{
   public class Bibliotheque
    {
        string id_biblio, nom_biblio, prenom_biblio;
        int telephone;

        public string Id_biblio
        {
            get { return id_biblio; }
            set { id_biblio = value; }
        }

        public string Nom_biblio
        {
            get { return nom_biblio; }
            set { nom_biblio = value; }
        }

        public string Prenom_biblio
        {
            get { return prenom_biblio; }
            set { prenom_biblio = value; }
        }
        

        public int Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        public Bibliotheque(string id_biblio, string nom_biblio, string prenom_biblio, int telephone) {
            this.id_biblio = id_biblio;
            this.nom_biblio = nom_biblio;
            this.prenom_biblio = prenom_biblio;
            this.telephone = telephone;
        }
        public Bibliotheque() { 
        }

    }
}
