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
    public partial class Update : Form
    {
        private static Update UpdateFrm = new Update();
        public static Update getUpdateFrm
        {
            get
            {
                return UpdateFrm;
            }
        }
        public Update()
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
                if (txtnom.Text == "") errorProvider1.SetError(txtnom, "Remplir tous les champ");
                if (txtcin.Text == "") errorProvider2.SetError(txtcin, "Remplir tous les champ");
            }
            else
            {
                errorProvider1.Clear();
                errorProvider2.Clear();
                DAL.Functions f = new DAL.Functions();
                f.updateWorker(txtnom.Text, txtcin.Text);
                UpdateFrm.Close();
            }

        }
    }
}
