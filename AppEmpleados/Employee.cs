using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEmpleados
{
    public class Employee
    {
        private int employeeId;
        private string firstName;
        private string lastName;
        private string email;
        private string phoneNumber;
        private DateTime hireDate;
        private string jobId;
        private int? managerId;
        private int? departmentId;

        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public DateTime HireDate { get => hireDate; set => hireDate = value; }
        public string JobId { get => jobId; set => jobId = value; }
        public int? ManagerId { get => managerId; set => managerId = value; }
        public int? DepartmentId { get => departmentId; set => departmentId = value; }


        public Employee() { }

        public Employee(int employeeId, string firstName, string lastName, string email, string phoneNumber,
            DateTime hireDate, string jobId, int? managerId, int? departmentId)
        {
            this.employeeId = employeeId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.hireDate = hireDate;
            this.jobId = jobId;
            this.managerId = managerId;
            this.departmentId = departmentId;
        }
    }
}
