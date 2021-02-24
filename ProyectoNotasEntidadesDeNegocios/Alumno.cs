using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNotasEntidadesDeNegocios
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string UserName { get; set; }
        public string Contraseña { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }

        public Seccion Seccion { get; set; }


        public Alumno() { }
        public Alumno(int pId, string pNombre, string pApellido, string pUserName, string pContraseña, string pDireccion, string pCorreo, Seccion pSeccion) 
        {
            Id = pId;
            Nombre = pNombre;
            Apellido = pApellido;
            UserName = pUserName;
            Contraseña = pContraseña;
            Direccion = pDireccion;
            Correo = pCorreo;
            Seccion = pSeccion;

        
        }

    }
}
