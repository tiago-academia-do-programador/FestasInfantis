﻿namespace FestasInfantis.WinApp.ModuloCliente
{
    partial class TelaAlugueisClienteForm
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
            lblId = new Label();
            txtId = new TextBox();
            lblNome = new Label();
            textBox1 = new TextBox();
            gridAlugueis = new DataGridView();
            btnOk = new Button();
            ((System.ComponentModel.ISupportInitialize)gridAlugueis).BeginInit();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(44, 46);
            lblId.Name = "lblId";
            lblId.Size = new Size(20, 15);
            lblId.TabIndex = 0;
            lblId.Text = "Id:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(70, 43);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 1;
            txtId.Text = "0";
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(21, 77);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(43, 15);
            lblNome.TabIndex = 2;
            lblNome.Text = "Nome:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(70, 74);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(399, 23);
            textBox1.TabIndex = 3;
            // 
            // gridAlugueis
            // 
            gridAlugueis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridAlugueis.Location = new Point(21, 115);
            gridAlugueis.Name = "gridAlugueis";
            gridAlugueis.RowTemplate.Height = 25;
            gridAlugueis.Size = new Size(448, 167);
            gridAlugueis.TabIndex = 4;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(394, 306);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 41);
            btnOk.TabIndex = 5;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // TelaAlugueisClienteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(491, 359);
            Controls.Add(btnOk);
            Controls.Add(gridAlugueis);
            Controls.Add(textBox1);
            Controls.Add(lblNome);
            Controls.Add(txtId);
            Controls.Add(lblId);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaAlugueisClienteForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Aluguéis do Cliente";
            ((System.ComponentModel.ISupportInitialize)gridAlugueis).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblId;
        private TextBox txtId;
        private Label lblNome;
        private TextBox textBox1;
        private DataGridView gridAlugueis;
        private Button btnOk;
    }
}