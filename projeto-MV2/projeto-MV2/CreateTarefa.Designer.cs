
namespace projeto_MV2
{
    partial class CreateTarefa
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
            this.btnEnviar = new System.Windows.Forms.Button();
            this.textboxTitulo = new System.Windows.Forms.TextBox();
            this.textboxDescricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEnviar.Location = new System.Drawing.Point(22, 162);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(104, 33);
            this.btnEnviar.TabIndex = 0;
            this.btnEnviar.Text = "Confirmar";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // textboxTitulo
            // 
            this.textboxTitulo.Location = new System.Drawing.Point(22, 25);
            this.textboxTitulo.Name = "textboxTitulo";
            this.textboxTitulo.Size = new System.Drawing.Size(348, 20);
            this.textboxTitulo.TabIndex = 1;
            this.textboxTitulo.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textboxDescricao
            // 
            this.textboxDescricao.Location = new System.Drawing.Point(22, 78);
            this.textboxDescricao.Multiline = true;
            this.textboxDescricao.Name = "textboxDescricao";
            this.textboxDescricao.Size = new System.Drawing.Size(348, 78);
            this.textboxDescricao.TabIndex = 2;
            this.textboxDescricao.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Título";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Descrição";
            // 
            // CreateTarefa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 207);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textboxDescricao);
            this.Controls.Add(this.textboxTitulo);
            this.Controls.Add(this.btnEnviar);
            this.Name = "CreateTarefa";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox textboxTitulo;
        private System.Windows.Forms.TextBox textboxDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}