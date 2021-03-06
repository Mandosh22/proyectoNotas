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
        public int IdAlumno { get; set; }
        public int IdProfesor { get; set; }
        public decimal Notas { get; set; }

        public int IdSeccion { get; set; }

        public string NombreSeccion { get; set; }

        public string NombreAlumno { get; set; }

        public string NombreProfesor { get; set; }




        public Nota() { }
        public Nota(int pId, int pIdAlumno, int pIdProfesor, decimal pNotas, int pIdSeccion,string pNombreSeccion, string pNombreAlumno, string pNombreProfesor)
        {
            Id = pId;
           
            IdAlumno = pIdAlumno;
            IdProfesor = pIdProfesor;
            Notas = pNotas;
            IdSeccion = pIdSeccion;
            NombreSeccion = pNombreSeccion;
            NombreAlumno = pNombreAlumno;
            NombreProfesor = pNombreProfesor;


        }
    }
}

