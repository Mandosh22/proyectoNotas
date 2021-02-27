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
  public class SeccionDAL
    {
        //metodo permite obtener los registros almacenados en la base de datos
        public List<Seccion> ObtenerSeccion()
        {
            List<Seccion> listaSeccion = new List<Seccion>();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string ssql = "SELECT * FROM Secciones   ";
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    listaSeccion.Add(new Seccion(reader.GetInt32(0), reader.GetString(1)));
                }

                con.Close();
            }

            return listaSeccion;
        }

        //metodo que permite insertar un registro de Seccion

        public int InsertarSeccion(Seccion pSeccion)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "INSERT INTO Secciones   (Nombre) VALUES('{0}')";
                string ssql = string.Format(sentencia, pSeccion.Nombre);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }
        //metodo que permite modificar un registro de Seccion existentes

        public int ModificarSeccion(Seccion pSeccion)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "UPDATE Secciones SET Nombre = '{0}' WHERE Id = {1}";
                string ssql = string.Format(sentencia, pSeccion.Nombre, pSeccion.Id);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }
        //metodo que permite elimiar un registro de Seccion existentes

        public int EliminarSeccion(int pId)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "DELETE FROM Secciones WHERE Id = {0}";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }
        //metodo permite obtener un registros almacenado en la base de datos
        public static Seccion ObtenerSeccionPorId(int pId)
        {
            Seccion Seccion = new Seccion();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "SELECT * FROM Secciones WHERE Id = {0}";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    Seccion.Id = reader.GetInt32(0);
                    Seccion.Nombre = reader.GetString(1);
                }

                con.Close();
            }

            return Seccion;
        }
    }
}
