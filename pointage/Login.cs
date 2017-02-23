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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtlogin.Text == "" || txtpassword.Text == "")
            {
                if (txtlogin.Text == "") errorProvider1.SetError(txtlogin, "SVP Remplir tous les champs");
                if (txtpassword.Text == "") errorProvider2.SetError(txtpassword, "SVP Remplir tous les champs");
            }
            else
            {
                errorProvider1.Clear();
                errorProvider2.Clear();
                DAL.Functions f = new DAL.Functions();
                if (f.login(txtlogin.Text, txtpassword.Text))
                {
                    Main frm = new Main();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("le nom ou le mot passe n'est pas correct","Erreur",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
