using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele
{
   public class Emprunt
    {
        string id_emprunt, idLivre, idAbon, status, dateRet;

        public string Id_emprunt
        {
            get { return id_emprunt; }
            set { id_emprunt = value; }
        }

        public string IdLivre
        {
            get { return idLivre; }
            set { idLivre = value; }
        }

        public string IdAbon
        {
            get { return idAbon; }
            set { idAbon = value; }
        }

        public string DateRet
        {
            get { return dateRet; }
            set { dateRet = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }


        public Emprunt(string id_emprunt,string idLivre, string idAbon, string dateRet, string status) {
            this.id_emprunt = id_emprunt;
            this.idLivre = idLivre;
            this.idAbon = idAbon;
            this.dateRet = dateRet;
            this.status = status;
        }
        public Emprunt() { 
        }
    }
}
