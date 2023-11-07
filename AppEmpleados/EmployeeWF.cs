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
    }
}
