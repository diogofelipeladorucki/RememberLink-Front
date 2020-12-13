using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace RememberLink
{
    public partial class Form1 : Form
    {
        Thread home;
        public Form1()
        {
            InitializeComponent();
            //this.email.Text = "Enter text here...";

            /*
            if (this.email.Text == "Enter text here...")
            {
                this.email.Text = "";
            }

            if (string.IsNullOrWhiteSpace(this.email.Text)) 
            { 
                this.email.Text = "Enter text here...";
            }
            */


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // VERIFICA NO BANCO E ACESSA A HOME
            if (email.Text != "" && senha.Text != "")
            {
                this.Close();
                home = new Thread(abrirHome);
                home.SetApartmentState(ApartmentState.STA);
                home.Start();
            }
        }

        private void abrirHome(object obj)
        {
            Application.Run(new Home());
            //Application.Run(new Link());

        }

        public void RemoveText(object sender, EventArgs e)
        {
            if (this.Text == "Enter text here...")
            {
                this.Text = "";
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.Text))
                this.Text = "Enter text here...";
        }

    }
}
