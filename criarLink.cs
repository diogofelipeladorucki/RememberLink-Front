using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RememberLink.localStorage;
using RememberLink.Models;
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

namespace RememberLink
{
    public partial class criarLink : Form
    {
        string categoryId;
        public criarLink(string categoryIdtoview)
        {
            InitializeComponent();
            categoryId = categoryIdtoview;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void createLink()
        {
            try
            {

                string URL = "http://localhost:3000/api/link";

                string titleLink = textBox1.Text;
                string descriptionLink = textBox3.Text;
                string linkform = textBox2.Text;


                LinksNotesRequest link = new LinksNotesRequest();
                link.titleLink = titleLink;
                link.descriptionLink = descriptionLink;
                link.link = linkform;
                link.category = categoryId;

                using (var client = new HttpClient()){

                    UserPersist data = new UserPersist();
                    var token = data.getTokenUser();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                    var loginFuncionario = JsonConvert.SerializeObject(link);

                    var content = new StringContent(loginFuncionario, Encoding.UTF8, "application/json");

                    var result = await client.PostAsync(URL, content);

                    var contents = await result.Content.ReadAsStringAsync();

                    if (result.IsSuccessStatusCode)
                    {


                        MessageBox.Show("Criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                         this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro inesperado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.ToString(), "Erro");
            }
        }

        private void criarLink_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            createLink();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
