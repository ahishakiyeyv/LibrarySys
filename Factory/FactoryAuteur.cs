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
   public class FactoryAuteur
    {
        static MySqlConnection conn = null;
        public static void initialiserConn()
        {
            string pwd = "";
            string chaine = "Server=localhost;Database=bibliotheque;port=3306;User Id=root;password=" + pwd;
            conn = new MySqlConnection(chaine);
        }

        #region Auteur

        public static ArrayList getAuteur()
        {
            initialiserConn();
            ArrayList listeAut = new ArrayList();
            if (conn.State != ConnectionState.Open) conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from auteur";
            MySqlDataReader dr = cmd.ExecuteReader();
            Auteur aut = null;
            try
            {
                while (dr.Read())
                {
                    aut = new Auteur();
                    aut.Id_auteur = dr["id_auteur"].ToString();
                    aut.Nom_auteur = dr["nom_auteur"].ToString();
                   
                    listeAut.Add(aut);
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return listeAut;
        }


        public static void AjouterAuteur(Auteur aut)
        {
            initialiserConn();
            if (conn.State != ConnectionState.Open) conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO auteur(id_auteur,nom_auteur)VALUES(@id,@nom)";
            cmd.Parameters.Add("@id", MySqlDbType.VarChar, 11);
            cmd.Parameters.Add("@nom", MySqlDbType.VarChar, 255);
            

            cmd.Parameters["@id"].Value =aut.Id_auteur;
            cmd.Parameters["@nom"].Value = aut.Nom_auteur;
           


            cmd.ExecuteNonQuery();
            conn.Close();
        }



        public static void ModifierAuteur(Auteur aut)
        {
            try
            {
                initialiserConn();
                if (conn.State != ConnectionState.Open) conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE auteur SET nom_auteur=@nom WHERE id_auteur=@id";
                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = aut.Id_auteur;
                cmd.Parameters.Add("@nom", MySqlDbType.VarChar).Value = aut.Nom_auteur;
              
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static void SupprimerAuteur(Auteur aut)
        {
            try
            {
                initialiserConn();
                if (conn.State != ConnectionState.Open) conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM auteur WHERE id_auteur=@id";
                cmd.Parameters.Add("@id", MySqlDbType.VarChar, 11).Value = aut.Id_auteur;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static ArrayList rechercherAuteur(String id_auteur)
        {
            Auteur aut = null;
            initialiserConn();
            if (conn.State != ConnectionState.Open) conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM auteur WHERE id_auteur=@id";
            cmd.Parameters.Add("@id", MySqlDbType.VarChar, 11);
            cmd.Parameters["@id"].Value = id_auteur;
            
            MySqlDataReader drt = cmd.ExecuteReader();
            ArrayList listAut = new ArrayList();
            try
            {

                while (drt.Read())
                {
                    aut = new Auteur();
                    aut.Id_auteur = drt["id_auteur"].ToString();
                    aut.Nom_auteur = drt["nom_auteur"].ToString();
                    listAut.Add(aut);
                }
                drt.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listAut;
        }
        #endregion
    }
}
