using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projeto_Sistema.Entidades;
using Projeto_Sistema.Model;

namespace Projeto_Sistema.View
{
    public partial class Frm_CadUsuario : Form
    {
        UsuarioEnt objTabela = new UsuarioEnt();

        public Frm_CadUsuario()
        {
            InitializeComponent();
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            opc = "Novo";//Recebe
            iniciarOpc();//executar método
        }

        private string opc = "";

        private void iniciarOpc()
        {
            switch (opc)
            {
                case "Novo":
                    HabilitarCampos();
                    LimparCampos();
                    break;

                case "Salvar":
                    try
                    {
                        //Recuperar informação do campo
                        objTabela.Nome = txt_nomeUsuario.Text;
                        objTabela.Usuario = txt_usuario.Text;
                        objTabela.Senha = txt_senha.Text;

                        //Passar informação .UsuarioModel
                        int x = UsuarioModel.Inserir(objTabela);

                        if (x > 0)
                        {
                            //string.Format() formatando em string
                            MessageBox.Show(string.Format("Usuário [ {0} ] foi inserido!", txt_nomeUsuario.Text));
                        }
                        else
                        {
                            MessageBox.Show("Não inserido!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocorreu um erro ao Salvar! - [ {ex.Message} ]");
                    }
                    LimparCampos();
                    break;

                case "Excluir":
                    try
                    {
                        //Recuperar informação do campo
                        objTabela.Id = Convert.ToInt32(txt_codigoUsuario.Text);

                        //Passar informação .UsuarioModel
                        int x = UsuarioModel.Excluir(objTabela);

                        if (x > 0)
                        {
                            //string.Format() formatando em string
                            MessageBox.Show(string.Format("Usuário [ {0} ] foi Excluido!", txt_nomeUsuario.Text));
                        }
                        else
                        {
                            MessageBox.Show("Não Excluido!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocorreu um erro ao Excluir! - [ {ex.Message} ]");
                    }
                    LimparCampos();
                    break;

                case "Editar":
                    try
                    {
                        //Recuperar informação do campo
                        objTabela.Nome = txt_nomeUsuario.Text;
                        objTabela.Usuario = txt_usuario.Text;
                        objTabela.Senha = txt_senha.Text;
                        objTabela.Id = Convert.ToInt32(txt_codigoUsuario.Text);

                        //Passar informação .UsuarioModel
                        int x = UsuarioModel.Editar(objTabela);

                        if (x > 0)
                        {
                            //string.Format() formatando em string
                            MessageBox.Show(string.Format("Usuário [ {0} ] foi editado!", txt_nomeUsuario.Text));
                        }
                        else
                        {
                            MessageBox.Show("Não Editado!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocorreu um erro ao Editar! - [ {ex.Message} ]");
                    }
                    LimparCampos();
                    break;

                case "Buscar":
                    try
                    {
                        objTabela.Nome = txt_buscar.Text;

                        //Armazenar dados no objeto list
                        List<UsuarioEnt> lista = new List<UsuarioEnt>();

                        //Passar informação .UsuarioModel
                        lista = new UsuarioModel().Buscar(objTabela);
                        //Não gerar colunas automátizada
                        GridUsuario.AutoGenerateColumns = false;
                        GridUsuario.DataSource = lista;//Receber lista
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao Buscar Dados! - {ex.Message}");
                    }
                    break;

                default:
                    break;
            }
        }

        //Método HabilitarCampos()
        private void HabilitarCampos()
        {
            txt_nomeUsuario.Enabled = true;
            txt_usuario.Enabled = true;
            txt_senha.Enabled = true;
        }

        //Método LimparCampos()
        private void LimparCampos()
        {
            txt_codigoUsuario.Text = "";
            txt_nomeUsuario.Text = "";
            txt_usuario.Text = "";
            txt_senha.Text = "";
        }

        //Método DesabilitarCampo()
        private void DesabilitarCampos()
        {
            txt_nomeUsuario.Enabled = false;
            txt_usuario.Enabled = false;
            txt_senha.Enabled = false;
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            if (txt_nomeUsuario.Text == "")
            {
                MessageBox.Show("Selecione o registro para ser SALVO!");
                return;//saír do bloco
            }

            opc = "Salvar";//Recebe
            iniciarOpc();//executar método
            ListarGrid();//Listar ao salvar
            DesabilitarCampos();//Desabilitar campos depois de salvar
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            if(txt_codigoUsuario.Text == "")
            {
                MessageBox.Show("Selecione um Usuário, para EXCLUIR!");
                return;//saír bloco
            }

            opc = "Excluir";//Recebe
            iniciarOpc();//executar método
            ListarGrid();//Listar ao salvar
            DesabilitarCampos();//Desabilitar campos depois de salvar
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if(txt_codigoUsuario.Text == "")
            {
                MessageBox.Show("Selecione o registro para ser EDITADO!");
                return;//saír do bloco
            }

            opc = "Editar";//Recebe
            iniciarOpc();//executar método
            DesabilitarCampos();//Desabilitar campos depois de salvar
            LimparCampos();//Limpar campos depois de editar
            ListarGrid();//Listar ao salvar
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Login form = new Frm_Login();
            form.Show();
        }

        //Método ListarGrid
        private void ListarGrid()
        {
            try
            {
                //Armazenar dados no objeto list
                List<UsuarioEnt> lista = new List<UsuarioEnt>();

                //Passar informação .UsuarioModel
                lista = new UsuarioModel().Lista();
                //Não gerar colunas automátizada
                GridUsuario.AutoGenerateColumns = false;
                GridUsuario.DataSource = lista;//Receber lista
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao listar Dados! - {ex.Message}");
            }
        }
        //Dois cliques no formulario 
        private void Frm_CadUsuario_Load(object sender, EventArgs e)
        { 
            ListarGrid();//Listar a grid
            //this.reportViewer1.RefreshReport();
        }
        //menu
        private void saírToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Evento - Exibir dados no formulário
        private void GridUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //                                  .linhaAtual.naPosição.celulas[0].Valor.
            txt_codigoUsuario.Text = GridUsuario.CurrentRow.Cells[0].Value.ToString();
            txt_nomeUsuario.Text = GridUsuario.CurrentRow.Cells[1].Value.ToString();
            txt_usuario.Text = GridUsuario.CurrentRow.Cells[2].Value.ToString();
            txt_senha.Text = GridUsuario.CurrentRow.Cells[3].Value.ToString();
            HabilitarCampos();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            opc = "Buscar";//Recebe
            iniciarOpc();//executar método
        }
        //Evento Pesquisa Dinamica (Exite valor mostra a letra selecionada)
        //Evento Pesquisa Dinamica (não existe: mostra todos registros)
        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            if(txt_buscar.Text == "")
            {
                ListarGrid();
                return;
            }
            opc = "Buscar";
            iniciarOpc();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            frm_CadProdutos frm_ = new frm_CadProdutos();
            frm_.Show();
        }

        private void usuáriosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frm_reportUsuario frm_ = new frm_reportUsuario();
            frm_.Show();
        }
    }
}
