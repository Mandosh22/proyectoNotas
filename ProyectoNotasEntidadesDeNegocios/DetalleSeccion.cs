using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNotasEntidadesDeNegocios
{
    public class DetalleSeccion
    {
        public int Id { get; set; }
        public Seccion Seccion { get; set; }
        public Materia Materia { get; set; }
        public Profesor Profesor { get; set; }

        public DetalleSeccion() { }
        public DetalleSeccion(int pId, Seccion PSeccion, Materia PMateria, Profesor pProfesor) 
        {
            Id = pId;
            Seccion = PSeccion;
            Materia = PMateria;
            Profesor = pProfesor;
        }
    }
}
