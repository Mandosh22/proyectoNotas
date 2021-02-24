using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNotasEntidadesDeNegocios
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Materia() { }


        public Materia(int pId, string pNombre)
        {
            Id = pId;
            Nombre = pNombre;
        }
    }
}
