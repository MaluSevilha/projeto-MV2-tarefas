using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace projeto_MV2
{
    public partial class Main : Form
    {
        private string connPath = "Server=localhost\\SQLEXPRESS;Integrated security=SSPI;database=GerenciadorDeTarefas";
        private string queryLoad = "SELECT id, titulo, descricao, concluido FROM Tarefas";

        public Main()
        {
            InitializeComponent();
            this.Resize += (s, e) => AjustarLayout();
            LoadTarefas();

        }

        public void LoadTarefas()
        {
            flowLayoutPanelTarefas.Controls.Clear();

            try
            {
                SqlConnection myConn = new SqlConnection(connPath);
                try
                {
                    myConn.Open();

                    SqlCommand command = new SqlCommand(queryLoad, myConn);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int concluido;

                        int id = reader.GetInt32(0);
                        string titulo = reader.GetString(1);
                        string descricao = reader.GetString(2);
                        bool concluido_booleano = reader.GetBoolean(3);

                        if (concluido_booleano)
                        {
                            concluido = 1;
                        }
                        else
                        {
                            concluido = 0;
                        }

                        AdicionarPainelTarefa(id, titulo, descricao, concluido);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar as tarefas: " + ex.Message);
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            AjustarLayout();
        }

        private void btnCreateTarefa_Click(object sender, EventArgs e)
        {
            CreateTarefa formCreate = new CreateTarefa(-1, "", "", 0);
            formCreate.FormClosed += (s, args) => LoadTarefas(); 
            formCreate.ShowDialog(); 
        }

        private void EditarTarefa(int id, string tituloAtual, string descricaoAtual, int concluido)
        {
            CreateTarefa formEdit = new CreateTarefa(id, tituloAtual, descricaoAtual, concluido);
            formEdit.FormClosed += (s, args) => LoadTarefas();
            formEdit.ShowDialog();
        }


        private void AdicionarPainelTarefa(int id, string titulo, string descricao, int concluido)
        {
            // Criar um novo painel para a tarefa
            Panel panelTarefa = new Panel();
            panelTarefa.Size = new Size(350, 100);
            panelTarefa.BorderStyle = BorderStyle.FixedSingle;
            panelTarefa.Margin = new Padding(5);
            if (concluido == 0)
            {
                panelTarefa.BackColor = Color.White;
            }
            else
            {
                panelTarefa.BackColor = Color.LightGray;
            }
            

            // Título
            TextBox txtTitulo = new TextBox();
            txtTitulo.Text = titulo;
            txtTitulo.Font = new Font("Arial", 10, FontStyle.Bold);
            txtTitulo.Location = new Point(10, 10);
            txtTitulo.Size = new Size(150, 20);
            txtTitulo.ReadOnly = true;
            txtTitulo.BackColor = Color.White;
            panelTarefa.Controls.Add(txtTitulo);

            // Descrição    
            TextBox txtDescricao = new TextBox();
            txtDescricao.Text = descricao;
            txtDescricao.Font = new Font("Arial", 9, FontStyle.Regular);
            txtDescricao.Location = new Point(10, 40);
            txtDescricao.Size = new Size(200, 20);
            txtDescricao.ReadOnly = true;
            txtDescricao.BackColor = Color.White;
            panelTarefa.Controls.Add(txtDescricao);

            // Botão "Deletar" com imagem
            Button btnDelete = new Button();
            btnDelete.Image = new Bitmap(Properties.Resources.delete, new Size(24, 24));
            btnDelete.Size = new Size(30, 30);
            btnDelete.Location = new Point(310, 10);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.BackColor = Color.Red;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0; // Remove bordas
            btnDelete.Click += (s, e) => DeletarTarefa(id);
            panelTarefa.Controls.Add(btnDelete);

            // Botão "Editar" com imagem
            Button btnEdit = new Button();
            btnEdit.Image = new Bitmap(Properties.Resources.edit, new Size(24, 24));
            btnEdit.Size = new Size(30, 30);
            btnEdit.Location = new Point(310, 45);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.FlatAppearance.BorderSize = 0; // Remove bordas
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Click += (s, e) => EditarTarefa(id, titulo, descricao, concluido);
            panelTarefa.Controls.Add(btnEdit);

            // Adicionar o painel ao FlowLayoutPanel na tela
            flowLayoutPanelTarefas.Controls.Add(panelTarefa);

            // Checkbox "Concluir Tarefa"
            CheckBox chkConcluir = new CheckBox();
            chkConcluir.Text = "Concluir";
            chkConcluir.Font = new Font("Arial", 9, FontStyle.Regular);
            chkConcluir.Location = new Point(10, 70);
            chkConcluir.Checked = concluido == 1;  // Marcar se concluído no banco
            chkConcluir.CheckedChanged += (s, e) =>
            {
                if (chkConcluir.Checked)
                {
                    panelTarefa.BackColor = Color.LightGray;  // Mudar para cinza claro
                    AtualizarStatusTarefa(id, 1);  // Atualiza no banco para concluído (1)
                }
                else
                {
                    panelTarefa.BackColor = Color.White;  // Voltar para branco
                    AtualizarStatusTarefa(id, 0);  // Atualiza no banco para não concluído (0)
                }
            };
            panelTarefa.Controls.Add(chkConcluir);
        }

        void AtualizarStatusTarefa(int id, int status)
        {
            string query = "UPDATE tarefas SET concluido = @status WHERE id = @id";
            using (SqlConnection conn = new SqlConnection(connPath))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void DeletarTarefa(int id)
        {
            DialogResult result = MessageBox.Show("Deseja realmente excluir esta tarefa?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection myConn = new SqlConnection(connPath))
                {
                    string queryDelete = "DELETE FROM Tarefas WHERE id = @id";
                    SqlCommand command = new SqlCommand(queryDelete, myConn);
                    command.Parameters.AddWithValue("@id", id);

                    try
                    {
                        myConn.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Tarefa excluída com sucesso!");
                        LoadTarefas(); // Recarregar a interface após exclusão
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao excluir tarefa: " + ex.Message);
                    }
                }
            }
        }

        private void AjustarLayout()
        {
            int margemInferior = 20;  // Aumentando a margem para mais espaço

            flowLayoutPanelTarefas.Top = 10;
            flowLayoutPanelTarefas.Left = 10;
            flowLayoutPanelTarefas.Width = this.ClientSize.Width - 20;

            // Ajusta a altura para garantir espaço suficiente para o botão
            flowLayoutPanelTarefas.Height = this.ClientSize.Height - btnCreateTarefa.Height - margemInferior - 50;

            // Garante que o botão esteja sempre visível
            btnCreateTarefa.Top = flowLayoutPanelTarefas.Bottom + 10;
            btnCreateTarefa.Left = (this.ClientSize.Width - btnCreateTarefa.Width) / 2;
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
