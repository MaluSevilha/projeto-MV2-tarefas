using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace projeto_MV2
{
    public class tarefa
    {
        public int id { get; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public int concluido { get; set; }

        public tarefa(int id, string titulo, string descricao, int concluido)
        {
            this.id = id;
            this.titulo = titulo;
            this.descricao = descricao;
            this.concluido = concluido;
        }

        // Método para atualizar o elemento no banco de dados
        public void Update(string connPath)
        {
            string queryUpdate;
            queryUpdate = "UPDATE Tarefas SET titulo = @titulo, descricao = @descricao, concluido = @concluido WHERE id = @id";

            try
            {
                SqlConnection connTable = new SqlConnection(connPath);

                try
                {
                    connTable.Open();
                    SqlCommand commandUpdate = new SqlCommand(queryUpdate, connTable);
                    commandUpdate.Parameters.AddWithValue("@titulo", titulo);
                    commandUpdate.Parameters.AddWithValue("@descricao", descricao);
                    commandUpdate.Parameters.AddWithValue("@concluido", concluido);
                    commandUpdate.Parameters.AddWithValue("@id", id);

                    MessageBox.Show("Atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar: {ex.Message}");
            }
        }

        // Método para excluir o elemento do banco de dados
        public void Delete(string connPath)
        {
            string queryDelete;
            queryDelete = "DELETE FROM Tarefas WHERE id = @id";

            try
            {
                SqlConnection connTable = new SqlConnection(connPath);

                try
                {
                    connTable.Open();

                    SqlCommand commandDelete = new SqlCommand(queryDelete, connTable);
                    commandDelete.Parameters.AddWithValue("@id", id);
                    
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao excluir: {ex.Message}");
            }
        }

    }
}
