using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Etec.AulaRevisao.Interface
{
    public partial class ConsultaFuncionario : Form
    {
        SqlConnection conn = new SqlConnection("Password=info211;Persist Security Info=True;User ID=sa;Initial Catalog=registro;Data Source=LAB-08-07");
        public ConsultaFuncionario()
        {
            InitializeComponent();
        }

        private void ConsultaFuncionario_Load(object sender, EventArgs e)
        {
            String sql = "select * from cadastros";
            SqlDataAdapter adaptador = new SqlDataAdapter(sql, conn);
            DataSet datasetCliente = new DataSet();
            adaptador.Fill(datasetCliente);
            dgvFuncionario.DataSource = datasetCliente;
            dgvFuncionario.DataMember = datasetCliente.Tables[0].TableName;

            conn.Close();
        }

        private void btnCadastrarFuncionario_Click(object sender, EventArgs e)
        {
            Form1 tt = new Form1();
            tt.Show();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            String sql = "select * from cadastros";
            SqlDataAdapter adaptador = new SqlDataAdapter(sql, conn);
            DataSet datasetCliente = new DataSet();
            adaptador.Fill(datasetCliente);
            dgvFuncionario.DataSource = datasetCliente;
            dgvFuncionario.DataMember = datasetCliente.Tables[0].TableName;

            conn.Close();
        }
    }
}
