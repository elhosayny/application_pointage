using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace pointage
{
    public partial class Main : Form
    {
        public int workerID;
        public ArrayList jours_labels = new ArrayList();
        public void setDaysForm(ref Button btn,int day)
        {
            btn.BackColor = Color.SlateGray;
            DAL.Functions f = new DAL.Functions();
            if (btn.Text == "")
            {
                btn.Text = "O";
                btn.ForeColor = Color.GreenYellow;
                if (f.getDayLen(workerID, day, combomois.SelectedIndex + 1, int.Parse(txtannee.Text)) == 1)
                {
                    f.updateDayStatus(workerID, day, combomois.SelectedIndex + 1, int.Parse(txtannee.Text), "yes");
                }
                else
                {
                    f.setDay(workerID, day, combomois.SelectedIndex + 1, int.Parse(txtannee.Text), "yes");
                }
            }
            else if (btn.Text == "O")
            {
                btn.Text = "X";
                btn.ForeColor = Color.Red;
                if (f.getDayLen(workerID, day, combomois.SelectedIndex + 1, int.Parse(txtannee.Text)) == 1)
                {
                    f.updateDayStatus(workerID, day, combomois.SelectedIndex + 1, int.Parse(txtannee.Text), "no");
                }
                else
                {
                    f.setDay(workerID, day, combomois.SelectedIndex + 1, int.Parse(txtannee.Text), "no");
                }
            }
            else if (btn.Text == "X")
            {
                btn.Text = "S";
                btn.BackColor = Color.Green;
                btn.ForeColor = Color.Black;
                if (f.getDayLen(workerID, day, combomois.SelectedIndex + 1, int.Parse(txtannee.Text)) == 1)
                {
                    f.updateDayStatus(workerID, day, combomois.SelectedIndex + 1, int.Parse(txtannee.Text), "sp");
                }
                else
                {
                    f.setDay(workerID, day, combomois.SelectedIndex + 1, int.Parse(txtannee.Text), "sp");
                }
            
            }
            else
            {
                btn.Text = "";
                if (f.getDayLen(workerID, day, combomois.SelectedIndex + 1, int.Parse(txtannee.Text)) == 1)
                {
                    f.deleteDay(workerID, day, combomois.SelectedIndex + 1, int.Parse(txtannee.Text));
                }
            }
        }
        public Main()
        {
            InitializeComponent();
            jours_labels.Add(jour1);
            jours_labels.Add(jour2);
            jours_labels.Add(jour3);
            jours_labels.Add(jour4);
            jours_labels.Add(jour5);
            jours_labels.Add(jour6);
            jours_labels.Add(jour7);
            jours_labels.Add(jour8);
            jours_labels.Add(jour9);
            jours_labels.Add(jour10);
            jours_labels.Add(jour11);
            jours_labels.Add(jour12);
            jours_labels.Add(jour13);
            jours_labels.Add(jour14);
            jours_labels.Add(jour15);
            jours_labels.Add(jour16);
            jours_labels.Add(jour17);
            jours_labels.Add(jour18);
            jours_labels.Add(jour19);
            jours_labels.Add(jour20);
            jours_labels.Add(jour21);
            jours_labels.Add(jour22);
            jours_labels.Add(jour23);
            jours_labels.Add(jour24);
            jours_labels.Add(jour25);
            jours_labels.Add(jour26);
            jours_labels.Add(jour27);
            jours_labels.Add(jour28);
            jours_labels.Add(jour29);
            jours_labels.Add(jour30);
            jours_labels.Add(jour31);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour2,2);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour3,3);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manage.getManageFrm.ShowDialog();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DAL.Functions f = new DAL.Functions();
            if (txtname.Text == "" && txtcin.Text == "")
            {
                errorProvider1.SetError(txtname, "Remplir au moins une seul champ");
                errorProvider2.SetError(txtcin, "Remplir au moins une seul champ");
            }
            else if (txtname.Text != "" && txtcin.Text == "")
            {
                if (f.getWorkerByNameLen(txtname.Text) != 0)
                {
                    workerID = int.Parse(f.getWorkerByName(txtname.Text).Rows[0][0].ToString());
                    txtcin.Text = f.getWorkerByName(txtname.Text).Rows[0][2].ToString();
                    txtname.Text = f.getWorkerByName(txtname.Text).Rows[0][1].ToString();
                    txtannee.Text = DateTime.Now.Year.ToString();
                    combomois.Enabled = true;
                    combomois.SelectedIndex = 0;
                }
                else MessageBox.Show("Il n'existe aucun ouvrier avec ce nom \n Merci de verifier les informations entrées ou d'entrer tous les autres informations Nom et CIN","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else if (txtname.Text == "" && txtcin.Text != "")
            {
                if (f.getWorkerByCinLen(txtcin.Text) != 0)
                {
                    workerID = int.Parse(f.getWorkerByCin(txtcin.Text).Rows[0][0].ToString());
                    txtcin.Text = f.getWorkerByCin(txtcin.Text).Rows[0][2].ToString();
                    txtname.Text = f.getWorkerByCin(txtcin.Text).Rows[0][1].ToString();
                    txtannee.Text = DateTime.Now.Year.ToString();
                    combomois.Enabled = true;
                    combomois.SelectedIndex = 0;
                }
                else MessageBox.Show("Il n'existe aucun ouvrier avec ce CIN \n Merci de verifier les informations entrées ou d'entrer tous les autres informations Nom et CIN", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (f.getWorkerLen(txtname.Text, txtcin.Text) != 0)
                {
                    workerID = int.Parse(f.getWorker(txtname.Text, txtcin.Text).Rows[0][0].ToString());
                    txtcin.Text = f.getWorker(txtname.Text, txtcin.Text).Rows[0][2].ToString();
                    txtname.Text = f.getWorker(txtname.Text, txtcin.Text).Rows[0][1].ToString();
                    txtannee.Text = DateTime.Now.Year.ToString();
                    combomois.Enabled = true;
                    combomois.SelectedIndex = 0;
                }
                else MessageBox.Show("Il n'existe aucun ouvrier avec ces informations \n Merci de verifier les informations entrées", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void jour1_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour1,1);
        }

        private void jour4_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour4,4);
        }

        private void jour5_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour5,5);
        }

        private void jour6_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour6,6);
        }

        private void jour7_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour7,7);
        }

        private void jour8_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour8,8);
        }

        private void jour9_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour9,9);
        }

        private void jour10_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour10,10);
        }

        private void jour11_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour11,11);
        }

        private void jour12_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour12,12);
        }

        private void jour13_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour13,13);
        }

        private void jour14_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour14,14);
        }

        private void jour15_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour15,15);
        }

        private void jour16_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour16,16);
        }

        private void jour17_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour17,17);
        }

        private void jour18_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour18,18);
        }

        private void jour19_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour19,19);
        }

        private void jour20_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour20,20);
        }

        private void jour21_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour21,21);
        }

        private void jour22_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour22,22);
        }

        private void jour23_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour23,23);
        }

        private void jour24_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour24,24);
        }

        private void jour25_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour25,25);
        }

        private void jour26_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour26,26);
        }

        private void jour27_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour27,27);
        }

        private void jour28_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour28,28);
        }

        private void jour29_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour29,29);
        }

        private void jour30_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour30,30);
        }

        private void jour31_Click(object sender, EventArgs e)
        {
            setDaysForm(ref jour31,31);
        }

        private void combomois_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtannee.Text == "")
            {
                errorProvider1.SetError(txtannee, "Remplir le champ");
            }
            else
            {
                errorProvider1.Clear();
                int month = combomois.SelectedIndex + 1;
                int daysInMonth = DateTime.DaysInMonth(int.Parse(txtannee.Text), month);
                int dayActive = 0;
                int daySp = 0;
                for (int i = 0; i < jours_labels.Count; i++)
                {
                    Button btn = (Button)jours_labels[i];
                    btn.Text = "";
                    if (i + 1 > daysInMonth)
                    {
                        
                        btn.BackColor = Color.Red;
                        btn.Enabled = false;
                    }
                    else
                    {
                        btn.BackColor = Color.SlateGray;
                        btn.Enabled = true;
                    }
                }
                DAL.Functions f = new DAL.Functions();
                if (f.getDaysLen(workerID,month,int.Parse(txtannee.Text)) != 0)
                {
                    DataTable dt = f.getDays(workerID, month, int.Parse(txtannee.Text));
                    for (int i = 0; i < jours_labels.Count; i++)
                    {
                        Button btn = (Button)jours_labels[i];
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            if ((i + 1) == int.Parse(dt.Rows[j][1].ToString()))
                            {
                                if (dt.Rows[j][5].ToString() == "yes")
                                {
                                    btn.Text = "O";
                                    btn.ForeColor = Color.GreenYellow;
                                    dayActive++;
                                }
                                else if (dt.Rows[j][5].ToString() == "no")
                                {
                                    btn.Text = "X";
                                    btn.ForeColor = Color.Red;
                                }
                                else if (dt.Rows[j][5].ToString() == "sp")
                                {
                                    btn.Text = "S";
                                    btn.ForeColor = Color.Black;
                                    btn.BackColor = Color.Green;
                                    daySp++;
                                }
                            }
                        }
                    }
                }
                nbrDay.Text = "Nombre de jour : "+dayActive.ToString();
                txtnbrday.Text = dayActive.ToString();
                nbrDaySp.Text = "Nombre de jour spéciale : " + daySp.ToString();
            }
        }
    }
}
