using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele;
using System.Collections;

namespace Factory
{
  public  class Factory
    {
        static MySqlConnection conn = null;
        public static void initialiserConn()
        {
            string pwd = "";
            string chaine = "Server=localhost;Database=bibliotheque;port=3306;User Id=root;password=" + pwd;
            conn = new MySqlConnection(chaine);
        }


#region abonnes

        public static ArrayList getAbonnes() {
            initialiserConn();
            ArrayList listeAb = new ArrayList();
            if (conn.State != ConnectionState.Open)conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from abonnes";
            MySqlDataReader dr = cmd.ExecuteReader();
            Abonnes abo = null;
            try
            {
                while (dr.Read())
                {
                    abo = new Abonnes();
                    abo.Id_abo =dr["id_abo"].ToString();
                    abo.Nom_abo = dr["nom_abo"].ToString();
                    abo.Prenom_abo = dr["prenom_abo"].ToString();
                    abo.Sexe = dr["sexe_abo"].ToString();
                    abo.Telephone_abo = int.Parse(dr["telephone_abo"].ToString());
                   // abo.Etat = dr["etat"].ToString();
                    listeAb.Add(abo);
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return listeAb;
        }

        public static void AjouterAbonnes(Abonnes ab) {
            initialiserConn();
            if (conn.State != ConnectionState.Open)conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO abonnes(id_abo,nom_abo,prenom_abo,sexe_abo,telephone_abo)VALUES(@id,@nom,@prenom,@sexe,@phone)";
            cmd.Parameters.Add("@id", MySqlDbType.VarChar, 11);
            cmd.Parameters.Add("@nom", MySqlDbType.VarChar, 255);
            cmd.Parameters.Add("@prenom", MySqlDbType.VarChar, 255);
            cmd.Parameters.Add("@sexe", MySqlDbType.VarChar, 255);
            cmd.Parameters.Add("@phone", MySqlDbType.Int32,11);
            //cmd.Parameters.Add("@etat", MySqlDbType.VarChar,100);

            cmd.Parameters["@id"].Value = ab.Id_abo;
            cmd.Parameters["@nom"].Value = ab.Nom_abo;
            cmd.Parameters["@prenom"].Value = ab.Prenom_abo;
            cmd.Parameters["@sexe"].Value = ab.Sexe;
            cmd.Parameters["@phone"].Value = ab.Telephone_abo;
            //cmd.Parameters["@etat"].Value = ab.Etat;


            cmd.ExecuteNonQuery();
            conn.Close();
        }



        public static void ModifierAbonner(Abonnes ab) {
            try
            {
                initialiserConn();
                if (conn.State != ConnectionState.Open) conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE abonnes SET nom_abo=@nom,prenom_abo=@prenom,sexe_abo=@sexe,telephone_abo=@phone WHERE id_abo=@id";
                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = ab.Id_abo;
                cmd.Parameters.Add("@nom", MySqlDbType.VarChar).Value = ab.Nom_abo;
                cmd.Parameters.Add("@prenom", MySqlDbType.VarChar).Value = ab.Prenom_abo;
                cmd.Parameters.Add("@sexe", MySqlDbType.VarChar).Value = ab.Sexe;
                cmd.Parameters.Add("@phone", MySqlDbType.Int32).Value = ab.Telephone_abo;
               // cmd.Parameters.Add("@etats", MySqlDbType.VarChar).Value = ab.Etat;

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SupprimerAbonner(Abonnes ab) {
            try
            {
                initialiserConn();
                if (conn.State != ConnectionState.Open) conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM abonnes WHERE id_abo=@id";
                cmd.Parameters.Add("@id", MySqlDbType.VarChar, 11).Value = ab.Id_abo;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ArrayList rechercherAbonner(String id_abo)
        {
            Abonnes abo = null;
            initialiserConn();
            if (conn.State != ConnectionState.Open) conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM abonnes WHERE id_abo=@id";
            cmd.Parameters.Add("@id", MySqlDbType.VarChar, 11);
            cmd.Parameters["@id"].Value = id_abo;
            MySqlDataReader drt = cmd.ExecuteReader();
            ArrayList listAbo = new ArrayList();
            try
            {

                while (drt.Read())
                {
                    abo = new Abonnes();
                    abo.Id_abo = drt["id_abo"].ToString();
                    abo.Nom_abo = drt["nom_abo"].ToString();
                    abo.Prenom_abo = drt["prenom_abo"].ToString();
                    abo.Sexe = drt["sexe_abo"].ToString();
                    abo.Telephone_abo =int.Parse( drt["telephone_abo"].ToString());
                   // abo.Etat = drt["etat"].ToString();
                    listAbo.Add(abo);
                }
                drt.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listAbo;
        }

#endregion
    }
}
