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
    public partial class UcReserver : UserControl
    {
        public UcReserver()
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
            int inde = comboLivres.SelectedIndex;
            ArrayList listLivre = new ArrayList();
            listLivre = Factory.FactoryLivre.getLivre();
            string idlivre = ((Livres)listLivre[inde]).Id;
            return idlivre;
        }

        string getIdAbonne()
        {
            int ind = comboAbonner.SelectedIndex;
            ArrayList listAbo = new ArrayList();
            listAbo = Factory.Factory.getAbonnes();
            string idabonner = ((Abonnes)listAbo[ind]).Id_abo;
            return idabonner;
        }


        public void afficher()
        {
            ArrayList listeRes = new ArrayList();
            dgvReserver.DataSource = Factory.FactoryReserver.getReserver();
            comboAbonner.DataSource = Factory.Factory.getAbonnes();
            comboAbonner.DisplayMember = "nom_abo";
            comboLivres.DataSource = Factory.FactoryLivre.getLivre();
            comboLivres.DisplayMember = "title";
            getIdAbonne();
            getIdLivre();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Reserver re = null;
            string id_res = txtIdRes.Text;
            string id_abon = getIdAbonne();
            string id_livres = getIdLivre();
            string date_lim = datelimite.Text;
            
            re = new Reserver(id_res, id_abon, id_livres, date_lim);
            try
            {
                Factory.FactoryReserver.AjouterReserver(re);
                afficher();
                MessageBox.Show("Enregistrement reussi");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void vider()
        {
            txtIdRes.Text = "";
            comboLivres.Text = "";
            comboAbonner.Text = "";
            datelimite.Text = "";
        }


        private void btnModifier_Click(object sender, EventArgs e)
        {
            Reserver res = null;
            string id_res = txtIdRes.Text;
            string id_abon = getIdAbonne();
            string id_livres = getIdLivre();
            string date_lim = datelimite.Text;
            

            res = new Reserver(id_res,id_abon, id_livres, date_lim);
            try
            {

                Factory.FactoryReserver.ModifierReserver(res);
                afficher();
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

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            afficher();
        }

        private void dgvReserver_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
             txtIdRes.Text = dgvReserver.CurrentRow.Cells[0].Value.ToString();
            comboLivres.Text = dgvReserver.CurrentRow.Cells[1].Value.ToString();
            comboAbonner.Text = dgvReserver.CurrentRow.Cells[2].Value.ToString();
            datelimite.Text = dgvReserver.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            string id_res = textRechercher.Text;
            if (textRechercher.Text != null)
            {
                dgvReserver.DataSource = Factory.FactoryReserver.rechercherReserver(id_res);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            Reserver re = null;

            string id_res = txtIdRes.Text;
            string id_abon = getIdAbonne();
            string id_livres = getIdLivre();
            string date_lim = datelimite.Text;
            


            re = new Reserver(id_res,id_abon, id_livres, date_lim);
            try
            {

                afficher();

                DialogResult R = MessageBox.Show("Voulez-vous vraiment Supprimer", "suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (R == DialogResult.Yes)
                {
                    Factory.FactoryReserver.SupprimerReserver(re);
                    vider();
                    afficher();
                }
            }
            catch (Exception ex)
            {

                throw ex;
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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap imagebmp = new Bitmap(dgvReserver.Width, dgvReserver.Height);
            dgvReserver.DrawToBitmap(imagebmp, new Rectangle(0, 0, dgvReserver.Width, dgvReserver.Height));
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
