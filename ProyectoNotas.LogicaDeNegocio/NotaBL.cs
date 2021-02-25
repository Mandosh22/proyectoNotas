using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoNotas.AccesoADatos;
using ProyectoNotasEntidadesDeNegocios;

namespace ProyectoNotas.LogicaDeNegocio
{
    public class NotaBL
    {
        NotaDAL notaDAL = new NotaDAL();

        public int InsertarNota(Nota pNota)
        {
            return notaDAL.InsertarNota(pNota);
        }
        public int ModificarNota(Nota pNota)
        {
            return notaDAL.ModificarNota(pNota);
        }
        public int EliminarNota(int pId)
        {

            return notaDAL.EliminarNota(pId);
        }

        public List<Nota> ObtenerNotas()
        {
            return notaDAL.ObtenerNotas();
        }
    }
}
