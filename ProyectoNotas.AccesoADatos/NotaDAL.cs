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
     public class NotaDAL
    {
        public List<Nota> ObtenerNotas()
        {
            List<Nota> listaNotas = new List<Nota>();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string ssql = "SELECT * FROM Notas";
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    listaNotas.Add(new Nota(reader.GetInt32(0), reader.GetDecimal(1), reader.GetInt32(2), reader.GetInt32(3)));
                }

                con.Close();
            }

            return listaNotas;
        }


        public int InsertarNota(Nota pNota)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "INSERT INTO Notas (IdAlumno ,Nota,IdMateria) VALUES('{0}','{1}','{2}')";
                string ssql = string.Format(sentencia, pNota.IdAlumno, pNota.Notas, pNota.IdMateria);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }



        public int ModificarNota (Nota pNota)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "UPDATE Notas SET IdAlumno = '{0}',Nota='{1}',IdMateria='{2}',' WHERE Id ='{3}'";
                string ssql = string.Format(sentencia, pNota.IdAlumno, pNota.Notas, pNota.IdMateria, pNota.Id);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }


        //metodo que permite elimiar un registro de Notaes existentes

        public int EliminarNota(int pId)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "DELETE FROM Notas WHERE Id = {0}";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }


        public static Nota ObtenerNotaPorId(int pId)
        {
            Nota Nota = new Nota();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "SELECT * FROM Notas WHERE Id = {0}";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    Nota.Id = reader.GetInt32(0);
                    Nota.IdAlumno = reader.GetInt32(1);
                    Nota.Notas = reader.GetInt32(2);
                    Nota.IdMateria = reader.GetInt32(3);

                }

                con.Close();
            }

            return Nota;
        }




    }
}
