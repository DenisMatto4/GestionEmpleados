using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEmpleados
{
    public class Job
    {
        int id;
        string titulo;
        decimal min;
        decimal max;

        public int ID { get => id; set => id = value; }
        public string Titulo { get => titulo; set => titulo = value; }

        public decimal Min { get => min; set => min = value; }

        public decimal Max { get => max; set => max = value; }

        public Job() { }    

        public Job(int id, string titulo, decimal min, decimal max)
        {
            this.id = id;
            this.titulo = titulo;
            this.min = min;
            this.max = max;
        }
    }
}
