using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace ProyectoNotas.AccesoADatos
{
    public class Conexion
    {
        private static string cadena = @"Data Source = MARTIR; Initial catalog = BDSistemaNotas; Integrated Security = True";

        public static SqlConnection Conectar() 
        {
            return new SqlConnection(cadena);
        }
    }
}
