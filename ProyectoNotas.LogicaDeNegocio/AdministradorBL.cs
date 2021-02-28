using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using ProyectoNotas.AccesoADatos;
using ProyectoNotasEntidadesDeNegocios;
 
namespace ProyectoNotas.LogicaDeNegocio
{
    public class AdministradorBL
    {
        AdministradorDAL administradorDAL = new AdministradorDAL();

        public int InsertarAdministrador(Administrador pAdministrador)
        {
            return administradorDAL.InsertarAdministradores(pAdministrador);
        }
        public int ModificarAdministrador(Administrador pAdministrador)
        {
            return administradorDAL.ModificarAdministrador(pAdministrador);
        }
        public int EliminarAdministardor(int pId)
        {

            return administradorDAL.EliminarAdministrador(pId);
        }

        public List<Administrador> obtenerAdminstrador()
        {
            return administradorDAL.ObtenerAdministradores();
        }
        public Administrador ObtenerAdministradorPorId(int pId)
        {
            return AdministradorDAL.ObtenerAdministradorPorId(pId);
        }
    }
}
