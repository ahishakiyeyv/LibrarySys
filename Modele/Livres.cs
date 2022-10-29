using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele
{
   public class Livres
    {
        string id, title, annee, edition, description, quantite, idAuteur;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Annee
        {
            get { return annee; }
            set { annee = value; }
        }

        public string Edition
        {
            get { return edition; }
            set { edition = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }

        public string IdAuteur
        {
            get { return idAuteur; }
            set { idAuteur = value; }
        }

        public Livres(string id, string title, string annee, string edition, string description, string quantite, string idAuteur) {
            this.id = id;
            this.title = title;
            this.annee = annee;
            this.edition = edition;
            this.description = description;
            this.quantite = quantite;
            this.idAuteur = idAuteur;
        }
        public Livres() { 
        }
    }
}
