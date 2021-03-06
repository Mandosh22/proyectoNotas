﻿using System;
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
                string ssql = "SELECT * FROM Profesor";
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    listaProfesor.Add(new Profesor(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)
                        , reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(7)));
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
                string sentencia = "INSERT INTO Profesores (Nombre,Apellido,Username,Contraseña,Direccion,Correo,IdSeccion) VALUES('{0}'," +
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
                string sentencia = "UPDATE Profesores SET Nombre = '{0}',Apellido='{1}',Username='{2}'," +
                    " Contraseña='{3}',Direccion='{4}',Correo='{5}',IdSeccion'{6}' WHERE Id ='{7}'";
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


        public static Profesor ObtenerProfesoresPorId(int pId)
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


    }
}
