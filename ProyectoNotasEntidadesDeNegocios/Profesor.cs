using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNotasEntidadesDeNegocios
{
    public class Profesor
    {
        public int Id  { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string UserName { get; set; }
        public string Contraseña { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public Materia Materia { get; set; }

        public Profesor( ) { }

        public Profesor(int pId, string pNombre, string pApellido, string pUserName, string pContraseña, string pDireccion, string pCorreo, Materia pMateria) 
        {
            Id = pId;
            Nombre = pNombre;
            Apellido = pApellido;
            UserName = pUserName;
            Contraseña = pContraseña;
            Direccion = pDireccion;
            Correo = pCorreo;
            Materia = pMateria;
        }
    }
}
