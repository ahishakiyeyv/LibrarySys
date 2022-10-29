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
    public partial class UcLivres : UserControl
    {
        public UcLivres()
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string id_livre = textRechercher.Text;
            if (textRechercher.Text != null)
            {
                dgvLivre.DataSource = Factory.FactoryLivre.rechercherLivre(id_livre);
            }
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

        string getIdAuteur()
        {
            int i = comboAut.SelectedIndex;
            ArrayList listAut = new ArrayList();
            listAut = Factory.FactoryAuteur.getAuteur();
            string auteur = ((Auteur)listAut[i]).Id_auteur;
            return auteur;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Livres liv = null;
            string id_livre = txtIdLiv.Text;
            string title = txtTitle.Text;
            string annee = txtAnnee.Text;
            string edition = txtEdition.Text;
            string description = txtDescription.Text;
            string quantite = txtQuantite.Text;
            //string idAuteur = comboAut.SelectedItem.ToString();
            string idAuteur = getIdAuteur();
            
            liv = new Livres(id_livre,title,annee,edition,description,quantite,idAuteur);
            try
            {
                Factory.FactoryLivre.AjouterLivre(liv);
                MessageBox.Show("Enregistrement Reussi");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void afficher()
        {
            ArrayList listeBiblio = new ArrayList();
            dgvLivre.DataSource = Factory.FactoryLivre.getLivre();
            comboAut.DataSource = Factory.FactoryAuteur.getAuteur();
            comboAut.DisplayMember = "Nom_auteur";
            getIdAuteur();
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            afficher();
        }

        private void dgvLivre_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtIdLiv.Text = dgvLivre.CurrentRow.Cells[0].Value.ToString();
            txtTitle.Text = dgvLivre.CurrentRow.Cells[1].Value.ToString();
            txtAnnee.Text = dgvLivre.CurrentRow.Cells[2].Value.ToString();
            txtEdition.Text = dgvLivre.CurrentRow.Cells[3].Value.ToString();
            txtDescription.Text = dgvLivre.CurrentRow.Cells[4].Value.ToString();
            txtQuantite.Text = dgvLivre.CurrentRow.Cells[5].Value.ToString();
            comboAut.Text = dgvLivre.CurrentRow.Cells[6].Value.ToString();
        }
        void vider() {
            txtIdLiv.Text = "";
            txtTitle.Text = "";
            txtAnnee.Text = "";
            txtEdition.Text = "";
            txtDescription.Text = "";
            txtQuantite.Text = "";
            comboAut.Text = "";
        }

        private void btnReinitialiser_Click(object sender, EventArgs e)
        {
            vider();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
           Livres liv= null;
           string id_livre = txtIdLiv.Text;
           string title = txtTitle.Text;
           string annee = txtAnnee.Text;
           string edition = txtEdition.Text;
           string description = txtDescription.Text;
           string quantite = txtQuantite.Text;
           //string idAuteur = comboAut.SelectedItem.ToString();
           string idAuteur = getIdAuteur();

           liv = new Livres(id_livre, title, annee, edition, description, quantite, idAuteur);
            try
            {

                Factory.FactoryLivre.ModifierLivre(liv);
                afficher();
                vider();
                MessageBox.Show("Modification Reussi!!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSuprimer_Click(object sender, EventArgs e)
        {
            Livres liv = null;
            string id_livre = txtIdLiv.Text;
            string title = txtTitle.Text;
            string annee = txtAnnee.Text;
            string edition = txtEdition.Text;
            string description = txtDescription.Text;
            string quantite = txtQuantite.Text;
            //string idAuteur = comboAut.SelectedItem.ToString();
            string idAuteur = getIdAuteur();

            liv = new Livres(id_livre, title, annee, edition, description, quantite, idAuteur);
            try
            {

                afficher();

                DialogResult R = MessageBox.Show("Voulez-vous vraiment Supprimer", "suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (R == DialogResult.Yes)
                {
                    Factory.FactoryLivre.SupprimerLivre(liv);
                    vider();
                    afficher();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void dgvLivre_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult R = MessageBox.Show("Voulez Vous vraiment vous deconnectez", "Deconnexion", MessageBoxButtons.YesNo);
            if (R == DialogResult.Yes)
            {
               // FormulaireAuthentification form = new FormulaireAuthentification();
               // this.Close();
                //form.Show();
                this.Hide();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap imagebmp = new Bitmap(dgvLivre.Width, dgvLivre.Height);
            dgvLivre.DrawToBitmap(imagebmp, new Rectangle(0, 0, dgvLivre.Width, dgvLivre.Height));
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
