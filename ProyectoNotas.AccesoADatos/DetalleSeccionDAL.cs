using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using System.Data.SqlClient;
using ProyectoNotasEntidadesDeNegocios;

//


namespace ProyectoNotas.AccesoADatos
{
    public class DetalleSeccionDAL
    {
        public List<DetalleSeccion> ObtenerDetalleSecciones()
        {
            List<DetalleSeccion> listaDetalleSeccion = new List<DetalleSeccion>();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string ssql = "SELECT dt.Id,dt.IdSeccion,dt.IdMateria,dt.IdProfesor ,s.Nombre ,m.Nombre, p.Nombre +' '+ p.Apellido as NombreProfesor   FROM Detalle_Secciones as dt" +
                            "  INNER JOIN  Secciones as s on s.Id = dt.IdSeccion" +
                             " INNER JOIN  Materias as m on m.Id =dt.IdMateria " +
                             "INNER JOIN Profesores as p on p.Id =dt.IdProfesor";
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    listaDetalleSeccion.Add(new DetalleSeccion(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3),reader.GetString(4),reader.GetString(5), reader.GetString(6)));
                }

                con.Close();
            }

            return listaDetalleSeccion;
        }



        public int InsertarDetalleSecciones(DetalleSeccion pDetalleSeccion)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "INSERT INTO Detalle_Secciones (IdSeccion,IdMateria,IdProfesor) VALUES('{0}','{1}','{2}')";
                string ssql = string.Format(sentencia, pDetalleSeccion.IdSeccion, pDetalleSeccion.IdMateria, pDetalleSeccion.IdProfesor);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }


        public int ModificarDetalleSecciones(DetalleSeccion pDetalleSeccion)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "UPDATE Detalle_Secciones SET IdSeccion = '{0}',IdMateria='{1}',IdProfesor='{2}' WHERE Id ='{3}'";
                string ssql = string.Format(sentencia, pDetalleSeccion.IdSeccion, pDetalleSeccion.IdMateria, pDetalleSeccion.IdProfesor, pDetalleSeccion.Id);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }

        //metodo que permite elimiar un registro de DetalleSecciones existentes

        public int EliminarDetalleSecciones(int pId)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "DELETE FROM Detalle_Secciones WHERE Id = {0}";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }


        public  DetalleSeccion ObtenerDetalleSeccionesPorId(int pId)
        {
            DetalleSeccion DetalleSeccion = new DetalleSeccion();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "SELECT * FROM Detalle_Secciones WHERE Id = {0}";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    DetalleSeccion.Id = reader.GetInt32(0);
                    DetalleSeccion.IdSeccion = reader.GetInt32(1);
                    DetalleSeccion.IdMateria = reader.GetInt32(2);
                    DetalleSeccion.IdProfesor = reader.GetInt32(3);
                  
                }

                con.Close();
            }

            return DetalleSeccion;
        }





    }
}
