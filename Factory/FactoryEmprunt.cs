using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Data;

namespace Factory
{
  public  class FactoryEmprunt
    {
        static MySqlConnection conn = null;
        public static void initialiserConn()
        {
            string pwd = "";
            string chaine = "Server=localhost;Database=bibliotheque;port=3306;User Id=root;password=" + pwd;
            conn = new MySqlConnection(chaine);
        }

        #region Emprunt

        public static ArrayList getEmprunt()
        {
            initialiserConn();
            ArrayList listeEmp = new ArrayList();
            if (conn.State != ConnectionState.Open) conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select l.*,ab.*,em.* from emprunter em,livres l,abonnes ab where em.id_Livre=l.id_livre and em.id_Abo=ab.id_abo";
            MySqlDataReader dr = cmd.ExecuteReader();
            Emprunt em = null;
            try
            {
                while (dr.Read())
                {
                    em = new Emprunt();
                    em.Id_emprunt = dr["id_emprunt"].ToString();
                    em.IdAbon= dr["id_Abo"].ToString();
                    em.IdLivre= dr["id_Livre"].ToString();
                    em.DateRet = dr["date_retour"].ToString();
                    em.Status= dr["statut"].ToString();

                    listeEmp.Add(em);
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return listeEmp;
        }

        public static void AjouterEmprunt(Emprunt em)
        {
            initialiserConn();
            if (conn.State != ConnectionState.Open) conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO emprunter(id_emprunt,id_Livre,id_Abo,date_retour,statut)VALUES(@id,@livre,@abon,@date,@status)";
            cmd.Parameters.Add("@id", MySqlDbType.VarChar, 11);
            cmd.Parameters.Add("@livre", MySqlDbType.VarChar, 255);
            cmd.Parameters.Add("@abon", MySqlDbType.VarChar, 255);
            cmd.Parameters.Add("@date", MySqlDbType.VarChar, 255);
            cmd.Parameters.Add("@status", MySqlDbType.VarChar, 255);


            cmd.Parameters["@id"].Value = em.Id_emprunt;
            cmd.Parameters["@livre"].Value = em.IdLivre;
            cmd.Parameters["@abon"].Value = em.IdAbon;
            cmd.Parameters["@date"].Value = em.DateRet;
            cmd.Parameters["@status"].Value = em.Status;



            cmd.ExecuteNonQuery();
            conn.Close();
        }



        public static void ModifierEmprunt(Emprunt em)
        {
            try
            {
                initialiserConn();
                if (conn.State != ConnectionState.Open) conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE emprunter SET id_Livre=@livre,id_Abo=@abon,date_retour=@date,statut=@status WHERE id_emprunt=@id";
                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = em.Id_emprunt;
                cmd.Parameters.Add("@livre", MySqlDbType.VarChar).Value = em.IdLivre;
                cmd.Parameters.Add("@abon", MySqlDbType.VarChar).Value = em.IdAbon;
                cmd.Parameters.Add("@date", MySqlDbType.VarChar).Value = em.DateRet;
                cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = em.Status;

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static void SupprimerEmprunt(Emprunt emp)
        {
            try
            {
                initialiserConn();
                if (conn.State != ConnectionState.Open) conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM emprunter WHERE id_emprunt=@id";
                cmd.Parameters.Add("@id", MySqlDbType.VarChar, 11).Value = emp.Id_emprunt;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static ArrayList rechercherEmprunt(String id_emprunt)
        {
            Emprunt em = null;
            initialiserConn();
            if (conn.State != ConnectionState.Open) conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM emprunter WHERE id_emprunt=@id";
            cmd.Parameters.Add("@id", MySqlDbType.VarChar, 11);
            cmd.Parameters["@id"].Value = id_emprunt;

            MySqlDataReader drt = cmd.ExecuteReader();
            ArrayList listEmp = new ArrayList();
            try
            {

                while (drt.Read())
                {
                   em = new Emprunt();
                    em.Id_emprunt= drt["id_emprunt"].ToString();
                    em.IdLivre = drt["id_Livre"].ToString();
                    em.IdAbon= drt["id_Abo"].ToString();
                    em.DateRet = drt["date_retour"].ToString();
                    em.Status = drt["statut"].ToString();
                    

                    listEmp.Add(em);
                }
                drt.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listEmp;
        }
        #endregion
    }
}
