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
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtnom.Text == "" || txtcin.Text == "")
            {
                if (txtnom.Text == "") errorProvider1.SetError(txtnom, "Remplir tous les champs");
                if (txtcin.Text == "") errorProvider1.SetError(txtcin, "Remplir tous les champs");
            }
            else
            {
                errorProvider1.Clear();
                errorProvider2.Clear();
                DAL.Functions f = new DAL.Functions();
                f.addWorker(txtnom.Text, txtcin.Text);
                MessageBox.Show("Bien ajouté", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
