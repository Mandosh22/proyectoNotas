using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoNotas.AccesoADatos;
using ProyectoNotasEntidadesDeNegocios;

namespace ProyectoNotas.LogicaDeNegocio
{
    public class SeccionBL
    {
        SeccionDAL seccionDAL = new SeccionDAL();

        public int InsertarSeccion(Seccion pSeccion)
        {
            return seccionDAL.InsertarSeccion(pSeccion);
        }
        public int ModificaSeccion(Seccion pSeccion)
        {
            return seccionDAL.ModificarSeccion(pSeccion);
        }
        public int EliminarSeccion(int pId)
        {

            return seccionDAL.EliminarSeccion(pId);
        }

        public List<Seccion> ObtenerSeccion()
        {
            return seccionDAL.ObtenerSeccion();
        }

        public object ObtenerPorId(int pId)
        {
            return SeccionDAL.ObtenerSeccionPorId(pId);
        }
    }
}
