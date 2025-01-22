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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string masterConnection, databaseName, tableName, databaseQuery, tableQuery;

            masterConnection = "Server=localhost\\SQLEXPRESS;Integrated security=SSPI;database=master";
            databaseName = "GerenciadorDeTarefas";
            tableName = "Tarefas";
            databaseQuery = $@"
                        IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = '{databaseName}')
                        BEGIN
                            CREATE DATABASE {databaseName};
                        END";
            tableQuery = $@"
                         IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = '{tableName}' AND xtype = 'U')
                        BEGIN
                            CREATE TABLE {tableName} (
                                id INT PRIMARY KEY IDENTITY(1,1),
                                titulo NVARCHAR(100) NOT NULL,
                                descricao NVARCHAR(MAX),
                                concluido BIT NOT NULL DEFAULT 0
                            );
                        END";

            SqlConnection myConn = new SqlConnection(masterConnection);

            try
            {
                myConn.Open();

                SqlCommand createDatabase = new SqlCommand(databaseQuery, myConn);

                createDatabase.ExecuteNonQuery();

                myConn.ChangeDatabase(databaseName);
                SqlCommand createTable = new SqlCommand(tableQuery, myConn);

                createTable.ExecuteNonQuery();

                MessageBox.Show("Conctado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Main main = new Main();
                main.Show();
                this.Hide();

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }
    }
}
