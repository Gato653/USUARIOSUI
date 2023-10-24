using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios_entidades;

namespace Usuarios_data
{
    public class UsuarioDB : Conexion
    {
        public Reply ObtenerUsuario(Usuario OBJusuario)
        {
            DataTable vDataTable = new DataTable(); // almacena el resultado de las consultas
            Reply reply = new Reply();
            vConexionSisUser.Open(); // Abrir conexion
            vMySQLCommand = new SqlCommand();
            vMySQLCommand.Connection = vConexionSisUser; // asigno el string de conexion
            vMySQLCommand.CommandText = "VerificarUsuarioLogin";
            vMySQLCommand.CommandType = CommandType.StoredProcedure; // Establecer el tipo de comando como Stored Procedure
                                                                     // Agregar parámetros al Stored Procedure
            vMySQLCommand.Parameters.Add("@pusername", SqlDbType.NVarChar, 50).Value = OBJusuario.username;
            vMySQLCommand.Parameters.Add("@ppasword", SqlDbType.NVarChar, 180).Value = OBJusuario.password;
            // vMySQLCommand.Parameters.Add("@Parametro3", SqlDbType.DateTime).Value = param3
            try
            {
                vMySQLDataAdapter = new SqlDataAdapter(vMySQLCommand);
                vMySQLDataAdapter.Fill(vDataTable);
                vConexionSisUser.Close(); // Cierro conexion

                reply.Success = true;
                reply.Message = "Conexión Exitosa!";
                reply.Data = vDataTable;
            }
            catch (Exception ex)
            {
                vConexionSisUser.Close();
                reply.Success = false;
                reply.Message = ex.ToString();
            }

            return reply;
        }
    }

}
