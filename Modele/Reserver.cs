using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele
{
   public class Reserver
    {
        string id_res, id_abon, id_livres, date_lim;

        public string Id_res
        {
            get { return id_res; }
            set { id_res = value; }
        }

        public string Id_abon
        {
            get { return id_abon; }
            set { id_abon = value; }
        }

        public string Id_livres
        {
            get { return id_livres; }
            set { id_livres = value; }
        }

        public string Date_lim
        {
            get { return date_lim; }
            set { date_lim = value; }
        }
        public Reserver(string id_res, string id_abon, string id_livres, string date_lim) {
            this.id_res = id_res;
            this.id_abon = id_abon;
            this.id_livres = id_livres;
            this.date_lim = date_lim;
        }
        public Reserver() { 
        }
    }
}
