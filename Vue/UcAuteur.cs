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
    public partial class UcAuteur : UserControl
    {
        public UcAuteur()
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
            Auteur aut = null;
            string id_auteur = txtIdAut.Text;
            string nom_auteur = txtNomAut.Text;
            aut = new Auteur(id_auteur, nom_auteur);
            try
            {
                Factory.FactoryAuteur.AjouterAuteur(aut);
                MessageBox.Show("Enregistrement Reussi");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            afficherAuteur();
        }
        void afficherAuteur()
        {
            ArrayList listeAut= new ArrayList();
            dvgAuteur.DataSource = Factory.FactoryAuteur.getAuteur();
        }
        void vider() {
            txtIdAut.Text = "";
            txtNomAut.Text = "";
        }



        private void btnModifier_Click(object sender, EventArgs e)
        {
            Auteur aut = null;
            string id_auteur = txtIdAut.Text;
            string nom_auteur = txtNomAut.Text;
         
            aut = new Auteur(id_auteur, nom_auteur);
            try
            {

                Factory.FactoryAuteur.ModifierAuteur(aut);
                afficherAuteur();
                vider();
                MessageBox.Show("Modification Reussi!!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dvgAuteur_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtIdAut.Text = dvgAuteur.CurrentRow.Cells[0].Value.ToString();
            txtNomAut.Text = dvgAuteur.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnReinitialiser_Click(object sender, EventArgs e)
        {
            vider();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            Auteur aut = null;

            string id_auteur = txtIdAut.Text;
            string nom_auteur = txtNomAut.Text;
           

            aut = new Auteur(id_auteur, nom_auteur);
            try
            {

                afficherAuteur();

                DialogResult R = MessageBox.Show("Voulez-vous vraiment Supprimer", "suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (R == DialogResult.Yes)
                {
                    Factory.FactoryAuteur.SupprimerAuteur(aut);
                    vider();
                    afficherAuteur();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            string id_auteur = txtRechercher.Text;
            if (txtRechercher.Text != null)
            {
                dvgAuteur.DataSource = Factory.FactoryAuteur.rechercherAuteur(id_auteur);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult R = MessageBox.Show("Voulez Vous vraiment vous deconnectez", "Deconnexion", MessageBoxButtons.YesNo);
            if (R == DialogResult.Yes)
            {
               // FormulaireAuthentification form = new FormulaireAuthentification();
                //this.Close();
                //form.Show();
                this.Hide();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap imagebmp = new Bitmap(dvgAuteur.Width, dvgAuteur.Height);
            dvgAuteur.DrawToBitmap(imagebmp, new Rectangle(0, 0, dvgAuteur.Width, dvgAuteur.Height));
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
