using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppEmpleados
{
    public partial class EmployeeWF : Form
    {
        public EmployeeWF()
        {
            InitializeComponent();
        }
        private void Iniciar()
        {
        }

        private void EmployeeWF_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dtEmployees.employees' Puede moverla o quitarla según sea necesario.
            this.employeesTableAdapter.Fill(this.dtEmployees.employees);
            // TODO: esta línea de código carga datos en la tabla 'dtEmployees.employees' Puede moverla o quitarla según sea necesario.
            this.employeesTableAdapter.Fill(this.dtEmployees.employees);

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.employeesTableAdapter.FillBy(this.dtEmployees.employees);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            // Crear una vista de los datos.
            DataView dv = new DataView(RellenarDataTable());

            // Aplicar el filtro.
            dv.RowFilter = string.Format("first_name LIKE '%{0}%'", txtNombre.Text);

            // Asignar la vista filtrada como origen de datos del DataGridView.
            dataGridViewEmployees.DataSource = dv;
        }

        private DataTable RellenarDataTable()
        {
            //DataTable dt = new DataTable();

            //dt.Columns.Add("employee_id", typeof(int));
            //dt.Columns.Add("first_name", typeof(string));
            //dt.Columns.Add("last_name", typeof(string));
            //dt.Columns.Add("email", typeof(string));
            //dt.Columns.Add("phone_number", typeof(string));
            //dt.Columns.Add("hire_date", typeof(DateTime));
            //dt.Columns.Add("job_id", typeof(string));
            //dt.Columns.Add("manager_id", typeof(int));
            //dt.Columns.Add("department_id", typeof(int));

            //// Añadir datos a la tabla.
            //dt.Rows.Add(100, "Steven", "King", "steven.king@sqltutorial.org", "515.123.4567", 1987 - 06 - 17, 4, 26400.00, null,9);
            //dt.Rows.Add(2, "Ana", "Gómez", "ana.gomez@ejemplo.com", "098-765-4321", DateTime.Now, "JOB2", 1, 20);
            //// ... puedes añadir más filas según sea necesario.
            ///
            //return dt;


            //Crear un nuevo DataTable.
            DataTable dt = new DataTable();

            // Agregar columnas al DataTable basadas en las columnas del DataGridView.
            foreach (DataGridViewColumn column in dataGridViewEmployees.Columns)
            {
                dt.Columns.Add(column.Name, column.ValueType);
            }

            // Recorrer las filas del DataGridView.
            foreach (DataGridViewRow row in dataGridViewEmployees.Rows)
            {
                // Crear una nueva fila en el DataTable.
                DataRow dr = dt.NewRow();

                // Recorrer las celdas de la fila del DataGridView.
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // Añadir el valor de la celda a la fila del DataTable.
                    dr[cell.ColumnIndex] = cell.Value;
                }

                // Añadir la fila al DataTable.
                dt.Rows.Add(dr);
            }
            dt.Rows.Add(100, "Neena", "King", "steven.king@sqltutorial.org", "515.123.4567", DateTime.Now, 4, 26400.00, 2, 9);
            return dt;

        }
    }
}
