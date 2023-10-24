using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Usuarios_data;
using Usuarios_entidades;

namespace Usuarios_login
{
    public class usuariolg
    {

       private UsuarioDB AccesoData = new UsuarioDB();  

        public Reply ObtenerUsuarios(Usuario ObjUsuario)
        {
            Reply reply = new Reply();
            var _replydata = AccesoData.ObtenerUsuario(ObjUsuario);
            if (_replydata.Success)
            {
                if ((string)_replydata.Data.Rows[0][0] == "Exito al inicar sesion")
                {
                    reply.Success = true;
                    reply.Message = "Exito al inicar sesion";
                }
                else
                {
                    reply.Success = false;
                    reply.Message = "Error, el usurio y la contrasena no son validos";
                }
            }
            else 
            {
                reply.Message = _replydata.Message;
            }
            return reply;   
        }



        public string GetSHA512Hash(string inputString)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                Encoding encoding = Encoding.UTF8;
                byte[] bytes = encoding.GetBytes(inputString);

                byte[] hashBytes = sha512.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                    sb.Append(b.ToString("x2"));// Convierte cada byte a su representación hexadecimal.

                return sb.ToString();
            }
        }
    }
}