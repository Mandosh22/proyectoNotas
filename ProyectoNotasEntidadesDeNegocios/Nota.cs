using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNotasEntidadesDeNegocios
{
    public class Nota
    {
        public int Id { get; set; }
        public decimal Notas { get; set; }
        public Alumno Alumno { get; set; }
        public Materia Materia { get; set; }


        public Nota() { }
        public Nota(int pId, decimal pNotas, Alumno pAlumno, Materia pMateria)
        {
            Id = pId;
            Notas = pNotas;
            Alumno = pAlumno;
            Materia = pMateria;
        }
    }
}

