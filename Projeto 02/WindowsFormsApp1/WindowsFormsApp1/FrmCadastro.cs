using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmCadastro : Form
    {
        public FrmCadastro()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public class Cliente
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string CPF { get; set; }
            public string DataNascimento { get; set; }

            public Cliente(int id, string nome, string cpf, string dataNascimento)
            {
                Id = id; 
                Nome = nome;
                CPF = cpf;
                DataNascimento = dataNascimento;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string idText = txtID.Text;
            string nome = txtNome.Text;
            string cpf = mtdCPF.Text;
            string dataNascimento = mtdDataDeNascimento.Text;

            if (string.IsNullOrEmpty(idText) || string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(cpf) || string.IsNullOrEmpty(dataNascimento))
            {
                MessageBox.Show("Por favor, preencha todos os campos antes de cadastrar.");
                return;
            }

            if (!int.TryParse(idText, out int idCliente))
            {
                MessageBox.Show("ID de cliente inválido. Por favor, insira um número válido.");
                return;
            }

            Cliente novoCliente = new Cliente(idCliente, nome, cpf, dataNascimento);

            txtID.Clear();
            txtNome.Clear();
            mtdCPF.Clear();
            mtdDataDeNascimento.Clear();

            MessageBox.Show("Cadastro realizado com sucesso!");
        }
    }
}