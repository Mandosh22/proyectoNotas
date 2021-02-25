using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoNotas.AccesoADatos;
using ProyectoNotasEntidadesDeNegocios;

namespace ProyectoNotas.LogicaDeNegocio
{
    public class DetalleSeccionBL
    {
        DetalleSeccionDAL detalleSeccionDAL = new DetalleSeccionDAL();

        public int InsertarDetalleSeccion(DetalleSeccion pDetalleSeccion)
        {
            return detalleSeccionDAL.InsertarDetalleSecciones(pDetalleSeccion);
        }
        public int ModificarDetalleSeccion(DetalleSeccion pDetalleSeccion)
        {
            return detalleSeccionDAL.ModificarDetalleSecciones(pDetalleSeccion);
        }
        public int EliminarDetalleSeccion(int pId)
        {

            return detalleSeccionDAL.EliminarDetalleSecciones(pId);
        }

        public List<DetalleSeccion> ObtenerDetalleSeccion()
        {
            return detalleSeccionDAL.ObtenerDetalleSecciones();
        }
    }
}
