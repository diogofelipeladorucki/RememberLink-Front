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
        string idToDelete;
        string decide;
        string colorBack;
        string nameCategory;
        public Home(string id, string color, string nameCategoryto)
        {
            InitializeComponent();
            decide = id;
            colorBack = color;
            nameCategory = nameCategoryto;
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

                            label1.Text = nameCategory;

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
        }

        private async void delete()
        {
            try
            {
                string URL = "http://localhost:3000/api/link/" + idToDelete;

                using (var client = new HttpClient())
                {
                    UserPersist data = new UserPersist();
                    var token = data.getTokenUser();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                    using (var response = await client.DeleteAsync(URL))
                    {
                        if (response.IsSuccessStatusCode)
                        {

                            var dataResponse = await response.Content.ReadAsStringAsync();

                            responseCreateAccount myDeserializedClass = JsonConvert.DeserializeObject<responseCreateAccount>(dataResponse);

                            MessageBox.Show(myDeserializedClass.msg, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            GetAllnotes();
                        }
                        else
                        {
                            MessageBox.Show("Selecione um link para exluir!");
                        }
                    }
                }
            }
            catch (ArgumentException e)
            {
                MessageBox.Show("Selecione um link para exluir!");
            }
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(idToDelete == "")
            {
                MessageBox.Show("Selecione um link para excluir!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
            delete();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string value = dataGridView1.CurrentRow.Cells["_id"].Value.ToString();

            idToDelete = value;

        }
    }
}
