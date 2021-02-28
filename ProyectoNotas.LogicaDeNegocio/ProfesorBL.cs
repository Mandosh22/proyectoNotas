using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoNotas.AccesoADatos;
using ProyectoNotasEntidadesDeNegocios;

namespace ProyectoNotas.LogicaDeNegocio
{
    public class ProfesorBL
    {
        ProfesorDAL profesorDAL = new ProfesorDAL();

        public int InsertarProfesor(Profesor pProfesor)
        {
            return profesorDAL.InsertarProfesores(pProfesor);
        }
        public int ModificarProfesor(Profesor pProfesor)
        {
            return profesorDAL.ModificarProfesores(pProfesor);
        }
        public int EliminarProfesor(int pId)
        {

            return profesorDAL.EliminarProfesores(pId);
        }

        public List<Profesor> ObtenerProfesor()
        {
            return profesorDAL.ObtenerProfesor();
        }

        public Profesor ObtenerPorId(int pId)
        {
            return profesorDAL.ObtenerPorId(pId);
        }

    }
}
