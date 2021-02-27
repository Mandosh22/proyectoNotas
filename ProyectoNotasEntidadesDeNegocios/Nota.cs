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
        public int IdAlumno { get; set; }
        public int IdMateria { get; set; }

        public Nota() { }
        public Nota(int pId, decimal pNotas, int pIdAlumno, int pIdMateria)
        {
            Id = pId;
            Notas = pNotas;
            IdAlumno = pIdAlumno;
            IdMateria = pIdMateria;
        }
    }
}

