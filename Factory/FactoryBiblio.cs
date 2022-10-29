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
   public class FactoryBiblio
   {
       static MySqlConnection conn = null;
       public static void initialiserConn()
       {
           string pwd = "";
           string chaine = "Server=localhost;Database=bibliotheque;port=3306;User Id=root;password=" + pwd;
           conn = new MySqlConnection(chaine);
       }

       #region Bibliothecaire
       public static ArrayList getBiblio()
       {
           initialiserConn();
           ArrayList listeBiblio = new ArrayList();
           if (conn.State != ConnectionState.Open) conn.Open();
           MySqlCommand cmd = conn.CreateCommand();
           cmd.CommandText = "select * from bibliothecaire";
           MySqlDataReader dr = cmd.ExecuteReader();
           Bibliotheque bib = null;
           try
           {
               while (dr.Read())
               {
                   bib = new Bibliotheque();
                   bib.Id_biblio = dr["id_biblio"].ToString();
                   bib.Nom_biblio = dr["nom_biblio"].ToString();
                   bib.Prenom_biblio = dr["prenom_biblio"].ToString();
                   bib.Telephone = int.Parse( dr["telephone"].ToString());

                   listeBiblio.Add(bib);
               }
               dr.Close();
               conn.Close();
           }
           catch (Exception e)
           {
               throw e;
           }
           return listeBiblio;
       }



       public static void AjouterBiblio(Bibliotheque bib)
       {
           initialiserConn();
           if (conn.State != ConnectionState.Open) conn.Open();
           MySqlCommand cmd = conn.CreateCommand();
           cmd.CommandText = "INSERT INTO bibliothecaire(id_biblio,nom_biblio,prenom_biblio,telephone)VALUES(@id,@nom,@prenom,@phone)";
           cmd.Parameters.Add("@id", MySqlDbType.VarChar, 11);
           cmd.Parameters.Add("@nom", MySqlDbType.VarChar, 255);
           cmd.Parameters.Add("@prenom", MySqlDbType.VarChar, 255);
           cmd.Parameters.Add("@phone", MySqlDbType.Int32, 11);


           cmd.Parameters["@id"].Value = bib.Id_biblio;
           cmd.Parameters["@nom"].Value = bib.Nom_biblio;
           cmd.Parameters["@prenom"].Value = bib.Prenom_biblio;
           cmd.Parameters["@phone"].Value = bib.Telephone;



           cmd.ExecuteNonQuery();
           conn.Close();
       }


       public static void ModifierBiblio(Bibliotheque bib)
       {
           try
           {
               initialiserConn();
               if (conn.State != ConnectionState.Open) conn.Open();
               MySqlCommand cmd = conn.CreateCommand();
               cmd.CommandText = "UPDATE bibliothecaire SET nom_biblio=@nom,prenom_biblio=@prenom,telephone=@phone WHERE id_biblio=@id";
               cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = bib.Id_biblio;
               cmd.Parameters.Add("@nom", MySqlDbType.VarChar).Value = bib.Nom_biblio;
               cmd.Parameters.Add("@prenom", MySqlDbType.VarChar).Value = bib.Prenom_biblio;
               cmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value = bib.Telephone;

               cmd.ExecuteNonQuery();
               conn.Close();
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }



       public static void SupprimerBiblio(Bibliotheque bib)
       {
           try
           {
               initialiserConn();
               if (conn.State != ConnectionState.Open) conn.Open();
               MySqlCommand cmd = conn.CreateCommand();
               cmd.CommandText = "DELETE FROM bibliothecaire WHERE id_biblio=@id";
               cmd.Parameters.Add("@id", MySqlDbType.VarChar, 11).Value = bib.Id_biblio;

               cmd.ExecuteNonQuery();
               conn.Close();

           }
           catch (Exception ex)
           {
               throw ex;
           }
       }


       public static ArrayList rechercherBiblio(String id_biblio)
       {
         Bibliotheque bib = null;
           initialiserConn();
           if (conn.State != ConnectionState.Open) conn.Open();
           MySqlCommand cmd = conn.CreateCommand();
           cmd.CommandText = "SELECT * FROM bibliothecaire WHERE id_biblio=@id";
           cmd.Parameters.Add("@id", MySqlDbType.VarChar, 11);
           cmd.Parameters["@id"].Value = id_biblio;

           MySqlDataReader drt = cmd.ExecuteReader();
           ArrayList listBib = new ArrayList();
           try
           {

               while (drt.Read())
               {
                   bib = new Bibliotheque();
                   bib.Id_biblio= drt["id_biblio"].ToString();
                   bib.Nom_biblio = drt["nom_biblio"].ToString();
                   bib.Prenom_biblio = drt["prenom_biblio"].ToString();
                  bib.Telephone = int.Parse(drt["telephone"].ToString());
                   listBib.Add(bib);
               }
               drt.Close();
               conn.Close();
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return listBib;
       }
       #endregion
   }
}
