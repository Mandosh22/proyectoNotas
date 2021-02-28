using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace ProyectoNotas.AccesoADatos
{
    public class Conexion

    { // Data Source = MARTIR; Initial catalog = ProyectoNotas; Integrated Security = True
        //Data Source=.;Initial Catalog=escuela;Integrated Security=True
        private static string cadena = @"Data Source=.;Initial Catalog=escuela;Integrated Security=True";

        public static SqlConnection Conectar() 
        {
            return new SqlConnection(cadena);
        }
    }
}
