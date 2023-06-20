namespace FestasInfantis.WinApp
{
    partial class TelaConfiguracaoDesconto
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
            groupBox1 = new GroupBox();
            lblPorcentagemAluguel = new Label();
            txtPorcentagemAluguel = new NumericUpDown();
            txtPorcentagemMaxima = new NumericUpDown();
            lblPorcentagemMaxima = new Label();
            btnCancelar = new Button();
            btnGravar = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtPorcentagemAluguel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPorcentagemMaxima).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtPorcentagemMaxima);
            groupBox1.Controls.Add(lblPorcentagemMaxima);
            groupBox1.Controls.Add(txtPorcentagemAluguel);
            groupBox1.Controls.Add(lblPorcentagemAluguel);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(314, 211);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Porcentagens de Desconto:";
            // 
            // lblPorcentagemAluguel
            // 
            lblPorcentagemAluguel.AutoSize = true;
            lblPorcentagemAluguel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPorcentagemAluguel.Location = new Point(61, 37);
            lblPorcentagemAluguel.Name = "lblPorcentagemAluguel";
            lblPorcentagemAluguel.Size = new Size(189, 21);
            lblPorcentagemAluguel.TabIndex = 0;
            lblPorcentagemAluguel.Text = "Porcentagem por Aluguel:";
            // 
            // txtPorcentagemAluguel
            // 
            txtPorcentagemAluguel.Location = new Point(120, 61);
            txtPorcentagemAluguel.Name = "txtPorcentagemAluguel";
            txtPorcentagemAluguel.Size = new Size(70, 29);
            txtPorcentagemAluguel.TabIndex = 1;
            // 
            // numericUpDown1
            // 
            txtPorcentagemMaxima.Location = new Point(120, 144);
            txtPorcentagemMaxima.Name = "numericUpDown1";
            txtPorcentagemMaxima.Size = new Size(70, 29);
            txtPorcentagemMaxima.TabIndex = 3;
            // 
            // label1
            // 
            lblPorcentagemMaxima.AutoSize = true;
            lblPorcentagemMaxima.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPorcentagemMaxima.Location = new Point(21, 120);
            lblPorcentagemMaxima.Name = "label1";
            lblPorcentagemMaxima.Size = new Size(275, 21);
            lblPorcentagemMaxima.TabIndex = 2;
            lblPorcentagemMaxima.Text = "Máximo de Porcentagem de Desconto:";
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(251, 241);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 41);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(170, 241);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 41);
            btnGravar.TabIndex = 5;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // TelaConfiguracaoDesconto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 294);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(groupBox1);
            Name = "TelaConfiguracaoDesconto";
            Text = "Configuração de Descontos";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtPorcentagemAluguel).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPorcentagemMaxima).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private NumericUpDown txtPorcentagemAluguel;
        private Label lblPorcentagemAluguel;
        private NumericUpDown txtPorcentagemMaxima;
        private Label lblPorcentagemMaxima;
        private Button btnCancelar;
        private Button btnGravar;
    }
}