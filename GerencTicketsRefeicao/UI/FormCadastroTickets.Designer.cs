namespace GerencTicketsRefeicao.UI
{
    partial class FormCadastroTickets
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
            this.labelId = new System.Windows.Forms.Label();
            this.labelNome = new System.Windows.Forms.Label();
            this.labelQuantidade = new System.Windows.Forms.Label();
            this.labelSituacao = new System.Windows.Forms.Label();
            this.labelDataAlt = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.cbSituacao = new System.Windows.Forms.ComboBox();
            this.dtpDataAlt = new System.Windows.Forms.DateTimePicker();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.cbNome = new System.Windows.Forms.ComboBox();
            this.numQuantidade = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantidade)).BeginInit();
            this.SuspendLayout();
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(80, 63);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(45, 19);
            this.labelId.TabIndex = 0;
            this.labelId.Text = "Id:";
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(195, 65);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(69, 19);
            this.labelNome.TabIndex = 0;
            this.labelNome.Text = "Nome:";
            // 
            // labelQuantidade
            // 
            this.labelQuantidade.AutoSize = true;
            this.labelQuantidade.Location = new System.Drawing.Point(359, 122);
            this.labelQuantidade.Name = "labelQuantidade";
            this.labelQuantidade.Size = new System.Drawing.Size(141, 19);
            this.labelQuantidade.TabIndex = 0;
            this.labelQuantidade.Text = "Quantidade:";
            // 
            // labelSituacao
            // 
            this.labelSituacao.AutoSize = true;
            this.labelSituacao.Location = new System.Drawing.Point(80, 122);
            this.labelSituacao.Name = "labelSituacao";
            this.labelSituacao.Size = new System.Drawing.Size(117, 19);
            this.labelSituacao.TabIndex = 0;
            this.labelSituacao.Text = "Situação:";
            // 
            // labelDataAlt
            // 
            this.labelDataAlt.AutoSize = true;
            this.labelDataAlt.Location = new System.Drawing.Point(80, 180);
            this.labelDataAlt.Name = "labelDataAlt";
            this.labelDataAlt.Size = new System.Drawing.Size(201, 19);
            this.labelDataAlt.TabIndex = 0;
            this.labelDataAlt.Text = "Data Alteração: ";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtId.Location = new System.Drawing.Point(134, 63);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(44, 27);
            this.txtId.TabIndex = 1;
            // 
            // cbSituacao
            // 
            this.cbSituacao.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSituacao.FormattingEnabled = true;
            this.cbSituacao.Location = new System.Drawing.Point(203, 120);
            this.cbSituacao.Name = "cbSituacao";
            this.cbSituacao.Size = new System.Drawing.Size(65, 28);
            this.cbSituacao.TabIndex = 3;
            this.cbSituacao.Tag = "";
            // 
            // dtpDataAlt
            // 
            this.dtpDataAlt.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpDataAlt.Enabled = false;
            this.dtpDataAlt.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDataAlt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataAlt.Location = new System.Drawing.Point(272, 176);
            this.dtpDataAlt.Name = "dtpDataAlt";
            this.dtpDataAlt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpDataAlt.Size = new System.Drawing.Size(321, 27);
            this.dtpDataAlt.TabIndex = 4;
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.IndianRed;
            this.btnFechar.FlatAppearance.BorderSize = 0;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Location = new System.Drawing.Point(84, 253);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(119, 35);
            this.btnFechar.TabIndex = 5;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(474, 253);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(119, 35);
            this.btnSalvar.TabIndex = 5;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // cbNome
            // 
            this.cbNome.FormattingEnabled = true;
            this.cbNome.Location = new System.Drawing.Point(270, 63);
            this.cbNome.Name = "cbNome";
            this.cbNome.Size = new System.Drawing.Size(323, 27);
            this.cbNome.TabIndex = 6;
            // 
            // numQuantidade
            // 
            this.numQuantidade.Location = new System.Drawing.Point(534, 120);
            this.numQuantidade.Name = "numQuantidade";
            this.numQuantidade.Size = new System.Drawing.Size(59, 26);
            this.numQuantidade.TabIndex = 7;
            // 
            // FormCadastroTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 401);
            this.Controls.Add(this.numQuantidade);
            this.Controls.Add(this.cbNome);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.dtpDataAlt);
            this.Controls.Add(this.cbSituacao);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.labelDataAlt);
            this.Controls.Add(this.labelSituacao);
            this.Controls.Add(this.labelQuantidade);
            this.Controls.Add(this.labelNome);
            this.Controls.Add(this.labelId);
            this.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCadastroTickets";
            this.ShowIcon = false;
            this.Text = "Cadastro de Tickets Refeição";
            this.Load += new System.EventHandler(this.FormCadastroTickets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.Label labelQuantidade;
        private System.Windows.Forms.Label labelSituacao;
        private System.Windows.Forms.Label labelDataAlt;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.ComboBox cbSituacao;
        private System.Windows.Forms.DateTimePicker dtpDataAlt;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.ComboBox cbNome;
        private System.Windows.Forms.NumericUpDown numQuantidade;
    }
}