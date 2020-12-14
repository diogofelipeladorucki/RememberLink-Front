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
using RememberLink.Models;

namespace RememberLink
{
    public partial class createAccount : Form
    {
        public createAccount()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async void loginUser()
        {
            try
            {

                string URL = "http://localhost:3000/api/createaccount";

                string userName = textBox1.Text;
                string email = textBox3.Text;
                string password = textBox2.Text;

                requestCreateAccount login = new requestCreateAccount();
                login.nameclient = userName;
                login.email = email;
                login.password = password;

                using (var client = new HttpClient())
                {
                    var loginFuncionario = JsonConvert.SerializeObject(login);

                    var content = new StringContent(loginFuncionario, Encoding.UTF8, "application/json");

                    var result = await client.PostAsync(URL, content);

                    var contents = await result.Content.ReadAsStringAsync();

                    if (result.IsSuccessStatusCode)
                    {

                        responseCreateAccount myDeserializedClass = JsonConvert.DeserializeObject<responseCreateAccount>(contents);

                        

                        MessageBox.Show(myDeserializedClass.msg, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if(myDeserializedClass.code == "2")
                        {
                            this.Close();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Erro ao criar usuário!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro inesperado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void createAccount_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginUser();
        }
    }
}
