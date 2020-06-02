using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CamadaDados;

namespace testeApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int ret = 0;

            DUsuario usuario = new DUsuario();
            usuario.Usuario = txtLogin.Text;
            usuario.Senha = txtSenha.Text;
            ret = usuario.Login(usuario);

            if (ret > 0)
                MessageBox.Show("Usuário logado com sucesso...");
            else
                MessageBox.Show("Usuario inválido");

        }
    }
}
