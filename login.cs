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
using RememberLink.localStorage;

namespace RememberLink
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private async void loginUser()
        {
            try
            {

                string URL = "http://localhost:3000/api/login";

                string userName = textBox1.Text;
                string password = textBox2.Text;

                requestLogin login = new requestLogin();
                login.email = userName;
                login.passwordUser = password;

                using (var client = new HttpClient())
                {
                    var loginFuncionario = JsonConvert.SerializeObject(login);

                    var content = new StringContent(loginFuncionario, Encoding.UTF8, "application/json");

                    var result = await client.PostAsync(URL, content);

                    var contents = await result.Content.ReadAsStringAsync();

                    if (result.IsSuccessStatusCode)
                    {
                        
                        UserResponse myDeserializedClass = JsonConvert.DeserializeObject<UserResponse>(contents);

                        UserPersist data = new UserPersist();
                        data.storageUserToken(myDeserializedClass.token);
                        var token = data.getTokenUser();

                        //MessageBox.Show(token, "Logado com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();
                        var form1 = new CATEGORIA();
                        form1.Closed += (s, args) => this.Close();
                        form1.Show();

                    }
                    else
                    {
                        MessageBox.Show("Dados de acesso errados ou usuário inexistente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro inesperado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginUser();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
