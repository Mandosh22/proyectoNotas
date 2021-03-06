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
        public List<Nota> ObtenerNotas(int pId)
        {
            List<Nota> listaNotas = new List<Nota>();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = " select  n.Id ,n.IdAlumno,n.IdProfesor ,n.nota ,s.Id as IDSECCION,s.Nombre ,a.Nombre +' '+ a.Apellido as NombreAumno,  p.Nombre+' '+ p.Apellido as NombreProfe    from Notas as n" +
                    " inner join Alumnos as a on n.IdAlumno = a.Id" +
                    "  inner join Profesores as p on n.IdProfesor = p.Id" +
                    "  inner join Secciones as s on a.IdSeccion = s.Id  where n.IdProfesor={0} ";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

        

                while (reader.Read())
                {
                    listaNotas.Add(new Nota(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDecimal(3), reader.GetInt32(4),reader.GetString(5),reader.GetString(6), reader.GetString(7)));
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
                string sentencia = "INSERT INTO Notas (IdAlumno ,Nota,IdProfesor) VALUES('{0}','{1}','{2}')";
                string ssql = string.Format(sentencia, pNota.IdAlumno, pNota.Notas, pNota.IdProfesor);
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
                string sentencia = "UPDATE Notas SET IdAlumno = '{0}',Nota='{1}',IdProfesor='{2}' WHERE Id ='{3}'";
                string ssql = string.Format(sentencia, pNota.IdAlumno, pNota.Notas, pNota.IdProfesor, pNota.Id);
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


        public  Nota ObtenerNotaPorId(int pId)
        {
            Nota Nota = new Nota();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "select n.Id ,n.IdAlumno,n.IdProfesor ,n.nota ,s.Id as IDSECCION,s.Nombre ,a.Nombre , p.Nombre from Notas as n " +
                    "inner join Alumnos as a on n.IdAlumno = a.Id" +
                    " inner join Profesores as p on n.IdProfesor = p.Id" +
                    "  inner join Secciones as s on a.IdSeccion = s.Id where n.Id = {0}   ";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    Nota.Id = reader.GetInt32(0);
                    Nota.IdAlumno = reader.GetInt32(1);
                    Nota.IdProfesor = reader.GetInt32(2);
                    Nota.Notas = reader.GetDecimal(3);
                    Nota.IdSeccion = reader.GetInt32(4);
                    Nota.NombreSeccion = reader.GetString(5);
                    Nota.NombreAlumno = reader.GetString(6);
                    Nota.NombreProfesor = reader.GetString(7);
                }

                con.Close();
            }

            return Nota;
        }




    }
}
