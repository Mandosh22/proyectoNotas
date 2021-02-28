using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNotasEntidadesDeNegocios
{
    public class Administrador
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Contraseña { get; set; }
        public string Nombre { get; set; }
        public string ApellidO { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }


        public Administrador() { }
        public Administrador(int pId, string pUserName, string pContraseña, string pNombre, string pApellidO, string pDireccion, string pCorreo)
        {
            Id = pId;
            Nombre = pNombre;
            ApellidO = pApellidO;
            Username = pUserName;
            Contraseña = pContraseña;
            Direccion = pDireccion;
            Correo = pCorreo;
        }
    }
}
