namespace GerencTicketsRefeicao.UI
{
    partial class FormPrincipal
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.btnGerencFunc = new System.Windows.Forms.Button();
            this.btnGerencTickets = new System.Windows.Forms.Button();
            this.panelFormularios = new System.Windows.Forms.Panel();
            this.btnSair = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.LightSlateGray;
            this.panelHeader.Controls.Add(this.btnSair);
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Controls.Add(this.btnGerencFunc);
            this.panelHeader.Controls.Add(this.btnGerencTickets);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(784, 91);
            this.panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(182, 25);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(425, 24);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "GERENCIAMENTO DE TICKETS REFEIÇÃO";
            // 
            // btnGerencFunc
            // 
            this.btnGerencFunc.BackColor = System.Drawing.Color.SlateGray;
            this.btnGerencFunc.FlatAppearance.BorderSize = 0;
            this.btnGerencFunc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerencFunc.Location = new System.Drawing.Point(392, 68);
            this.btnGerencFunc.Name = "btnGerencFunc";
            this.btnGerencFunc.Size = new System.Drawing.Size(392, 23);
            this.btnGerencFunc.TabIndex = 0;
            this.btnGerencFunc.Text = "Gerenciar Funcionarios";
            this.btnGerencFunc.UseVisualStyleBackColor = false;
            this.btnGerencFunc.Click += new System.EventHandler(this.btnGerencFuncionarios_Click);
            // 
            // btnGerencTickets
            // 
            this.btnGerencTickets.BackColor = System.Drawing.Color.SlateGray;
            this.btnGerencTickets.FlatAppearance.BorderSize = 0;
            this.btnGerencTickets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerencTickets.Location = new System.Drawing.Point(0, 68);
            this.btnGerencTickets.Name = "btnGerencTickets";
            this.btnGerencTickets.Size = new System.Drawing.Size(392, 23);
            this.btnGerencTickets.TabIndex = 0;
            this.btnGerencTickets.Text = "Gerenciar Tickets";
            this.btnGerencTickets.UseVisualStyleBackColor = false;
            this.btnGerencTickets.Click += new System.EventHandler(this.btnGerencTickets_Click);
            // 
            // panelFormularios
            // 
            this.panelFormularios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormularios.Location = new System.Drawing.Point(0, 91);
            this.panelFormularios.Name = "panelFormularios";
            this.panelFormularios.Size = new System.Drawing.Size(784, 390);
            this.panelFormularios.TabIndex = 1;
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.IndianRed;
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Location = new System.Drawing.Point(12, 12);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 23);
            this.btnSair.TabIndex = 2;
            this.btnSair.Text = "SAIR";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 481);
            this.Controls.Add(this.panelFormularios);
            this.Controls.Add(this.panelHeader);
            this.Name = "FormPrincipal";
            this.ShowIcon = false;
            this.Text = "Gerenciador de Tickets Refeição";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelFormularios;
        private System.Windows.Forms.Button btnGerencTickets;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button btnGerencFunc;
        private System.Windows.Forms.Button btnSair;
    }
}