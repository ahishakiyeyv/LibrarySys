using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele;
using System.Collections;
using System.Data;

namespace Factory
{
   public class FactoryLivre
    {

        static MySqlConnection conn = null;
        public static void initialiserConn()
        {
            string pwd = "";
            string chaine = "Server=localhost;Database=bibliotheque;port=3306;User Id=root;password=" + pwd;
            conn = new MySqlConnection(chaine);
        }

        #region Livres

        public static ArrayList getLivre()
        {
            initialiserConn();
            ArrayList listeLiv = new ArrayList();
            if (conn.State != ConnectionState.Open) conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from livres inner join auteur on livres.id_Auteur = auteur.id_auteur";
            MySqlDataReader dr = cmd.ExecuteReader();
            Livres liv = null;
            try
            {
                while (dr.Read())
                {
                    liv = new Livres();
                    liv.Id = dr["id_livre"].ToString();
                    liv.Title = dr["title"].ToString();
                    liv.Annee = dr["annee"].ToString();
                    liv.Edition = dr["edition"].ToString();
                    liv.Description = dr["description"].ToString();
                    liv.Quantite = dr["quantite"].ToString();
                    liv.IdAuteur = dr["id_Auteur"].ToString();

                    listeLiv.Add(liv);
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return listeLiv;
        }

        public static void AjouterLivre(Livres liv)
        {
            initialiserConn();
            if (conn.State != ConnectionState.Open) conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO livres(id_livre,title,annee,edition,description,quantite,id_auteur)VALUES(@id,@title,@anne,@edit,@desc,@quant,@idaut)";
            cmd.Parameters.Add("@id", MySqlDbType.VarChar, 11);
            cmd.Parameters.Add("@title", MySqlDbType.VarChar, 255);
            cmd.Parameters.Add("@anne", MySqlDbType.VarChar, 11);
            cmd.Parameters.Add("@edit", MySqlDbType.VarChar, 11);
            cmd.Parameters.Add("@desc", MySqlDbType.VarChar, 255);
            cmd.Parameters.Add("@quant", MySqlDbType.VarChar, 11);
            cmd.Parameters.Add("@idaut", MySqlDbType.VarChar, 11);



            cmd.Parameters["@id"].Value = liv.Id;
            cmd.Parameters["@title"].Value = liv.Title;
            cmd.Parameters["@anne"].Value = liv.Annee;
            cmd.Parameters["@edit"].Value = liv.Edition;
            cmd.Parameters["@desc"].Value = liv.Description;
            cmd.Parameters["@quant"].Value = liv.Quantite;
            cmd.Parameters["@idaut"].Value = liv.IdAuteur;



            cmd.ExecuteNonQuery();
            conn.Close();
        }



        public static void ModifierLivre(Livres liv)
        {
            try
            {
                initialiserConn();
                if (conn.State != ConnectionState.Open) conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE livres SET title=@title,annee=@anne,edition=@edit,description=@desc,quantite=@quant,id_Auteur=@aut WHERE id_livre=@id";
                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = liv.Id;
                cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = liv.Title;
                cmd.Parameters.Add("@anne", MySqlDbType.VarChar).Value = liv.Annee;
                cmd.Parameters.Add("@edit", MySqlDbType.VarChar).Value = liv.Edition;
                cmd.Parameters.Add("@desc", MySqlDbType.VarChar).Value = liv.Description;
                cmd.Parameters.Add("@quant", MySqlDbType.VarChar).Value = liv.Quantite;
                cmd.Parameters.Add("@aut", MySqlDbType.VarChar).Value = liv.IdAuteur;

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static void SupprimerLivre(Livres liv)
        {
            try
            {
                initialiserConn();
                if (conn.State != ConnectionState.Open) conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM livres WHERE id_livre=@id";
                cmd.Parameters.Add("@id", MySqlDbType.VarChar, 11).Value = liv.Id;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static ArrayList rechercherLivre(String id_livre)
        {
            Livres liv = null;
            initialiserConn();
            if (conn.State != ConnectionState.Open) conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM livres WHERE id_livre=@id";
            cmd.Parameters.Add("@id", MySqlDbType.VarChar, 11);
            cmd.Parameters["@id"].Value = id_livre;

            MySqlDataReader drt = cmd.ExecuteReader();
            ArrayList listLiv = new ArrayList();
            try
            {

                while (drt.Read())
                {
                    liv = new Livres();
                    liv.Id = drt["id_livre"].ToString();
                    liv.Title = drt["title"].ToString();
                    liv.Annee = drt["annee"].ToString();
                    liv.Edition = drt["edition"].ToString();
                    liv.Description = drt["description"].ToString();
                    liv.Quantite = drt["quantite"].ToString();
                    liv.IdAuteur = drt["id_Auteur"].ToString();
                    
                    listLiv.Add(liv);
                }
                drt.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listLiv;
        }
        #endregion
    }
}
