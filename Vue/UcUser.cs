using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modele;
using System.Collections;
namespace Vue
{
    public partial class UcUser : UserControl
    {
        public UcUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UcAbonnes ucAb = new UcAbonnes();
            // ucAb.Show();
            // Visible = false;
            this.panel.Controls.Clear();
            this.panel.Controls.Add(ucAb);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UcAuteur ucAut = new UcAuteur();
            this.panel.Controls.Clear();
            this.panel.Controls.Add(ucAut);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UcBiblio ucBib = new UcBiblio();
            this.panel.Controls.Clear();
            this.panel.Controls.Add(ucBib);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UcEmprunt ucEmp = new UcEmprunt();
            this.panel.Controls.Clear();
            this.panel.Controls.Add(ucEmp);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UcLivres ucLiv = new UcLivres();
            this.panel.Controls.Clear();
            this.panel.Controls.Add(ucLiv);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UcReserver ucRes = new UcReserver();
            this.panel.Controls.Clear();
            this.panel.Controls.Add(ucRes);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            UcUser ucUs = new UcUser();
            this.panel.Controls.Clear();
            this.panel.Controls.Add(ucUs);
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Users us = null;
            int id_user = int.Parse(txtIdUs.Text);
            string nom_util = txtNomUtil.Text;
            string password = txtPass.Text;
            
            us = new Users(id_user,nom_util, password);
            try
            {
                Factory.AuthFactory.AjouterUser(us);
                MessageBox.Show("Enregistrement Reussi");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void afficher()
        {
            ArrayList listeUser = new ArrayList();
            dgvUser.DataSource = Factory.AuthFactory.getUser();
        }

        void vider()
        {
            txtIdUs.Text = "";
            txtNomUtil.Text = "";
            txtPass.Text = "";
            
        }
        private void btnModifier_Click(object sender, EventArgs e)
        {
            Users us = null;
            int id_user =int.Parse( txtIdUs.Text);
            string nom_util = txtNomUtil.Text;
            string password = txtPass.Text;
            
            us = new Users(id_user,nom_util, password);
            try
            {

                Factory.AuthFactory.ModifierUser(us);
                afficher();
                vider();
                MessageBox.Show("Modification Reussi!!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            Users us = null;

            int id_user =int.Parse(txtIdUs.Text);
            string nom_util = txtNomUtil.Text;
            string password = txtPass.Text;
            

            us = new Users(id_user,nom_util, password);
            try
            {

                afficher();

                DialogResult R = MessageBox.Show("Voulez-vous vraiment Supprimer", "suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (R == DialogResult.Yes)
                {
                    Factory.AuthFactory.SupprimerUser(us);
                    vider();
                    afficher();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            afficher();
        }

        private void btnReinitialiser_Click(object sender, EventArgs e)
        {
            vider();
        }

        private void dgvUser_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtIdUs.Text = dgvUser.CurrentRow.Cells[0].Value.ToString();
            txtNomUtil.Text = dgvUser.CurrentRow.Cells[1].Value.ToString();
            txtPass.Text = dgvUser.CurrentRow.Cells[2].Value.ToString();
           
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            string id_users = textRechercher.Text;
            if (textRechercher.Text != null)
            {
                dgvUser.DataSource = Factory.AuthFactory.rechercherUser(id_users);
            }
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textRechercher_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult R = MessageBox.Show("Voulez vous vraiment vous deconnectez", "Deconnexion", MessageBoxButtons.YesNo);
            if (R == DialogResult.Yes)
            {
               // FormulaireAuthentification form = new FormulaireAuthentification();
                //this.Close();
                //form.Show();
                this.Hide();
            }
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap imagebmp = new Bitmap(dgvUser.Width, dgvUser.Height);
            dgvUser.DrawToBitmap(imagebmp, new Rectangle(0, 0, dgvUser.Width, dgvUser.Height));
            e.Graphics.DrawImage(imagebmp, 120, 20);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
