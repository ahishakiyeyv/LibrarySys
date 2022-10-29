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
    public partial class UcBiblio : UserControl
    {
        public UcBiblio()
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
            Bibliotheque bib = null;
            string id_biblio = txtIdBiblio.Text;
            string nom_biblio = txtNomBiblio.Text;
            string prenom_biblio = txtPrenomBiblio.Text;
            int telephone = int.Parse(txtPhoneBiblio.Text);
            bib = new Bibliotheque(id_biblio, nom_biblio,prenom_biblio,telephone);
            try
            {
                Factory.FactoryBiblio.AjouterBiblio(bib);
                MessageBox.Show("Enregistrement Reussi");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            afficherBiblio();

        }
        void afficherBiblio (){ 
        ArrayList listeBiblio= new ArrayList();
            dgvBiblio.DataSource = Factory.FactoryBiblio.getBiblio();
        }
        void vider() {
            txtIdBiblio.Text = "";
            txtNomBiblio.Text = "";
            txtPrenomBiblio.Text = "";
            txtPhoneBiblio.Text = "";
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            Bibliotheque bib = null;
            string id_biblio = txtIdBiblio.Text;
            string nom_biblio = txtNomBiblio.Text;
            string prenom_biblio = txtPrenomBiblio.Text;
            int telephone = int.Parse(txtPhoneBiblio.Text);

            bib = new Bibliotheque(id_biblio, nom_biblio,prenom_biblio,telephone);
            try
            {

                Factory.FactoryBiblio.ModifierBiblio(bib);
                afficherBiblio();
                vider();
                MessageBox.Show("Modification Reussi!!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnReinitialiser_Click(object sender, EventArgs e)
        {
            vider();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            Bibliotheque bib = null;

            string id_biblio = txtIdBiblio.Text;
            string nom_biblio = txtNomBiblio.Text;
            string prenom_biblio = txtPrenomBiblio.Text;
            int telephone = int.Parse(txtPhoneBiblio.Text);


            bib = new Bibliotheque(id_biblio, nom_biblio,prenom_biblio,telephone);
            try
            {

                afficherBiblio();

                DialogResult R = MessageBox.Show("Voulez-vous vraiment Supprimer", "suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (R == DialogResult.Yes)
                {
                    Factory.FactoryBiblio.SupprimerBiblio(bib);
                    vider();
                    afficherBiblio();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void dgvBiblio_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtIdBiblio.Text = dgvBiblio.CurrentRow.Cells[0].Value.ToString();
            txtNomBiblio.Text = dgvBiblio.CurrentRow.Cells[1].Value.ToString();
            txtPrenomBiblio.Text = dgvBiblio.CurrentRow.Cells[2].Value.ToString();
            txtPhoneBiblio.Text = dgvBiblio.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            string id_biblio = txtRechercher.Text;
            if (txtRechercher.Text != null)
            {
                dgvBiblio.DataSource = Factory.FactoryBiblio.rechercherBiblio(id_biblio);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UcBiblio_Load(object sender, EventArgs e)
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
            Bitmap imagebmp = new Bitmap(dgvBiblio.Width, dgvBiblio.Height);
            dgvBiblio.DrawToBitmap(imagebmp, new Rectangle(0, 0, dgvBiblio.Width, dgvBiblio.Height));
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
