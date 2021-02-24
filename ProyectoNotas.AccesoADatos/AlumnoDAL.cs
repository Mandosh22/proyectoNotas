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
    class AlumnoDAL
    {

        public List<Alumno> ObtenerAlumnos()
        {
            List<Alumno> listaAlumno = new List<Alumno>();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string ssql = "SELECT * FROM Alumnos";
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    listaAlumno.Add(new Alumno(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)
                        , reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(7)));
                }

                con.Close();
            }

            return listaAlumno;
        }

        public int InsertarAlumnos(Alumno pAlumno)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "INSERT INTO Alumnos (Nombre,Apellido,Username,Contraseña,Direccion,Correo,IdSeccion) VALUES('{0}'," +
                    "'{1}','{2}','{3}','{4}','{5}','{6}')";
                string ssql = string.Format(sentencia, pAlumno.Nombre, pAlumno.Apellido, pAlumno.UserName,
                    pAlumno.Contraseña, pAlumno.Direccion, pAlumno.Correo, pAlumno.IdSeccion );
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }



        public int ModificarAlumnos(Alumno pAlumno)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "UPDATE Alumnos SET Nombre = '{0}',Apellido='{1}',Username='{2}'," +
                    " Contraseña='{3}',Direccion='{4}',Correo='{5}',IdSeccion'{6}' WHERE Id ='{7}'";
                string ssql = string.Format(sentencia, pAlumno.Nombre, pAlumno.Apellido,
                    pAlumno.UserName, pAlumno.Contraseña, pAlumno.Direccion,
                    pAlumno.Correo, pAlumno.IdSeccion , pAlumno.Id);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }


        //metodo que permite elimiar un registro de Alumnos existentes

        public int EliminarAlumnos(int pId)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "DELETE FROM Alumnos WHERE Id = {0}";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }




        public static Alumno ObtenerAlumnosPorId(int pId)
        {
            Alumno Alumno = new Alumno();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "SELECT * FROM Alumnos WHERE Id = {0}";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    Alumno.Id = reader.GetInt32(0);
                    Alumno.Nombre = reader.GetString(1);
                    Alumno.Apellido = reader.GetString(2);
                    Alumno.UserName = reader.GetString(3);
                    Alumno.Contraseña = reader.GetString(4);
                    Alumno.Direccion = reader.GetString(5);
                    Alumno.Correo = reader.GetString(6);
                    Alumno.IdSeccion = reader.GetInt32(7);
                }

                con.Close();
            }

            return Alumno;
        }


    }
}
