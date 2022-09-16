using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projeto_Sistema.Model;
using Projeto_Sistema.Entidades;

namespace Projeto_Sistema.View
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
        }

        private void link_cadastrarUsuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Frm_CadUsuario form = new Frm_CadUsuario();
            form.Show();
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            //Fechar o frm_login
            this.Close();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                if(txt_usuario.Text == "")
                {
                    MessageBox.Show("Preencher o campo [ Usuário ]!");
                    txt_usuario.Focus();//Cursor no formulário
                    return;//Saír do bloco
                }

                if(txt_senha.Text == "")
                {
                    MessageBox.Show("Preencher o campo [ Senha ]!");
                    txt_senha.Focus();//Cursor no formulário
                    return;//Saír do bloco
                }

                UsuarioEnt obj = new UsuarioEnt();

                obj.Usuario = txt_usuario.Text;
                obj.Senha = txt_senha.Text;

                obj = new UsuarioModel().Login(obj);

                if(obj.Usuario == null)
                {
                    lbl_mensagem.Text = "Usuário ou Senha, não encontrado!";//Mensagem ao usuário
                    lbl_mensagem.ForeColor = Color.Red;//lbl_mensagem cor vermelha
                    return;
                }

                Frm_CadUsuario form = new Frm_CadUsuario();

                this.Hide();//Ocultar frm_login
                form.Show();//Abrir frm_CadUsuario
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao Logar! - {ex.Message}");
            }
        }
    }
}
