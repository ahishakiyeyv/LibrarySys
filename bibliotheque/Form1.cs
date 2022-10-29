using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;

using Modele;

namespace bibliotheque
{
    public partial class FormulaireAuthentification : Form
    {
        public FormulaireAuthentification()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            txtUtil.Focus();
           /* if (txtUtil.Text != string.Empty || txtPass.Text != string.Empty) {
                Users us = null;
               // int id_user = int.Parse(txtIdUs.Text);
                string nom_util = txtUtil.Text;
                string password = txtPass.Text;

                us = new Users(nom_util, password);
                if (txtUtil.Text == nom_util && txtPass.Text == password)
                {
                   // try
                   // {
                        Factory.AuthFactory.loginUser(us);
                        MessageBox.Show("Authentification Reussi");
                        this.Hide();
                        formulairePrincipale home = new formulairePrincipale();
                        home.ShowDialog();
                   // }
                   // catch (Exception ex)
                   // {
                    //    throw ex;
                   // }
                }
                else {
                    MessageBox.Show("Invalide Authentification");
                }
            }*/

             MySqlConnection conn = null;
            string pwd = "";
            string chaine = "Server=localhost;Database=bibliotheque;port=3306;User Id=root;password=" + pwd;
            conn = new MySqlConnection(chaine);

            string nom_util, password;
            nom_util=txtUtil.Text;
            password=txtPass.Text;
            try
            {
                string query = "SELECT * FROM users WHERE nom_util = '" + txtUtil.Text + "' AND password= '" + txtPass.Text + "'";
                MySqlDataAdapter sda = new MySqlDataAdapter(query,conn);
                DataTable dtable = new DataTable();
                sda.Fill(dtable);
                if (dtable.Rows.Count > 0)
                {
                    nom_util = txtUtil.Text;
                    password = txtPass.Text;

                    MessageBox.Show("Authentification Reussi");
                    this.Hide();
                    formulairePrincipale home = new formulairePrincipale();
                    home.ShowDialog();
                    
                }
                else {
                    MessageBox.Show("Invalide");
                }
            }
            catch
            {
                MessageBox.Show("error!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vider();
        }
        void vider()
        {
            txtUtil.Text = "";
            txtPass.Text = "";
            
        }

        private void FormulaireAuthentification_Load(object sender, EventArgs e)
        {

        }
    }
}
