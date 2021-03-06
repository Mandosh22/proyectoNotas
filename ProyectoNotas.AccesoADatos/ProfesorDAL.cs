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
    public class ProfesorDAL
    {

        public List<Profesor> ObtenerProfesor()
        {
            List<Profesor> listaProfesor = new List<Profesor>();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string ssql = "SELECT d.Id ,d.Nombre,d.Apellido,d.Username,d.Contraseña,d.Direccion,d.Correo,d.IdMateria  ,e.Nombre FROM Profesores as d INNER JOIN Materias as e on d.IdMateria = e.Id";
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    listaProfesor.Add(new Profesor(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)
                        , reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(7), reader.GetString(8)));
                }

                con.Close();
            }

            return listaProfesor;
        }


        public int InsertarProfesores(Profesor pProfesor)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "INSERT INTO Profesores (Nombre,Apellido,Username,Contraseña,Direccion,Correo,IdMateria) VALUES('{0}'," +
                    "'{1}','{2}','{3}','{4}','{5}','{6}')";
                string ssql = string.Format(sentencia, pProfesor.Nombre, pProfesor.Apellido, pProfesor.UserName,
                    pProfesor.Contraseña, pProfesor.Direccion, pProfesor.Correo, pProfesor.IdMateria);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }

        public int ModificarProfesores(Profesor pProfesor)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "UPDATE Profesores SET Nombre = '{0}',Apellido='{1}',Username='{2}', Contraseña='{3}',Direccion='{4}',Correo='{5}',IdMateria='{6}' WHERE Id ='{7}'";
                string ssql = string.Format(sentencia, pProfesor.Nombre, pProfesor.Apellido,
                    pProfesor.UserName, pProfesor.Contraseña, pProfesor.Direccion,
                    pProfesor.Correo, pProfesor.IdMateria, pProfesor.Id);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }



        //metodo que permite elimiar un registro de Profesores existentes

        public int EliminarProfesores(int pId)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "DELETE FROM Profesores WHERE Id = {0}";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }


        public   Profesor ObtenerPorId(int pId)
        {
            Profesor Profesor = new Profesor();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "SELECT * FROM Profesores WHERE Id = {0}";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    Profesor.Id = reader.GetInt32(0);
                    Profesor.Nombre = reader.GetString(1);
                    Profesor.Apellido = reader.GetString(2);
                    Profesor.UserName = reader.GetString(3);
                    Profesor.Contraseña = reader.GetString(4);
                    Profesor.Direccion = reader.GetString(5);
                    Profesor.Correo = reader.GetString(6);
                    Profesor.IdMateria = reader.GetInt32(7);
                }

                con.Close();
            }

            return Profesor;
        }



        public List<Profesor> ObtenerProfesor_Materia(int pId)
        {
            List<Profesor> listaProfesor = new List<Profesor>();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "SELECT d.Id ,d.Nombre,d.Apellido,d.Username,d.Contraseña,d.Direccion,d.Correo,d.IdMateria  ,e.Nombre  " +
                    "     FROM Profesores as d INNER JOIN Materias as e on d.IdMateria = e.Id  WHERE IdMateria = {0}";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    listaProfesor.Add(new Profesor(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)
                        , reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(7),reader.GetString(8)));
                }

                con.Close();
            }

            return listaProfesor;
        }

        public Profesor Login(Profesor pProfesor)
        {
            Profesor profesor = new Profesor();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string ssql = "SELECT * from Profesores where Username=@Username ";
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@Username", pProfesor.UserName);
                IDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {

                    if (reader["Contraseña"].ToString()==pProfesor.Contraseña)
                    {

                        profesor.Id = reader.GetInt32(0);
                        profesor.Nombre = reader.GetString(1);
                        profesor.Apellido = reader.GetString(2);
                        profesor.UserName = reader.GetString(3);
                        profesor.Contraseña = reader.GetString(4);
                        profesor.Direccion = reader.GetString(5);
                        profesor.Correo = reader.GetString(6);
                        profesor.IdMateria = reader.GetInt32(7);

                    }
                    else
                    
                        return null;
                    
                  
                }else

                    return null;

                con.Close();
            }

            return profesor;
        }




    }
}








