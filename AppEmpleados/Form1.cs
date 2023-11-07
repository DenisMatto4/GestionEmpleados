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
        Job jobSelected = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            abrirConexionBDD();
            RefrescarListView();
        }
        private void abrirConexionBDD()
        {
            string connectionString = "Data Source=79.143.90.12,54321;Initial Catalog=DenisMattoEmployees;User ID=sa;Password=123456789";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string connectionString = "Data Source=79.143.90.12,54321;Initial Catalog=DenisMattoEmployees;User ID=sa;Password=123456789";
                connection = new SqlConnection(connectionString);
                connection.Open();
                abierto = true;
                btnCerrar.Enabled = true;
                btnConexion.Visible = true;
                btnConexion.BackColor = System.Drawing.Color.Green;
                labelConexion.Visible = true;
                labelConexion.Text = "Conexión BDD abierta";

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
                    //MessageBox.Show("Conexion cerrada");
                    btnConexion.BackColor = System.Drawing.Color.Red;
                    labelConexion.Text = "Conexión BDD Cerrada";
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
            string query = $"INSERT INTO JOBS (job_title,min_salary,max_salary) VALUES (@Titulo, @Min, @Max); SELECT SCOPE_IDENTITY();";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                //decimal minimo = decimal.TryParse(txtMinimo.Text, out minimo) ? minimo : 0;
                decimal temp;
                decimal? minimo = decimal.TryParse(txtMinimo.Text, out temp) ? temp : (decimal?)null;
                decimal? maximo = decimal.TryParse(txtMaximo.Text, out temp) ? temp : (decimal?)null;

                // Crear los parámetros SQL
                SqlParameter[] parameters = new SqlParameter[]
                {
                        new SqlParameter("@Titulo", SqlDbType.VarChar,35) { Value =  txtTitulo.Text },
                        new SqlParameter("@Min", SqlDbType.Decimal) { Value = minimo == null ? DBNull.Value : (object)minimo },
                        new SqlParameter("@Max", SqlDbType.Decimal) { Value = maximo  == null ? DBNull.Value : (object)maximo}
                };

                command.Parameters.AddRange(parameters);
                object lastid = command.ExecuteScalar();
                int id = Convert.ToInt32(lastid);
                txtID.Text = id.ToString();

                MessageBox.Show("Insert correcto!");
                RefrescarListView();
            }               
        }

        private void SelectJobs()
        {
            listaJObs.Clear();

            string query = $"SELECT job_id,job_title,min_salary,max_salary FROM jobs;";


            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string titulo = reader.GetString(1);
                        decimal? min = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2);
                        decimal? max = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3);

                        listaJObs.Add(new Job(id, titulo, min, max));
                    }
                }                                
            }                         
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (jobSelected == null)
                    InsertJob();
                else
                    UpdateJob();
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
                RefrescarListView();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
           
        }

        private void RefrescarListView()
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
            listViewJobs.Items.Clear();
            foreach (var jobs in listaJObs)
            {
                string[] data = { jobs.ID.ToString(),jobs.Titulo, jobs.Min.ToString(), jobs.Max.ToString() };
                var ls = new ListViewItem(data);
                listViewJobs.Items.Add(ls);
            }
        }

        private void listViewJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            RellenarInfoPantalla();
        }

        private void RellenarInfoPantalla()
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
                txtMaximo.Text = item.SubItems[3].Text;

                SeleccionarTrabajoUpdate(Convert.ToInt32(txtID.Text));
            }
        }

        private void SeleccionarTrabajoUpdate(int Id)
        {
            jobSelected = new Job();
            foreach (var job in listaJObs) 
                if (job.ID == Id)
                    jobSelected = job;           
        }

        private void UpdateJob()
        {
            try
            {
                decimal temp;
                jobSelected.Titulo = txtTitulo.Text;
                jobSelected.Min = decimal.TryParse(txtMinimo.Text, out temp) ? temp : (decimal?)null;
                jobSelected.Max = decimal.TryParse(txtMaximo.Text, out temp) ? temp : (decimal?)null;


                string query = $"UPDATE jobs SET job_title = @Titulo,min_salary = @Min, max_salary = @Max WHERE job_id = @Id;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Crear los parámetros SQL
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@ID", SqlDbType.Int) { Value = jobSelected.ID },
                        new SqlParameter("@Titulo", SqlDbType.VarChar,35) { Value = jobSelected.Titulo },
                        new SqlParameter("@Min", SqlDbType.Decimal) { Value = jobSelected.Min == null ? DBNull.Value : (object)jobSelected.Min },
                        new SqlParameter("@Max", SqlDbType.Decimal) { Value = jobSelected.Max  == null ? DBNull.Value : (object)jobSelected.Max}
                    };

                    command.Parameters.AddRange(parameters);
                    command.ExecuteScalar();
                    MessageBox.Show("Update correcto!");
                    RefrescarListView();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void DeleteJob()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("¿Estás seguro de que quieres eliminar este JOB?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Delete();
                }
                else if (dialogResult == DialogResult.No)
                {
                    // El usuario hizo clic en 'No', puedes cancelar la eliminación aquí
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private void Delete()
        {
            decimal temp;
            jobSelected.Titulo = txtTitulo.Text;
            jobSelected.Min = decimal.TryParse(txtMinimo.Text, out temp) ? temp : (decimal?)null;
            jobSelected.Max = decimal.TryParse(txtMaximo.Text, out temp) ? temp : (decimal?)null;

            string query = $"DELETE FROM jobs WHERE job_id = @ID;";

            using (SqlCommand command = new SqlCommand(query, connection))
            {

                // Crear los parámetros SQL
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ID", SqlDbType.Int) { Value = jobSelected.ID }
                };

                command.Parameters.AddRange(parameters);
                command.ExecuteScalar();
                MessageBox.Show("Se ha borrado correctamente!");
                RefrescarListView();
            }
            
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DeleteJob();
        }
    }
}
