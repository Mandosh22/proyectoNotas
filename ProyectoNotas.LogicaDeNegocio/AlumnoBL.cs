using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoNotas.AccesoADatos;
using ProyectoNotasEntidadesDeNegocios;

namespace ProyectoNotas.LogicaDeNegocio
{
    public class AlumnoBL
    {
        AlumnoDAL alumnoDAL = new AlumnoDAL();

        public int InsertarAlumno(Alumno pAlumno)
        {
            return alumnoDAL.InsertarAlumnos(pAlumno);
        }
        public int ModificarAlumno(Alumno pAlumno)
        {
            return alumnoDAL.ModificarAlumnos(pAlumno);
        }
        public int EliminarAlumno(int pId)
        {

            return alumnoDAL.EliminarAlumnos(pId);
        }

        public List<Alumno> ObtenerAlumnos()
        {
            return alumnoDAL.ObtenerAlumnos();
        }


        public Alumno ObtenerAlumnosPorId(int pId)
        {
            return AlumnoDAL.ObtenerAlumnosPorId(pId);
        }

        public List<Alumno> ObtenerAlumnosPorSeccion(int pId)
        {
            return alumnoDAL.ObtenerAlumnosPorSeccion(pId);
        }

    }
}
