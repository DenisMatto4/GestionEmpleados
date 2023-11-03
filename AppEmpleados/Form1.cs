using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AppEmpleados
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        bool abierto = false;
        List<Job> listaJObs = new List<Job>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //string connectionString = "Data Source=79.143.90.12,54321;Initial Catalog=DenisMattoEmployees;User ID=sa;Password=123456789";
                //using (SqlConnection connection = new SqlConnection(connectionString))
                //{
                //    connection.Open();
                //    // Do something with the connection
                //    MessageBox.Show("Conexion realizada con exito!!");
                //}

                string connectionString = "Data Source=79.143.90.12,54321;Initial Catalog=DenisMattoEmployees;User ID=sa;Password=123456789";
                connection = new SqlConnection(connectionString);
                connection.Open();
                abierto = true;
                btnCerrar.Enabled = true;
                button1.Enabled = false;
                // Do something with the connection
                MessageBox.Show("Conexion realizada con exito!!");

            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
                throw;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (abierto)
                {
                    connection.Close();
                    button1.Enabled = true;
                    btnCerrar.Enabled = false;
                    MessageBox.Show("Conexion cerrada");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);

                throw;
            }
        }

        private void InsertJob()
        {
            string query = $"INSERT INTO JOBS (job_title,min_salary,max_salary) VALUES (@Value1, @Value2, @Value3); SELECT SCOPE_IDENTITY();";
            if (abierto)
            {
                decimal minimo = decimal.TryParse(txtMinimo.Text, out minimo) ? minimo : 0;
                decimal maximo = decimal.TryParse(txtMaximo.Text, out maximo) ? maximo : 0;

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Value1", txtTitulo.Text);
                command.Parameters.AddWithValue("@Value2", minimo);
                command.Parameters.AddWithValue("@Value3", maximo);

                object lastid = command.ExecuteScalar();
                int id = Convert.ToInt32(lastid);
                txtID.Text = id.ToString();
                MessageBox.Show("Insert correcto!");
            }
        }

        private void SelectJobs()
        {
            if (abierto)
            {
                string query = $"SELECT job_id,job_title,min_salary,max_salary FROM jobs;";

                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string titulo = reader.GetString(1);
                        decimal min = reader.GetDecimal(2);
                        decimal max = reader.GetDecimal(3);

                        listaJObs.Add(new Job(id, titulo, min, max));
                    }
                }
            }
            
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                InsertJob();
            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.Message);
                throw;
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                SelectJobs();
                RellenarListaJobs();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
           
        }
        private void RellenarListaJobs()
        {
            foreach (var jobs in listaJObs)
            {
                string[] data = { jobs.ID.ToString(),jobs.Titulo, jobs.Min.ToString(), jobs.Max.ToString() };
                var ls = new ListViewItem(data);
                listViewJobs.Items.Add(ls);
            }
        }

        private void listViewJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar que haya un elemento seleccionado
            if (listViewJobs.SelectedItems.Count > 0)
            {
                // Obtener el elemento seleccionado
                ListViewItem item = listViewJobs.SelectedItems[0];
                // Obtener el texto de la primera columna
                txtID.Text = item.SubItems[0].Text;
                txtTitulo.Text = item.SubItems[1].Text;
                txtMinimo.Text = item.SubItems[2].Text;
                txtMaximo.Text =  item.SubItems[3].Text;

                
            }
        }
    }
}
