using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pointage
{
    public partial class Manage : Form
    {
        private static Manage ManageFrm;
        static void ManageFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ManageFrm = null;
        }
        public static Manage getManageFrm
        { 
            get
            {
                if (ManageFrm == null)
                {
                    ManageFrm = new Manage();
                    ManageFrm.FormClosed += new FormClosedEventHandler(ManageFrm_FormClosed);
                }
                return ManageFrm;
            }
        }
        public Manage()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add frm = new Add();
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = dgvouvrier.SelectedRows[0].Cells[0].Value.ToString();
            string cin = dgvouvrier.SelectedRows[0].Cells[1].Value.ToString();
            pointage.Update.getUpdateFrm.txtnom.Text = name;
            pointage.Update.getUpdateFrm.txtcin.Text = cin;
            pointage.Update.getUpdateFrm.ShowDialog();
        }

        private void Manage_Load(object sender, EventArgs e)
        {
            DAL.Functions f = new DAL.Functions();
            dgvouvrier.DataSource = f.getAllWorkers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DAL.Functions f = new DAL.Functions();
            dgvouvrier.DataSource = f.getWorkersBy(txtkeyword.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DAL.Functions f = new DAL.Functions();
            dgvouvrier.DataSource = f.getWorkersBy(txtkeyword.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string cin = dgvouvrier.SelectedRows[0].Cells[1].Value.ToString();
            if(MessageBox.Show("Voulez vous vraiment supprimer cet ouvrier ?","Suppression",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                DAL.Functions f = new DAL.Functions();
                f.deleteWorker(cin);
            }
            dgvouvrier.Rows.RemoveAt(dgvouvrier.SelectedRows[0].Index);
        }
    }
}
