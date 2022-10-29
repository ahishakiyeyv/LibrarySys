using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele
{
   public class Auteur
    {
        string id_auteur, nom_auteur;

        public string Id_auteur
        {
            get { return id_auteur; }
            set { id_auteur = value; }
        }
        public string Nom_auteur
        {
            get { return nom_auteur; }
            set { nom_auteur = value; }
        }

       public Auteur(string id_auteur,string nom_auteur){
           this.id_auteur = id_auteur;
           this.nom_auteur = nom_auteur;
       }
       public Auteur() { 
       
       }

    }
}
