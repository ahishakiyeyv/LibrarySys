using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele;

namespace Factory
{
public  class FactoryReserver
    {
        static MySqlConnection conn = null;
        public static void initialiserConn()
        {
            string pwd = "";
            string chaine = "Server=localhost;Database=bibliotheque;port=3306;User Id=root;password=" + pwd;
            conn = new MySqlConnection(chaine);
        }


        #region Reserver

        public static ArrayList getReserver()
        {
            initialiserConn();
            ArrayList listeRes = new ArrayList();
            if (conn.State != ConnectionState.Open) conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select l.*,ab.*,res.* from reserver res,livres l,abonnes ab where res.id_Livres=l.id_livre and res.id_Abon=ab.id_abo";
            MySqlDataReader dr = cmd.ExecuteReader();
            Reserver re = null;
            try
            {
                while (dr.Read())
                {
                    re = new Reserver();
                    re.Id_res = dr["id_res"].ToString();
                    re.Id_abon= dr["id_Abon"].ToString();
                    re.Id_livres = dr["id_Livres"].ToString();
                    re.Date_lim = dr["date_limite"].ToString();
                 

                    listeRes.Add(re);
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return listeRes;
        }


        public static void AjouterReserver(Reserver re)
        {
            initialiserConn();
            if (conn.State != ConnectionState.Open) conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO reserver(id_res,id_Abon,id_Livres,date_limite)VALUES(@id,@abon,@livre,@date)";
            cmd.Parameters.Add("@id", MySqlDbType.VarChar, 11);
            cmd.Parameters.Add("@abon", MySqlDbType.VarChar, 255);
            cmd.Parameters.Add("@livre", MySqlDbType.VarChar, 255);
            cmd.Parameters.Add("@date", MySqlDbType.VarChar, 255);


            cmd.Parameters["@id"].Value = re.Id_res;
            cmd.Parameters["@abon"].Value = re.Id_abon;
            cmd.Parameters["@livre"].Value = re.Id_livres;
            cmd.Parameters["@date"].Value = re.Date_lim;



            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public static void ModifierReserver(Reserver re)
        {
            try
            {
                initialiserConn();
                if (conn.State != ConnectionState.Open) conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE reserver SET id_Abon=@abon,id_Livres=@livre,date_limite=@date WHERE id_res=@id";
                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = re.Id_res;
                cmd.Parameters.Add("@abon", MySqlDbType.VarChar).Value = re.Id_abon;
                cmd.Parameters.Add("@livre", MySqlDbType.VarChar).Value = re.Id_livres;
                cmd.Parameters.Add("@date", MySqlDbType.VarChar).Value = re.Date_lim;
                

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void SupprimerReserver(Reserver re)
        {
            try
            {
                initialiserConn();
                if (conn.State != ConnectionState.Open) conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM reserver WHERE id_res=@id";
                cmd.Parameters.Add("@id", MySqlDbType.VarChar, 11).Value = re.Id_res;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static ArrayList rechercherReserver(String id_res)
        {
            Reserver re = null;
            initialiserConn();
            if (conn.State != ConnectionState.Open) conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM reserver WHERE id_res=@id";
            cmd.Parameters.Add("@id", MySqlDbType.VarChar, 11);
            cmd.Parameters["@id"].Value = id_res;

            MySqlDataReader drt = cmd.ExecuteReader();
            ArrayList listRes = new ArrayList();
            try
            {

                while (drt.Read())
                {
                    re = new Reserver();
                    re.Id_res = drt["id_res"].ToString();
                    re.Id_abon = drt["id_Abon"].ToString();
                    re.Id_livres= drt["id_Livres"].ToString();
                    re.Date_lim = drt["date_limite"].ToString();
                   


                    listRes.Add(re);
                }
                drt.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listRes;
        }

        #endregion

    }
}
