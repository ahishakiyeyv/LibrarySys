using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Modele;

namespace Vue
{
    public partial class UcEmprunt : UserControl
    {
        public UcEmprunt()
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

       string getIdLivre()
        {
            int inde = comboLivre.SelectedIndex;
            ArrayList listLivre = new ArrayList();
            listLivre = Factory.FactoryLivre.getLivre();
            string idlivre = ((Livres)listLivre[inde]).Id;
            return idlivre;
        }
        string getIdAbonne() {
            int ind = comboAbon.SelectedIndex;
            ArrayList listAbo = new ArrayList();
            listAbo = Factory.Factory.getAbonnes();
            string idabonner = ((Abonnes)listAbo[ind]).Id_abo;
            return idabonner;
        }

        public void afficher()
        {
            ArrayList listeEmp = new ArrayList();
            dgvEmprunt.DataSource = Factory.FactoryEmprunt.getEmprunt();
            comboLivre.DataSource = Factory.FactoryLivre.getLivre();
            comboLivre.DisplayMember = "title";
            comboAbon.DataSource = Factory.Factory.getAbonnes();
            comboAbon.DisplayMember = "nom_abo";
            getIdLivre();
            getIdAbonne();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Emprunt em = null;
            string id_emprunt = txtIdEmp.Text;
            string idLivre = getIdLivre();
            string idAbon = getIdAbonne();
            string dateRet = dateRetour.Text;
            string status = comboStatus.SelectedItem.ToString();
            em = new Emprunt(id_emprunt,idLivre,idAbon,dateRet,status);
            try
            {
                Factory.FactoryEmprunt.AjouterEmprunt(em);
                afficher();
                MessageBox.Show("Enregistrement reussi");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            afficher();
        }

        private void dgvEmprunt_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtIdEmp.Text = dgvEmprunt.CurrentRow.Cells[0].Value.ToString();
            comboLivre.Text = dgvEmprunt.CurrentRow.Cells[1].Value.ToString();
            comboAbon.Text = dgvEmprunt.CurrentRow.Cells[2].Value.ToString();
            dateRetour.Text = dgvEmprunt.CurrentRow.Cells[3].Value.ToString();
            comboStatus.Text = dgvEmprunt.CurrentRow.Cells[4].Value.ToString();
        }

        void vider() {
            txtIdEmp.Text = "";
            comboLivre.Text = "";
            comboAbon.Text = "";
            dateRetour.Text = "";
            comboStatus.Text = "";
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            Emprunt emp = null;
            string id_emprunt = txtIdEmp.Text;
            string id_Livre = getIdLivre();
            string id_Abon = getIdAbonne();
            string dateRet = dateRetour.Text;
            string status = comboStatus.SelectedItem.ToString();

            emp = new Emprunt(id_emprunt, id_Livre,id_Abon, dateRet,status);
            try
            {

                Factory.FactoryEmprunt.ModifierEmprunt(emp);
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
            Emprunt emp = null;

            string id_emprunt = txtIdEmp.Text;
            string id_Livre = getIdLivre();
            string id_Abon = getIdAbonne();
            string dateRet = dateRetour.Text;
            string status = comboStatus.SelectedItem.ToString();


            emp = new Emprunt(id_emprunt, id_Livre, id_Abon, dateRet,status);
            try
            {

                afficher();

                DialogResult R = MessageBox.Show("Voulez-vous vraiment Supprimer", "suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (R == DialogResult.Yes)
                {
                    Factory.FactoryEmprunt.SupprimerEmprunt(emp);
                    vider();
                    afficher();
                }
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

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            string id_emprunt = textRechercher.Text;
            if (textRechercher.Text != null)
            {
                dgvEmprunt.DataSource = Factory.FactoryEmprunt.rechercherEmprunt(id_emprunt);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult R = MessageBox.Show("Voulez vous vraiment vous deconnectez", "Deconnexion", MessageBoxButtons.YesNo);
            if (R == DialogResult.Yes)
            {
                //FormulaireAuthentification form = new FormulaireAuthentification();
                //this.Close();
                //form.Show();
                this.Hide();
            }
        }

        private void dgvEmprunt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap imagebmp = new Bitmap(dgvEmprunt.Width, dgvEmprunt.Height);
            dgvEmprunt.DrawToBitmap(imagebmp, new Rectangle(0, 0, dgvEmprunt.Width, dgvEmprunt.Height));
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
