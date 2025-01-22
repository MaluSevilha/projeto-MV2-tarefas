using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace projeto_MV2
{
    public partial class CreateTarefa : Form
    {
        public tarefa newTarefa;
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public int TarefaId { get; private set; }

        public CreateTarefa(int id, string titulo, string descricao, int concluido)
        {
            InitializeComponent();
            newTarefa = new tarefa(id, titulo, descricao, concluido);
            textboxTitulo.Text = titulo;
            textboxDescricao.Text = descricao;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            newTarefa.titulo = textboxTitulo.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            newTarefa.descricao = textboxDescricao.Text;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string connPath = "Server=localhost\\SQLEXPRESS;Integrated security=SSPI;database=GerenciadorDeTarefas";
            string queryUpdate = "UPDATE Tarefas SET titulo = @titulo, descricao = @descricao WHERE id = @id";
            string queryCreate = $@"INSERT INTO Tarefas VALUES ('{newTarefa.titulo}', '{newTarefa.descricao}', '{newTarefa.concluido}')";
            
            try
            {
                SqlConnection myConn = new SqlConnection(connPath);
                myConn.Open();
                string msg;
                SqlCommand command;

                if (newTarefa.id == -1)
                {
                    command = new SqlCommand(queryCreate, myConn);
                    msg = "Tarefa adicionada com sucesso!";

                }
                else
                {
                    command = new SqlCommand(queryUpdate, myConn);
                    command.Parameters.AddWithValue("@titulo", newTarefa.titulo);
                    command.Parameters.AddWithValue("@descricao", newTarefa.descricao);
                    command.Parameters.AddWithValue("@id", newTarefa.id);
                    msg = "Tarefa editada com sucesso!";
                }

                command.ExecuteNonQuery();
                MessageBox.Show(msg);
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar a tarefa: " + ex.Message);
            }

            this.Close();
        }
    }
}
