using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNotasEntidadesDeNegocios
{
    public class DetalleSeccion
    {
        public int Id { get; set; }
        public int IdSeccion { get; set; }
        public int IdMateria { get; set; }
        public int IdProfesor { get; set; }
        public string NombreSeccion { get; set; }
          public string NombreMateria{ get; set; }
        public string NombreProfesor { get; set; }

        

        public DetalleSeccion() { }
        
        
        public DetalleSeccion(int pId, int PIdSeccion, int PIdMateria, int pIdProfesor, string pNombreSeccion, string pNombreMateria, string pNombreProfesor) 
        {
            Id = pId;
            IdSeccion = PIdSeccion;
            IdMateria = PIdMateria;
            IdProfesor = pIdProfesor;
            NombreSeccion = pNombreSeccion;
            NombreMateria = pNombreMateria;
            NombreProfesor = pNombreProfesor;

        }
    }
}
