using System;
using System.Collections;
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
    public partial class EmployeeWFLinq : Form
    {
        public EmployeeWFLinq()
        {
            InitializeComponent();
        }

        private void EmployeeWF_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dtLocations.locations' Puede moverla o quitarla según sea necesario.
            this.locationsTableAdapter.Fill(this.dtLocations.locations);
            MejorasInterfaz();
            CargarDataGrid();
        }
        private void CargarDataGrid()
        {
            ClaseEmployeesDataContext dc = new ClaseEmployeesDataContext();

            var data = from employees in dc.employees
                       join d in dc.departments
                       on employees.department_id equals d.department_id
                       join l in dc.locations
                       on d.location_id equals l.location_id
                       select new { employees.employee_id, employees.first_name, employees.last_name, l.city };

            dataGridViewEmployees.DataSource = data.ToList();

        }

        private void MejorasInterfaz()
        {
            // Establece la paleta de colores
            this.BackColor = Color.LightGray; // Cambia el color de fondo a gris claro

            DataGridViewRow row = this.dataGridViewEmployees.RowTemplate;
            row.DefaultCellStyle.BackColor = Color.Bisque;

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            FiltrarPorNombre(txtNombre.Text);
        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {
            FiltrarPorApellido(txtApellidos.Text);            
        }

        private void comboBoxCiudad_SelectedValueChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)sender;

            if (comboBox != null)
                if (comboBox.Items.Count > 0)
                    if (comboBox.SelectedValue != null)
                    {
                        int idLocationSelected = Convert.ToInt32(comboBox.SelectedValue.ToString());
                        RowFilterInt(idLocationSelected);
                    }

            MejorasInterfaz();
        }

        private void Filtro(string nombre,string apellidos, int locationId)
        {

            // Tu consulta LINQ
            ClaseEmployeesDataContext dc = new ClaseEmployeesDataContext();

            var data = from employees in dc.employees
                       join d in dc.departments
                       on employees.department_id equals d.department_id
                       join l in dc.locations
                       on d.location_id equals l.location_id
                       where employees.first_name.ToLower().Contains(nombre)
                       select new { employees.employee_id, employees.first_name, employees.last_name, l.city };

        }
        private void FiltrarPorNombre(string nombre)
        {
            ClaseEmployeesDataContext dc = new ClaseEmployeesDataContext();
            var data = from employees in dc.employees
                       join d in dc.departments
                       on employees.department_id equals d.department_id
                       join l in dc.locations
                       on d.location_id equals l.location_id
                       where employees.first_name.ToLower().Contains(nombre)
                       select new { employees.employee_id, employees.first_name, employees.last_name, l.city };

            dataGridViewEmployees.DataSource = data.ToList();
        }

        private void FiltrarPorApellido(string apellido)
        {
            ClaseEmployeesDataContext dc = new ClaseEmployeesDataContext();
            var data = from employees in dc.employees
                       join d in dc.departments
                       on employees.department_id equals d.department_id
                       join l in dc.locations
                       on d.location_id equals l.location_id
                       where employees.last_name.ToLower().Contains(apellido)
                       select new { employees.employee_id, employees.first_name, employees.last_name, l.city };

            dataGridViewEmployees.DataSource = data.ToList();
        }

        private void RowFilterInt(int idFiltro)
        {
            ClaseEmployeesDataContext dc = new ClaseEmployeesDataContext();
            var data = from employees in dc.employees
                       join d in dc.departments
                       on employees.department_id equals d.department_id
                       join l in dc.locations
                       on d.location_id equals l.location_id
                       where l.location_id == idFiltro
                       select new { employees.employee_id, employees.first_name, employees.last_name, l.city };

            dataGridViewEmployees.DataSource = data.ToList();
        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            txtNombre.Text = String.Empty;
            txtApellidos.Text = String.Empty;
            comboBoxCiudad.SelectedIndex = -1;
            CargarDataGrid();
        }
    }
}
