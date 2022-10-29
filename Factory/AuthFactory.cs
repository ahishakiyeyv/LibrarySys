using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Modele;
using MySql.Data.MySqlClient;

namespace Factory
{
   public class AuthFactory
    {
        static MySqlConnection conn = null;
        public static void initialiserConn()
        {
            string pwd = "";
            string chaine = "Server=localhost;Database=bibliotheque;port=3306;User Id=root;password=" + pwd;
            conn = new MySqlConnection(chaine);
        }
        public static ArrayList loginUser(Users user) {
            initialiserConn();
            ArrayList listUs = new ArrayList();
            if (conn.State != ConnectionState.Open) conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from users where nom_util=@username and password=@password";
            cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = user.Nom_util;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = user.Password;
            MySqlDataReader dr = cmd.ExecuteReader();
            Users users= null;

            try {
                while (dr.Read()) {
                    users = new Users();
                    listUs.Add(users);
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ex) {
                throw ex;
            }
            return listUs;

        }

        public static ArrayList getUser()
        {
            initialiserConn();
            ArrayList listeUser = new ArrayList();
            if (conn.State != ConnectionState.Open) conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from users";
            MySqlDataReader dr = cmd.ExecuteReader();
            Users us = null;
            try
            {
                while (dr.Read())
                {
                    us = new Users();
                    us.Id_user = int.Parse(dr["id_users"].ToString());
                    us.Nom_util = dr["nom_util"].ToString();
                    us.Password = dr["password"].ToString();
                    
                    listeUser.Add(us);
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return listeUser;
        }

        public static void AjouterUser(Users us)
        {
            initialiserConn();
            if (conn.State != ConnectionState.Open) conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO users(id_users,nom_util,password)VALUES(@id,@nom,@password)";
            cmd.Parameters.Add("@id", MySqlDbType.VarChar, 11);
            cmd.Parameters.Add("@nom", MySqlDbType.VarChar, 255);
            cmd.Parameters.Add("@password", MySqlDbType.VarChar, 255);


            cmd.Parameters["@id"].Value = us.Id_user;
            cmd.Parameters["@nom"].Value = us.Nom_util;
            cmd.Parameters["@password"].Value = us.Password;
           


            cmd.ExecuteNonQuery();
            conn.Close();
        }



        public static void ModifierUser(Users us)
        {
            try
            {
                initialiserConn();
                if (conn.State != ConnectionState.Open) conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE users SET nom_util=@nom,password=@password WHERE id_users=@id";
                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = us.Id_user;
                cmd.Parameters.Add("@nom", MySqlDbType.VarChar).Value = us.Nom_util;
                cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = us.Password;
               

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SupprimerUser(Users us)
        {
            try
            {
                initialiserConn();
                if (conn.State != ConnectionState.Open) conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM users WHERE id_users=@id";
                cmd.Parameters.Add("@id", MySqlDbType.VarChar, 11).Value = us.Id_user;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static ArrayList rechercherUser(String id_users)
        {
            Users us = null;
            initialiserConn();
            if (conn.State != ConnectionState.Open) conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM users WHERE id_users=@id";
            cmd.Parameters.Add("@id", MySqlDbType.VarChar, 11);
            cmd.Parameters["@id"].Value = id_users;
            MySqlDataReader drt = cmd.ExecuteReader();
            ArrayList listUser = new ArrayList();
            try
            {

                while (drt.Read())
                {
                    us = new Users();
                    us.Id_user = int.Parse(drt["id_users"].ToString());
                    us.Nom_util = drt["nom_util"].ToString();
                    us.Password = drt["password"].ToString();
                    
                    listUser.Add(us);
                }
                drt.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listUser;
        }

    }
}
