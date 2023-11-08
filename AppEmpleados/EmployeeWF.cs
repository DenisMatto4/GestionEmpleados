using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            // TODO: esta línea de código carga datos en la tabla 'dtEmployeesLocation.EmployeesLocationView' Puede moverla o quitarla según sea necesario.
            this.employeesLocationViewTableAdapter.Fill(this.dtEmployeesLocation.EmployeesLocationView);
            // TODO: esta línea de código carga datos en la tabla 'dtLocations.locations' Puede moverla o quitarla según sea necesario.
            this.locationsTableAdapter.Fill(this.dtLocations.locations);
            // TODO: esta línea de código carga datos en la tabla 'dtEmployees.employees' Puede moverla o quitarla según sea necesario.
            this.employeesTableAdapter.Fill(this.dtEmployees.employees);
            MejorasInterfaz();
        }

        private void MejorasInterfaz()
        {
            // Establece la paleta de colores
            this.BackColor = Color.LightGray; // Cambia el color de fondo a gris claro

            DataGridViewRow row = this.dataGridViewEmployees.RowTemplate;
            row.DefaultCellStyle.BackColor = Color.Bisque;

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ClaseEmployeesDataContext dc = new ClaseEmployeesDataContext();
            var data = from employees in dc.employees
                       join j in dc.jobs
                       on employees.job_id equals j.job_id
                       //where employees.employee_id == 103
                       select new { employees.first_name,employees.last_name,j.job_title};
            //string nombre = data.FirstOrDefault();

            var data2 = from employees in dc.employees
                        select employees;

            foreach (var employee in data)
            {
                listBoxEmployees.Items.Add($"Nombre: {employee.first_name}, Apellido: {employee.last_name}, " +
                    $"Trabajo : {employee.job_title}");
            }

            var dataBis = from employees in dc.employees
                          where employees.employee_id == 103
                        select employees;
            employees empleado = dataBis.FirstOrDefault();
            empleado.salary = 100;
            empleado.first_name = "Denis";
            dc.SubmitChanges();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            RowFilterString("first_name", txtNombre.Text);
        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {
            RowFilterString("last_name", txtApellidos.Text);            
        }

        private void comboBoxCiudad_SelectedValueChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)sender;

            if(comboBox != null)
                if (comboBox.Items.Count > 0)
                    if(comboBox.SelectedValue != null)
                    {
                        int idLocationSelected = Convert.ToInt32(comboBox.SelectedValue.ToString());
                        RowFilterInt("location_id", idLocationSelected);
                    }

            MejorasInterfaz();
        }

        private void RowFilterString(string nombreCampo, string textoFiltrar)
        {
            this.dtEmployeesLocation.EmployeesLocationView.DefaultView.RowFilter = $"{nombreCampo} LIKE '{textoFiltrar}%'";
            dataGridViewEmployees.DataSource = this.dtEmployeesLocation.EmployeesLocationView;
        }

        private void RowFilterInt(string nombreCampo, int idFiltro)
        {
            this.dtEmployeesLocation.EmployeesLocationView.DefaultView.RowFilter = $"{nombreCampo} = {idFiltro}";
            dataGridViewEmployees.DataSource = this.dtEmployeesLocation.EmployeesLocationView;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {

        }
    }
}
