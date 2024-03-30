using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sisfac.GUI
{
    public partial class Login : Form
    {
        //Atributo 
        private Boolean _Autorizado= false;
        //Propiedad
        public bool Autorizado { get => _Autorizado;}

        //Variables
        //String _Usuario="Einer";
        //String _Clave="12345";

        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            DataLayer.DBOperacion oOperacion = new DataLayer.DBOperacion();
            DataTable dt = new DataTable();
            string query = @"SELECT usuarios
                            IDUsuario, usuario,
                            IDEmpleado, IDRol
                            FROM usuario
                            WHERE usuario = '"+txtUsuario.Text+@"'
                            AND Clave = MD5('"+txtClave.Text+@"');";
            oOperacion.Consultar(query);
            dt = oOperacion.Consultar(query);
            if (dt.Rows.Count == 1)
            {
                _Autorizado = true;
                Close();
            }
            else
            {
                _Autorizado = false;
                lblMensaje.Text = "Usuario o Clave incorrectos";
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _Autorizado = false;
            Close();
        }
    }
}
