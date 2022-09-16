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
    public partial class frm_reportProduto : Form
    {
        public frm_reportProduto()
        {
            InitializeComponent();
        }

        private void frm_reportProduto_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'bd_bancoMvcDataSet1.tb_produtos'. Você pode movê-la ou removê-la conforme necessário.
            this.tb_produtosTableAdapter.Fill(this.bd_bancoMvcDataSet1.tb_produtos);

            this.reportViewer1.RefreshReport();
        }
    }
}
