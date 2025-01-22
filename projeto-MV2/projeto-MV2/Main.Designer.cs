using System.Windows.Forms;

namespace projeto_MV2
{
    partial class Main
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
            this.btnCreateTarefa = new System.Windows.Forms.Button();
            this.flowLayoutPanelTarefas = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // btnCreateTarefa
            // 
            this.btnCreateTarefa.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCreateTarefa.Location = new System.Drawing.Point(274, 402);
            this.btnCreateTarefa.Name = "btnCreateTarefa";
            this.btnCreateTarefa.Size = new System.Drawing.Size(244, 36);
            this.btnCreateTarefa.TabIndex = 1;
            this.btnCreateTarefa.Text = "Adicionar uma Tarefa";
            this.btnCreateTarefa.UseVisualStyleBackColor = true;
            this.btnCreateTarefa.Click += new System.EventHandler(this.btnCreateTarefa_Click);
            // 
            // flowLayoutPanelTarefas
            // 
            this.flowLayoutPanelTarefas.AutoScroll = true;
            this.flowLayoutPanelTarefas.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelTarefas.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanelTarefas.Name = "flowLayoutPanelTarefas";
            this.flowLayoutPanelTarefas.Size = new System.Drawing.Size(775, 370);
            this.flowLayoutPanelTarefas.TabIndex = 2;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanelTarefas);
            this.Controls.Add(this.btnCreateTarefa);
            this.Name = "Main";
            this.Text = "Gerenciador de Tarefas";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.FormClosed += (s, e) => Application.Exit();


        }

        #endregion
        private System.Windows.Forms.Button btnCreateTarefa;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTarefas;
    }
}