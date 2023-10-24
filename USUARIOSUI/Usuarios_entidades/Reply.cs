using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuarios_entidades
{
    public class Reply
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public DataTable Data { get; set; }
    }
}
