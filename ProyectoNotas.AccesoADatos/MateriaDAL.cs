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
    public class MateriaDAL
    {
        //metodo permite obtener los registros almacenados en la base de datos
        public List<Materia> ObtenerMaterias() 
        {
            List<Materia> listaMaterias = new List<Materia>();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string ssql = "SELECT * FROM Materias";
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                while (reader.Read()) 
                {
                    listaMaterias.Add(new Materia(reader.GetInt32(0), reader.GetString(1)));
                }

                con.Close();
            }

            return listaMaterias;
        }

        //metodo que permite insertar un registro de materias

        public int insertarMateria(Materia pMateria) 
        {
            int resultado = 0;
            using(SqlConnection con = Conexion.Conectar()) 
            {
                con.Open();
                string sentencia = "ISERT INTO Materia(Nombre) VALUES('{0}')";
                string ssql = string.Format(sentencia, pMateria.Nombre);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }
        //metodo que permite modificar un registro de materias existentes

        public int modificarMateria(Materia pMateria)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "UPDATE Materias SET Nombre = '{0}' WHERE id = {1}";
                string ssql = string.Format(sentencia, pMateria.Nombre, pMateria.Id);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }
        //metodo que permite elimiar un registro de materias existentes

        public int eliminarMateria(int pId)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "DELETE FROM Materias WHERE Id = {0}";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }
        //metodo permite obtener un registros almacenado en la base de datos
        public static Materia ObtenerMateriaPorId(int pId)
        {
            Materia Materia = new Materia();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "SELECT * FROM Materias WHERE Id = {0}";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    Materia.Id = reader.GetInt32(0);
                    Materia.Nombre = reader.GetString(1);
                }

                con.Close();
            }

            return Materia;
        }
    }
}
