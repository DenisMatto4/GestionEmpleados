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

            comboBoxCiudad.SelectedIndex = -1;
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
            this.dtEmployeesLocation.EmployeesLocationView.DefaultView.RowFilter = "";
            dataGridViewEmployees.DataSource = this.dtEmployeesLocation.EmployeesLocationView;

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            RowFilterString("first_name", txtNombre.Text);
        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {
            RowFilterApellido("last_name", txtApellidos.Text);            
        }

        private void comboBoxCiudad_SelectedValueChanged(object sender, EventArgs e)
        {
            //System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)sender;

            //if(comboBox != null)
            //    if (comboBox.Items.Count > 0)
            //        if(comboBox.SelectedValue != null)
            //        {
            //            int idLocationSelected = Convert.ToInt32(comboBox.SelectedValue.ToString());
            //            RowFilterInt("location_id", idLocationSelected);
            //        }

            //MejorasInterfaz();
        }

        private void RowFilterString(string nombreCampo, string textoFiltrar)
        {
            //this.dtEmployeesLocation.EmployeesLocationView.DefaultView.RowFilter = $"{nombreCampo} LIKE '{textoFiltrar}%'";
            //dataGridViewEmployees.DataSource = this.dtEmployeesLocation.EmployeesLocationView;

            if (!string.IsNullOrEmpty(textoFiltrar))
            {
                this.dtEmployeesLocation.EmployeesLocationView.DefaultView.RowFilter = $"{nombreCampo} LIKE '{textoFiltrar}%'";
            }
            else
            {
                if (!string.IsNullOrEmpty(txtApellidos.Text))
                {
                    if (comboBoxCiudad.SelectedValue != null)
                        this.dtEmployeesLocation.EmployeesLocationView.DefaultView.RowFilter = $"last_name LIKE '{txtApellidos.Text}%' AND location_id = {comboBoxCiudad.SelectedValue}";
                    else
                        this.dtEmployeesLocation.EmployeesLocationView.DefaultView.RowFilter = $"last_name LIKE '{txtApellidos.Text}%'";


                }
                else if (comboBoxCiudad.SelectedValue != null)
                    this.dtEmployeesLocation.EmployeesLocationView.DefaultView.RowFilter = $"location_id = {comboBoxCiudad.SelectedValue}";
                else
                    this.dtEmployeesLocation.EmployeesLocationView.DefaultView.RowFilter = "";


            }

            dataGridViewEmployees.DataSource = this.dtEmployeesLocation.EmployeesLocationView;

        }

        private void RowFilterApellido(string nombreCampo, string textoFiltrar)
        {
            if (!string.IsNullOrEmpty(textoFiltrar))
            {
                if (!string.IsNullOrEmpty(txtNombre.Text))
                    this.dtEmployeesLocation.EmployeesLocationView.DefaultView.RowFilter += $" AND {nombreCampo} LIKE '{textoFiltrar}%'";
                else if(comboBoxCiudad.SelectedValue != null)
                    this.dtEmployeesLocation.EmployeesLocationView.DefaultView.RowFilter += $" AND {nombreCampo} LIKE '{textoFiltrar}%' AND location_id = {comboBoxCiudad.SelectedValue}";

            }
            else
            {
                if (!string.IsNullOrEmpty(txtNombre.Text))
                {
                    if(comboBoxCiudad.SelectedValue != null)
                        this.dtEmployeesLocation.EmployeesLocationView.DefaultView.RowFilter = $"first_name LIKE '{txtNombre.Text}%' AND location_id = {comboBoxCiudad.SelectedValue}";
                    else
                        this.dtEmployeesLocation.EmployeesLocationView.DefaultView.RowFilter = $"first_name LIKE '{txtNombre.Text}%'";


                }else if(comboBoxCiudad.SelectedValue != null)
                    this.dtEmployeesLocation.EmployeesLocationView.DefaultView.RowFilter = $"location_id = {comboBoxCiudad.SelectedValue}";
                else
                    this.dtEmployeesLocation.EmployeesLocationView.DefaultView.RowFilter = "";

            }

            dataGridViewEmployees.DataSource = this.dtEmployeesLocation.EmployeesLocationView;

        }

        private void RowFilterInt(string nombreCampo, int idFiltro)
        {
            if(idFiltro > 0)
            {
                if(string.IsNullOrEmpty(txtNombre.Text) && string.IsNullOrEmpty(txtApellidos.Text))
                    this.dtEmployeesLocation.EmployeesLocationView.DefaultView.RowFilter = $"{nombreCampo} = {idFiltro}";
                else
                    this.dtEmployeesLocation.EmployeesLocationView.DefaultView.RowFilter += $" AND {nombreCampo} = {idFiltro}";

            }
            else
            {
                if(!string.IsNullOrEmpty(txtNombre.Text))
                    if(!string.IsNullOrEmpty(txtApellidos.Text))
                        this.dtEmployeesLocation.EmployeesLocationView.DefaultView.RowFilter = $"first_name LIKE '{txtNombre.Text}%' AND last_name LIKE '{txtApellidos.Text}%'";
                    else
                        this.dtEmployeesLocation.EmployeesLocationView.DefaultView.RowFilter = $"first_name LIKE '{txtNombre.Text}%'";
                else if(!string.IsNullOrEmpty(txtApellidos.Text))
                    this.dtEmployeesLocation.EmployeesLocationView.DefaultView.RowFilter = $"last_name LIKE '{txtApellidos.Text}%'";
                else
                    this.dtEmployeesLocation.EmployeesLocationView.DefaultView.RowFilter = "";

            }


            dataGridViewEmployees.DataSource = this.dtEmployeesLocation.EmployeesLocationView;
        }

        private void comboBoxCiudad_Validated(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)sender;

            if (comboBox != null)
                if (comboBox.Items.Count > 0)
                    if (comboBox.SelectedValue != null)
                    {
                        int idLocationSelected = Convert.ToInt32(comboBox.SelectedValue.ToString());
                        RowFilterInt("location_id", idLocationSelected);
                    }else
                        RowFilterInt("location_id", 0);

            MejorasInterfaz();
        }
    }
}
