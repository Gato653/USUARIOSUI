using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuarios_data
{
    public class Conexion
    {
        public static string vStringConexionSisUser = "data source=DESKTOP-LE6KK42\\MSSQLSERVER12;initial catalog=UsuariosDB;Integrated Security=SSPI";
        public SqlDataAdapter vMySQLDataAdapter; // permite hacer consultas a sqlserver, no se recomienda para insert o update
        public SqlCommand vMySQLCommand; // permite hacer insert con parametros, para evitar sqlinjection
        public static SqlConnection vConexionSisUser = new SqlConnection(vStringConexionSisUser);
    }
}
