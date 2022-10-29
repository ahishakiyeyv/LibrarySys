using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele
{
   public class Users
    {
        int id_user;
        string nom_util, password;

        public int Id_user
        {
            get { return id_user; }
            set { id_user = value; }
        }
       

        public string Nom_util
        {
            get { return nom_util; }
            set { nom_util = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public Users(int id_user,string nom_util, string password)
        {
            this.id_user = id_user;
            this.nom_util = nom_util;
            this.password = password;
        }
       

        public Users()
        {
            // TODO: Complete member initialization
        }

      

       

    }
}
