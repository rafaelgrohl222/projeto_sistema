using Projeto_Sistem.Entidades;
using Projeto_Sistema.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Sistema.View
{
    public partial class frm_CadProdutos : Form
    {
        ProdutoEnt objTabela = new ProdutoEnt();

        public frm_CadProdutos()
        {
            InitializeComponent();
        }
        //Método HabilitarCampos()
        private void HabilitarCampos()
        {
            txt_nomeProdutos.Enabled = true;
            txt_descricao.Enabled = true;
            txt_valor.Enabled = true;
        }

        //Método LimparCampos()
        private void LimparCampos()
        {
            txt_codigoProdutos.Text = "";
            txt_nomeProdutos.Text = "";
            txt_descricao.Text = "";
            txt_valor.Text = "";
        }

        //Método DesabilitarCampo()
        private void DesabilitarCampos()
        {
            txt_nomeProdutos.Enabled = false;
            txt_descricao.Enabled = false;
            txt_valor.Enabled = false;
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
                        objTabela.Nome_produto = txt_nomeProdutos.Text;
                        objTabela.Descricao = txt_descricao.Text;
                        objTabela.Valor = Convert.ToDecimal(txt_valor.Text);

                        //Passar informação .UsuarioModel
                        int x = ProdutoModel.Inserir(objTabela);

                        if (x > 0)
                        {
                            //string.Format() formatando em string
                            MessageBox.Show(string.Format("Produto [ {0} ] foi inserido!", txt_nomeProdutos.Text));
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
                        objTabela.Id = Convert.ToInt32(txt_codigoProdutos.Text);

                        //Passar informação .UsuarioModel
                        int x = ProdutoModel.Excluir(objTabela);

                        if (x > 0)
                        {
                            //string.Format() formatando em string
                            MessageBox.Show(string.Format("Usuário [ {0} ] foi Excluido!", txt_nomeProdutos.Text));
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
                        objTabela.Nome_produto = txt_nomeProdutos.Text;
                        objTabela.Descricao = txt_descricao.Text;
                        objTabela.Valor = Convert.ToInt32(txt_valor.Text);
                        objTabela.Id = Convert.ToInt32(txt_codigoProdutos.Text);

                        //Passar informação .UsuarioModel
                        int x = ProdutoModel.Editar(objTabela);

                        if (x > 0)
                        {
                            //string.Format() formatando em string
                            MessageBox.Show(string.Format("Usuário [ {0} ] foi editado!", txt_nomeProdutos.Text));
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
                        objTabela.Nome_produto = txt_buscar.Text;

                        //Armazenar dados no objeto list
                        List<ProdutoEnt> lista = new List<ProdutoEnt>();

                        //Passar informação .UsuarioModel
                        lista = new ProdutoModel().Buscar(objTabela);
                        //Não gerar colunas automátizada
                        GridProdutos.AutoGenerateColumns = false;
                        GridProdutos.DataSource = lista;//Receber lista
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
        //Método ListarGrid
        private void ListarGrid()
        {
            try
            {
                //Armazenar dados no objeto list
                List<ProdutoEnt> lista = new List<ProdutoEnt>();

                //Passar informação .UsuarioModel
                lista = new ProdutoModel().Lista();
                //Não gerar colunas automátizada
                GridProdutos.AutoGenerateColumns = false;
                GridProdutos.DataSource = lista;//Receber lista
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao listar Dados! - {ex.Message}");
            }
        }
        //Dois cliques no formulario 
        private void frm_CadProdutos_Load(object sender, EventArgs e)
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
        private void GridProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //                                  .linhaAtual.naPosição.celulas[0].Valor.
            txt_codigoProdutos.Text = GridProdutos.CurrentRow.Cells[0].Value.ToString();
            txt_nomeProdutos.Text = GridProdutos.CurrentRow.Cells[1].Value.ToString();
            txt_descricao.Text = GridProdutos.CurrentRow.Cells[2].Value.ToString();
            txt_valor.Text = GridProdutos.CurrentRow.Cells[3].Value.ToString();
            HabilitarCampos();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            opc = "Salvar";//Recebe
            iniciarOpc();//executar método
            ListarGrid();//Listar ao salvar
            DesabilitarCampos();//Desabilitar campos depois de salvar
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            opc = "Novo";//Recebe
            iniciarOpc();//executar método
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Frm_CadUsuario frm_ = new Frm_CadUsuario();
            frm_.Show();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (txt_codigoProdutos.Text == "")
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

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            if (txt_codigoProdutos.Text == "")
            {
                MessageBox.Show("Selecione um Usuário, para EXCLUIR!");
                return;//saír bloco
            }

            opc = "Excluir";//Recebe
            iniciarOpc();//executar método
            ListarGrid();//Listar ao salvar
            DesabilitarCampos();//Desabilitar campos depois de salvar
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
            if (txt_nomeProdutos.Text == "")
            {
                ListarGrid();
                return;
            }
            opc = "Buscar";
            iniciarOpc();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_reportProduto frm_ = new frm_reportProduto();
            frm_.Show();
        }
    }
}
