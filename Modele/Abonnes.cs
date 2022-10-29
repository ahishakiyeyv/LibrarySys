using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele
{
   public class Abonnes
    {
        int  telephone_abo;
        string id_abo, nom_abo, prenom_abo, etat, sexe;

        
    

        public string Id_abo
        {
            get { return id_abo; }
            set { id_abo = value; }
        }
        public string Nom_abo
        {
            get { return nom_abo; }
            set { nom_abo = value; }
        }
        public string Prenom_abo
        {
            get { return prenom_abo; }
            set { prenom_abo = value; }
        }
        public string Sexe
        {
            get { return sexe; }
            set { sexe = value; }
        }
        public int Telephone_abo
        {
            get { return telephone_abo; }
            set { telephone_abo = value; }
        }
       // public string Etat
       // {
         //   get { return etat; }
        //    set { etat = value; }
        //}

        public Abonnes(string id_abo, string nom_abo, string prenom_abo, string sexe,int telephone_abo) {
            this.id_abo = id_abo;
            this.nom_abo = nom_abo;
            this.prenom_abo = prenom_abo;
            this.sexe = sexe;
            this.telephone_abo = telephone_abo;
           // this.etat = etat;
        }
        public Abonnes() { 
        }

       // public Abonnes(string nom, string prenom, int phone, string etat)
       // {
            // TODO: Complete member initialization
        //    this.nom = nom;
        //    this.prenom = prenom;
         //   this.phone = phone;
         //   this.etat = etat;
      //  }

    }
}
