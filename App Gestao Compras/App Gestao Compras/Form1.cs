using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Gestao_Compras
{
    public partial class Form1 : Form
    {
        private string connectionString;
        public Form1()
        {
            InitializeComponent();
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CasaComprasConnectionString"].ConnectionString;
            CarregarItens();
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
        private void CarregarItens()
        {
            string connectionString = "server=localhost;user=root;database=CasaCompras;password=root;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Nome, Imagem FROM Itens";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        // Adicionar coluna de imagem ao DataGridView se não existir
                        if (!dataGridViewItens.Columns.Contains("Imagem"))
                        {
                            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                            imageColumn.Name = "Imagem";
                            imageColumn.HeaderText = "Imagem";
                            dataGridViewItens.Columns.Add(imageColumn);
                        }

                        dataGridViewItens.Rows.Clear();
                        foreach (DataRow row in dt.Rows)
                        {
                            int index = dataGridViewItens.Rows.Add();
                            dataGridViewItens.Rows[index].Cells["Id"].Value = row["Id"];
                            dataGridViewItens.Rows[index].Cells["Nome"].Value = row["Nome"];

                            if (row["Imagem"] != DBNull.Value)
                            {
                                byte[] imageBytes = (byte[])row["Imagem"];
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    dataGridViewItens.Rows[index].Cells["Imagem"].Value = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                dataGridViewItens.Rows[index].Cells["Imagem"].Value = null;
                            }
                        }
                    }
                }
            }
        }
        private void btnSelecionarImagem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxImagem.Image = new Bitmap(openFileDialog.FileName);
                }
            }
        }

        private void btnAdicionarItem_Click(object sender, EventArgs e)
        {
            string nomeItem = txtNomeItem.Text;
            byte[] imagemBytes = null;

            if (pictureBoxImagem.Image != null)
            {
                imagemBytes = ImageToByteArray(pictureBoxImagem.Image);
            }

            string connectionString = "server=localhost;user=root;database=CasaCompras;password=root;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Itens (Nome, Imagem) VALUES (@Nome, @Imagem)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", nomeItem);
                    if (imagemBytes != null)
                    {
                        command.Parameters.AddWithValue("@Imagem", imagemBytes);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Imagem", DBNull.Value);
                    }
                    command.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Item adicionado com sucesso!");
            CarregarItens(); // Método para recarregar os itens no DataGridView
        }

        private void btnCriarLista_Click(object sender, EventArgs e)
        {
            string nomeLista = txtNomeLista.Text;

            if (!string.IsNullOrEmpty(nomeLista))
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = "INSERT INTO ListasCompras (NomeLista) VALUES (@NomeLista); SELECT LAST_INSERT_ID();";
                    int listaId;
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NomeLista", nomeLista);
                        conn.Open();
                        listaId = Convert.ToInt32(cmd.ExecuteScalar());
                        conn.Close();
                    }

                    foreach (var item in listBoxItensSelecionados.Items)
                    {
                        string itemNome = item.ToString();
                        using (MySqlCommand cmd = new MySqlCommand("INSERT INTO ListaItens (ListaId, ItemId, Quantidade) VALUES (@ListaId, (SELECT Id FROM Itens WHERE Nome = @ItemNome), 1)", conn))
                        {
                            cmd.Parameters.AddWithValue("@ListaId", listaId);
                            cmd.Parameters.AddWithValue("@ItemNome", itemNome);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }

                    MessageBox.Show("Lista de compras criada com sucesso!");
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira um nome para a lista de compras.");
            }
        }
    }
}
