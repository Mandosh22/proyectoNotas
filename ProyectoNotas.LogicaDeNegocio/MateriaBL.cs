using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoNotas.AccesoADatos;
using ProyectoNotasEntidadesDeNegocios;

namespace ProyectoNotas.LogicaDeNegocio
{
    public class MateriaBL
    {

        MateriaDAL materiaDAL = new MateriaDAL();

        public int InsertarMateria(Materia pMateria) 
        {
            return materiaDAL.InsertarMateria(pMateria);
        }
        public int ModificarMateria(Materia pMateria)
        {
            return materiaDAL.ModificarMateria(pMateria);
        }
        public int EliminarMateria(int pId)
        {
            return materiaDAL.EliminarMateria(pId);
        }

        public List<Materia> ObtenerMaterias()
        {
            return materiaDAL.ObtenerMaterias();
        }
    }
}
