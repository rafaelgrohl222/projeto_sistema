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
    public partial class frm_reportUsuario : Form
    {
        public frm_reportUsuario()
        {
            InitializeComponent();
        }

        private void frm_reportUsuario_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'bd_bancoMvcDataSet.tb_usuario'. Você pode movê-la ou removê-la conforme necessário.
            this.tb_usuarioTableAdapter.Fill(this.bd_bancoMvcDataSet.tb_usuario);

            this.reportViewer1.RefreshReport();
        }
    }
}
