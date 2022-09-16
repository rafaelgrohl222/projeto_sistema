
namespace Projeto_Sistema.View
{
    partial class frm_reportProduto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bd_bancoMvcDataSet1 = new Projeto_Sistema.View.bd_bancoMvcDataSet1();
            this.tb_produtosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_produtosTableAdapter = new Projeto_Sistema.View.bd_bancoMvcDataSet1TableAdapters.tb_produtosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bd_bancoMvcDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.tb_produtosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Projeto_Sistema.View.ReportProduto.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(776, 293);
            this.reportViewer1.TabIndex = 0;
            // 
            // bd_bancoMvcDataSet1
            // 
            this.bd_bancoMvcDataSet1.DataSetName = "bd_bancoMvcDataSet1";
            this.bd_bancoMvcDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tb_produtosBindingSource
            // 
            this.tb_produtosBindingSource.DataMember = "tb_produtos";
            this.tb_produtosBindingSource.DataSource = this.bd_bancoMvcDataSet1;
            // 
            // tb_produtosTableAdapter
            // 
            this.tb_produtosTableAdapter.ClearBeforeFill = true;
            // 
            // frm_reportProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 321);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frm_reportProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Registros dos Produtos";
            this.Load += new System.EventHandler(this.frm_reportProduto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bd_bancoMvcDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tb_produtosBindingSource;
        private bd_bancoMvcDataSet1 bd_bancoMvcDataSet1;
        private bd_bancoMvcDataSet1TableAdapters.tb_produtosTableAdapter tb_produtosTableAdapter;
    }
}