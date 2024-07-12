using System.Windows.Forms;

namespace App_Gestao_Compras
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        private void InitializeComponent()
        {
            this.dataGridViewItens = new System.Windows.Forms.DataGridView();
            this.txtNomeItem = new System.Windows.Forms.TextBox();
            this.btnAdicionarItem = new System.Windows.Forms.Button();
            this.btnSelecionarImagem = new System.Windows.Forms.Button();
            this.pictureBoxImagem = new System.Windows.Forms.PictureBox();
            this.txtNomeLista = new System.Windows.Forms.TextBox();
            this.btnCriarLista = new System.Windows.Forms.Button();
            this.listBoxItensSelecionados = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagem)).BeginInit();
            this.SuspendLayout();
          
            this.dataGridViewItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id" },
        new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome" },
        new System.Windows.Forms.DataGridViewImageColumn { Name = "Imagem", HeaderText = "Imagem" }
    });
            this.dataGridViewItens.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewItens.Name = "dataGridViewItens";
            this.dataGridViewItens.Size = new System.Drawing.Size(776, 150);
            this.dataGridViewItens.TabIndex = 0;
            this.dataGridViewItens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
          
            this.txtNomeItem.Location = new System.Drawing.Point(12, 180);
            this.txtNomeItem.Name = "txtNomeItem";
            this.txtNomeItem.Size = new System.Drawing.Size(200, 20);
            this.txtNomeItem.TabIndex = 1;
      
            this.btnAdicionarItem.Location = new System.Drawing.Point(12, 220);
            this.btnAdicionarItem.Name = "btnAdicionarItem";
            this.btnAdicionarItem.Size = new System.Drawing.Size(100, 23);
            this.btnAdicionarItem.TabIndex = 2;
            this.btnAdicionarItem.Text = "Adicionar Item";
            this.btnAdicionarItem.UseVisualStyleBackColor = true;
            this.btnAdicionarItem.Click += new System.EventHandler(this.btnAdicionarItem_Click);
          
            this.btnSelecionarImagem.Location = new System.Drawing.Point(230, 180);
            this.btnSelecionarImagem.Name = "btnSelecionarImagem";
            this.btnSelecionarImagem.Size = new System.Drawing.Size(120, 23);
            this.btnSelecionarImagem.TabIndex = 3;
            this.btnSelecionarImagem.Text = "Selecionar Imagem";
            this.btnSelecionarImagem.UseVisualStyleBackColor = true;
            this.btnSelecionarImagem.Click += new System.EventHandler(this.btnSelecionarImagem_Click);
          
            this.pictureBoxImagem.Location = new System.Drawing.Point(230, 210);
            this.pictureBoxImagem.Name = "pictureBoxImagem";
            this.pictureBoxImagem.Size = new System.Drawing.Size(120, 120);
            this.pictureBoxImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImagem.TabIndex = 4;
            this.pictureBoxImagem.TabStop = false;
          
            this.txtNomeLista.Location = new System.Drawing.Point(12, 270);
            this.txtNomeLista.Name = "txtNomeLista";
            this.txtNomeLista.Size = new System.Drawing.Size(200, 20);
            this.txtNomeLista.TabIndex = 5;
          
            this.btnCriarLista.Location = new System.Drawing.Point(12, 310);
            this.btnCriarLista.Name = "btnCriarLista";
            this.btnCriarLista.Size = new System.Drawing.Size(100, 23);
            this.btnCriarLista.TabIndex = 6;
            this.btnCriarLista.Text = "Criar Lista";
            this.btnCriarLista.UseVisualStyleBackColor = true;
            this.btnCriarLista.Click += new System.EventHandler(this.btnCriarLista_Click);
           
            this.listBoxItensSelecionados.FormattingEnabled = true;
            this.listBoxItensSelecionados.Location = new System.Drawing.Point(380, 180);
            this.listBoxItensSelecionados.Name = "listBoxItensSelecionados";
            this.listBoxItensSelecionados.Size = new System.Drawing.Size(200, 160);
            this.listBoxItensSelecionados.TabIndex = 7;
           
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBoxItensSelecionados);
            this.Controls.Add(this.btnCriarLista);
            this.Controls.Add(this.txtNomeLista);
            this.Controls.Add(this.pictureBoxImagem);
            this.Controls.Add(this.btnSelecionarImagem);
            this.Controls.Add(this.btnAdicionarItem);
            this.Controls.Add(this.txtNomeItem);
            this.Controls.Add(this.dataGridViewItens);
            this.Name = "Form1";
            this.Text = "Gestão de Compras Domésticas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewItens;
        private System.Windows.Forms.TextBox txtNomeItem;
        private System.Windows.Forms.Button btnAdicionarItem;
        private System.Windows.Forms.Button btnSelecionarImagem;
        private System.Windows.Forms.PictureBox pictureBoxImagem;
        private System.Windows.Forms.TextBox txtNomeLista;
        private System.Windows.Forms.Button btnCriarLista;
        private System.Windows.Forms.ListBox listBoxItensSelecionados;
    }
}

