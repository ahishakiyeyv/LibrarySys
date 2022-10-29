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
using Factory;
using System.Collections;


namespace Vue
{
    public partial class UcAbonnes : UserControl
    {
        public UcAbonnes()
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

        private void button8_Click(object sender, EventArgs e)
        {
            Abonnes ab = null;
            string id_abo = txtIdAbon.Text;
            string nom_abo = txtNomAbon.Text;
            string prenom_abo = txtPrenomAbon.Text;
            string sexe = "";
            foreach (Control c in groupBox.Controls)
            {
                if (((RadioButton)c).Checked)
                {
                    sexe = ((RadioButton)c).Text;
                    break;
                }
            }
            int telephone_abo = int.Parse(txtPhoneAbon.Text);
           // string etat = txtEtatAbon.Text;
            ab = new Abonnes(id_abo,nom_abo,prenom_abo,sexe,telephone_abo);
            try
            {
                Factory.Factory.AjouterAbonnes(ab);
                MessageBox.Show("Enregistrement Reussi");
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            afficherAbonner();
        }
       void afficherAbonner()
        {
            ArrayList listeAb = new ArrayList();
            dgv.DataSource = Factory.Factory.getAbonnes();
        }
       void vider()
       {
           txtIdAbon.Text = "";
           txtNomAbon.Text = "";
           txtPrenomAbon.Text = "";
           groupBox.Text = "";
           txtPhoneAbon.Text = "";
           //txtEtatAbon.Text = "";
       }

       private void button12_Click(object sender, EventArgs e)
       {
           vider();
       }

       private void button9_Click(object sender, EventArgs e)
       {
           Abonnes abo = null;
           string id_abo = txtIdAbon.Text;
           string nom_abo = txtNomAbon.Text;
           string prenom_abo = txtPrenomAbon.Text;
           string sexe = "";
           foreach (Control c in groupBox.Controls)
           {
               if (((RadioButton)c).Checked)
               {
                   sexe = ((RadioButton)c).Text;
                   break;
               }
           }
           int telephone_abo = int.Parse(txtPhoneAbon.Text);
           //string etat = txtEtatAbon.Text;
           abo = new Abonnes(id_abo,nom_abo,prenom_abo,sexe,telephone_abo);
           try
           {
              
               Factory.Factory.ModifierAbonner(abo);
               afficherAbonner();
               vider();
               MessageBox.Show("Modification Reussi!!");
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
       {
          
           txtIdAbon.Text = dgv.CurrentRow.Cells[0].Value.ToString();
           txtNomAbon.Text = dgv.CurrentRow.Cells[1].Value.ToString();
           txtPrenomAbon.Text = dgv.CurrentRow.Cells[2].Value.ToString();
           groupBox.Text = dgv.CurrentRow.Cells[3].Value.ToString();
           txtPhoneAbon.Text = dgv.CurrentRow.Cells[4].Value.ToString();
          // txtEtatAbon.Text = dgv.CurrentRow.Cells[5].Value.ToString();
       }

       private void button10_Click(object sender, EventArgs e)
       {
           Abonnes abo = null;

           string id_abo = txtIdAbon.Text;
           string nom_abo = txtNomAbon.Text;
           string prenom_abo = txtPrenomAbon.Text;
           string sexe = "";
           foreach (Control c in groupBox.Controls)
           {
               if (((RadioButton)c).Checked)
               {
                   sexe = ((RadioButton)c).Text;
                   break;
               }
           }
           int telephone_abo = int.Parse(txtPhoneAbon.Text);
          // string etat = txtEtatAbon.Text;

           abo = new Abonnes(id_abo,nom_abo,prenom_abo,sexe,telephone_abo);
           try
           {

               afficherAbonner();

               DialogResult R = MessageBox.Show("Voulez-vous vraiment Supprimer", "suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               if (R == DialogResult.Yes)
               {
                   Factory.Factory.SupprimerAbonner(abo);
                   vider();
                   afficherAbonner();
               }
           }
           catch (Exception ex)
           {

               throw ex;
           }
       }

       private void button13_Click(object sender, EventArgs e)
       {
           string id_abo = txtRechercher.Text;
           if (txtRechercher.Text != null)
           {
               dgv.DataSource = Factory.Factory.rechercherAbonner(id_abo);
           }
       }

       private void btnExport_Click(object sender, EventArgs e)
       {
           printPreviewDialog1.Document = printDocument1;
           printPreviewDialog1.PrintPreviewControl.Zoom = 1;
           printPreviewDialog1.ShowDialog();
          /* Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel._Application();
           Microsoft.Office.Interop.Excel._Workshop workbook = app.Workbooks.Add(Type.Missing);
           Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
           worksheet = workbook.Sheets["Sheet1"];
           worksheet = workbook.ActiveSheet;
           worksheet.Name = "CustomerDetail";
           for (int i = 1; i < dgv.Columns.Count + 1; i++) {
               worksheet.Cells[i, 1] = dgv.Columns[i - 1].HeaderText;
           }
           for (int i = 0; i < dgv.Rows.Count; i++) {
               for (int j = 0; j < dgv.Columns.Count; j++) {
                   worksheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
               }
           }
           var saveFileDialoge = new SaveFileDialog();
           saveFileDialoge.FileName = "output";
           saveFileDialoge.DefaultExt = ".xlsx";
           if (saveFileDialoge.ShowDialog() == DialogResult.OK)
           {
               workbook.SaveAs(saveFileDialoge.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing);
           }
           app.Quit();*/

       }

       private void panel2_Paint(object sender, PaintEventArgs e)
       {

       }

       private void btnLogout_Click(object sender, EventArgs e)
       {
           DialogResult R = MessageBox.Show("Voulez Vous vraiment vous deconnectez?", "Deconnexion", MessageBoxButtons.YesNo);
           if (R == DialogResult.Yes)
           {
              // FormulaireAuthentification form = new FormulaireAuthentification();
              // this.Close();
              // form.Show();
               this.Hide();
               
           }
       }

       private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
       {
           Bitmap imagebmp = new Bitmap(dgv.Width, dgv.Height);
           dgv.DrawToBitmap(imagebmp, new Rectangle(0, 0, dgv.Width, dgv.Height));
           e.Graphics.DrawImage(imagebmp, 120, 20);
       }
    }
}
