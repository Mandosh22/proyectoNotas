using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using ProyectoNotasEntidadesDeNegocios;

namespace ProyectoNotas.AccesoADatos
{
    public class AdministradorDAL
    {

        public List<Administrador> ObtenerAdministradores()
        {
            List<Administrador> listaAdministrador = new List<Administrador>();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string ssql = "SELECT * FROM Administradores";
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    listaAdministrador.Add(new Administrador(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)
                        , reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6)));
                }

                con.Close();
            }

            return listaAdministrador;
        }


        public int InsertarAdministradores(Administrador pAdministrador)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "INSERT INTO Administradores (Nombre,Apellido,Username,Contraseña,Direccion,Correo) VALUES('{0}'," +
                    "'{1}','{2}','{3}','{4}','{5}')";
                string ssql = string.Format(sentencia, pAdministrador.Nombre,pAdministrador.Apellido,pAdministrador.UserName,
                    pAdministrador.Contraseña, pAdministrador.Direccion, pAdministrador.Correo);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }



        public int ModificarAdministrador(Administrador pAdministrador)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "UPDATE Administradores SET Nombre = '{0}',Apellido='{1}',Username='{2}'," +
                    " Contraseña='{3}',Direccion='{4}',Correo='{5}' WHERE Id ='{6}'";
                string ssql = string.Format(sentencia, pAdministrador.Nombre, pAdministrador.Apellido, 
                    pAdministrador.UserName,pAdministrador.Contraseña, pAdministrador.Direccion, 
                    pAdministrador.Correo,pAdministrador.Id);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }


        //metodo que permite elimiar un registro de Administradors existentes

        public int EliminarAdministrador(int pId)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "DELETE FROM Administradores WHERE Id = {0}";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }

        //metodo permite obtener un registros almacenado en la base de datos
        public static Administrador ObtenerAdministradorPorId(int pId)
        {
            Administrador Administrador = new Administrador();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "SELECT * FROM Administradores WHERE Id = {0}";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    Administrador.Id = reader.GetInt32(0);
                    Administrador.Nombre = reader.GetString(1);
                    Administrador.Apellido = reader.GetString(2);
                    Administrador.UserName = reader.GetString(3);
                    Administrador.Contraseña = reader.GetString(4);
                    Administrador.Direccion = reader.GetString(5);
                    Administrador.Correo = reader.GetString(6);
                }

                con.Close();
            }

            return Administrador;
        }



    }
}
