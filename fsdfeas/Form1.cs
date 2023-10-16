using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fsdfeas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Form2 form2;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int vyska = int.Parse(textBox1.Text);
                int sirka = int.Parse(textBox2.Text);
                bool YesNo = radioButton1.Checked;
                string color = comboBox1.Text;

                form2 = new Form2(vyska, sirka, YesNo, color);

                this.Hide();

                form2.Show();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
    }

    public partial class Form2 : Form
    {
        Button backButton = new Button();
        Button exitButton = new Button();
        int vyska_zde;
        int sirka_zde;
        bool YesNo_zde;
        string color_zde;

        public Form2(int vyska, int sirka, bool YesNo, string color)
        {
            vyska_zde = vyska;
            sirka_zde = sirka;
            YesNo_zde = YesNo;
            color_zde = color;

            this.Size = new Size(sirka, vyska);
            if (!YesNo)
            {
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
            }
            Color barva = Color.FromName(color_zde);

            this.BackColor = barva;

            backButton.Text = "Zpět";
            backButton.Location = new Point(50, 50);
            backButton.Size = new Size(100, 40);
            backButton.Click += backButton_Click;
            Controls.Add(backButton);

            exitButton.Text = "Konec";
            exitButton.Location = new Point(200, 50);
            exitButton.Size = new Size(100, 40);
            exitButton.Click += exitButton_Click;
            Controls.Add(exitButton);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (form1 != null)
            {
                form1.Show();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
