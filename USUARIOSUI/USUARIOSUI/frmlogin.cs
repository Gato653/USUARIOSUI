using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Usuarios_entidades;
using Usuarios_login;

namespace USUARIOSUI
{
    public partial class frmlogin : Form
    {
        //Creación de objeto de tipos usuario 
        private Usuario objUsuario = new Usuario();

        //Creación de instancia para conectar con el metodo de Encriptarpasword
        private usuariolg AccesoLogica = new usuariolg (); 
        public frmlogin()
        {
            InitializeComponent();
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtuser.Text != "" && txtpasword.Text != "")
            {
                Usuario OBJusuario = new Usuario();

                OBJusuario.username = txtuser.Text;
                OBJusuario.password = txtpasword.Text;
                var PassEncriptado = AccesoLogica.GetSHA512Hash(OBJusuario.password);

                OBJusuario.password = PassEncriptado;

                var reply = AccesoLogica.ObtenerUsuarios(OBJusuario);

                if (reply.Success)
                {
                    MessageBox.Show(reply.Message);
                    
                    this.Hide();
                   
                    FrmMenuPrincipal menuprincipal = new FrmMenuPrincipal();
                    menuprincipal.Show();
                }
                else
                {
                    MessageBox.Show(reply.Message);
                }

                

            }
            else
            {
                MessageBox.Show("Algunos de los campos de textos están vacios");
            }


    }
        }
}
