using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNotasEntidadesDeNegocios
{
    public class Seccion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Seccion() { }

        public Seccion(int pId, string pNombre) 
        {
            Id = pId;
            Nombre = pNombre;
        
        }
    }
}
