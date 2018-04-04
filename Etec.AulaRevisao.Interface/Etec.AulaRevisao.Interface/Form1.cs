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
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Password=info211;Persist Security Info=True;User ID=sa;Initial Catalog=registro;Data Source=LAB-08-07");
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
            MessageBox.Show("Campos Foram Limpos","Teste");
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtCargo.Text == "" || txtNome.Text == "")
            {
                MessageBox.Show("Todos os campos devem ser preenchidos", "Etec ZL");
            }
            else
            {
                String salario = mtxtSalario.Text, cpf = mtxtCpf.Text;
                salario = salario.Replace("R", "");
                salario = salario.Replace("$", "");
                cpf = cpf.Replace(".", "");
                cpf = cpf.Replace(",", "");
                cpf = cpf.Replace("-", "");
                String sql = "insert into cadastros (nome, cargo, salario, cpf) values ('" + txtNome.Text + "','" + txtCargo.Text + "','"+salario+"','"+cpf+"');";
                SqlCommand comando = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    comando.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Cadastro Realizado!!\n" + sql);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Cadastro Não Realizado!!\n" + sql);
                    DisplaySqlErrors(ex);
                }
            }
        }

        private static void DisplaySqlErrors(SqlException ex)
        {
            for(int i=0;i<ex.Errors.Count;i++)
            {
                MessageBox.Show("Index #" + i + "\n" + "Error: " + ex.Errors[i].ToString() + "\n");
            }
        }

        private void limparCampos()
        {
            txtCargo.Text = "";
            txtNome.Text = "";
        }
    }
}
