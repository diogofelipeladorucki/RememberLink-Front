using Newtonsoft.Json;
using RememberLink.localStorage;
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

namespace RememberLink
{
    public partial class CATEGORIA : Form
    {
        string idToDelete;
        public CATEGORIA()
        {
            InitializeComponent();
            GetAllCategorias();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void GetAllCategorias()
        {


            try
            {
                string URL = "http://localhost:3000/api/category";

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


                            var objData = JsonConvert.DeserializeObject<List<Category>>(dataResponse);

                            dataGridView1.DataSource = objData;
                        }
                        else
                        {
                            MessageBox.Show(response.ToString());
                        }
                    }
                }
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.ToString(), "Erro");
            }

            /*DataGridViewButtonColumn button2 = new DataGridViewButtonColumn();
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

        private void CATEGORIA_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CriarCategoria categoria = new CriarCategoria();
            categoria.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            GetAllCategorias();
        }

         private void dataGridView1_CellContentClick(object sender,DataGridViewCellEventArgs e)
        {


        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string value = dataGridView1.CurrentRow.Cells["_id"].Value.ToString();
            string color = dataGridView1.CurrentRow.Cells["color"].Value.ToString();
            string descriptionCategory = dataGridView1.CurrentRow.Cells["descriptionCategory"].Value.ToString();
            idToDelete = value;

            if (e.ColumnIndex.ToString() == "2")
            {
                Home home = new Home(value, color, descriptionCategory);
                home.Show();
            }
            
        }

        private async void delete()
        {
            try
            {
                string URL = "http://localhost:3000/api/category/" + idToDelete;

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

                            GetAllCategorias();
                        }
                        else
                        {
                            MessageBox.Show("Selecione uma Categoria para exluir!");
                        }
                    }
                }
            }
            catch (ArgumentException e)
            {
                MessageBox.Show("Selecione uma Categoria para exluir!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (idToDelete == "")
            {
                MessageBox.Show("Selecione uma categoria para excluir!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                delete();
            }
        }
    }
}
