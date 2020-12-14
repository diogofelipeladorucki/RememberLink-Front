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
using Newtonsoft.Json;
using RememberLink.localStorage;
using RememberLink.Models;

namespace RememberLink
{
    public partial class CriarCategoria : Form
    {
        public CriarCategoria()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void createCategory()
        {
            try
            {

                string URL = "http://localhost:3000/api/category";

                string title = textBox3.Text;
                string color = textBox2.Text;

                Category category = new Category();
                category.descriptionCategory = title;
                category.color = color;

                using (var client = new HttpClient())
                {
                    UserPersist data = new UserPersist();
                    var token = data.getTokenUser();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                    var loginFuncionario = JsonConvert.SerializeObject(category);

                    var content = new StringContent(loginFuncionario, Encoding.UTF8, "application/json");

                    var result = await client.PostAsync(URL, content);

                    var contents = await result.Content.ReadAsStringAsync();

                    if (result.IsSuccessStatusCode)
                    {



                        DialogResult dialogResult =  MessageBox.Show("Criado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (dialogResult == DialogResult.OK)
                        {
                            this.Close();

                        }


                    }
                    else
                    {
                        MessageBox.Show("Erro ao criar Categoria", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro inesperado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void CriarCategoria_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            createCategory();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
