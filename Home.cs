using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RememberLink.Models;
using RememberLink.localStorage;

namespace RememberLink
{
    public partial class Home : Form
    {
        string decide;
        string colorBack;
        public Home(string id, string color)
        {
            InitializeComponent();
            decide = id;
            colorBack = color;
            this.BackColor = ColorTranslator.FromHtml(color);
            GetAllnotes();

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CriarCategoria categoria = new CriarCategoria();
            categoria.Show();
        }

        private async void GetAllnotes()
        {
            try
            {
                string URL = "http://localhost:3000/api/links/"+ decide;

                using (var client = new HttpClient())
                {
                    UserPersist data = new UserPersist();
                    var token = data.getTokenUser();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                    using (var response = await client.GetAsync(URL))
                    {
                        if (response.IsSuccessStatusCode)
                        {

                            var dataResponse = await response.Content.ReadAsStringAsync();

                            
                            var objData = JsonConvert.DeserializeObject<List<LinksNotes>>(dataResponse);

                            label1.Text = objData[0].category.descriptionCategory;

                            dataGridView1.DataSource = objData;
                        }
                        else
                        {
                            MessageBox.Show(response.ToString());
                        }
                    }
                }
            }
            catch(ArgumentException e)
            {
                MessageBox.Show(e.ToString(), "Erro");
            }
            /*DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            {
                button.Name = "APAGAR";
                button.HeaderText = "APAGAR";
                button.Text = "APAGAR";
                button.FlatStyle = FlatStyle.Flat;
                button.DefaultCellStyle.BackColor = Color.Red;
                button.DefaultCellStyle.ForeColor = Color.White;
                button.UseColumnTextForButtonValue = true;
                this.dataGridView1.Columns.Add(button);
            }
            DataGridViewButtonColumn button2 = new DataGridViewButtonColumn();
            {
                button2.Name = "EDITAR";
                button2.HeaderText = "EDITAR";
                button2.Text = "EDITAR";
                button2.FlatStyle = FlatStyle.Flat;
                button2.DefaultCellStyle.BackColor = Color.Blue;
                button2.DefaultCellStyle.ForeColor = Color.White;
                button2.UseColumnTextForButtonValue = true;
                this.dataGridView1.Columns.Add(button2);
            }
            DataGridViewButtonColumn button3 = new DataGridViewButtonColumn();
            {
                button3.Name = "DETALHAR";
                button3.HeaderText = "DETALHAR";
                button3.Text = "DETALHAR";
                button3.FlatStyle = FlatStyle.Flat;
                button3.DefaultCellStyle.BackColor = Color.Blue;
                button3.DefaultCellStyle.ForeColor = Color.White;
                button3.UseColumnTextForButtonValue = true;
                this.dataGridView1.Columns.Add(button3);
            }*/
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetAllnotes();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            criarLink link = new criarLink(decide);
            link.Show();
        }
    }
}
