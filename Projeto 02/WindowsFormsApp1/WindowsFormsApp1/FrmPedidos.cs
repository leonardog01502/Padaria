using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmPedidos : Form
    {
        private decimal total = 0.00m;
        private Dictionary<string, decimal> precos = new Dictionary<string, decimal>();
        private List<Produto> produtos = new List<Produto>();

        public FrmPedidos()
        {
            InitializeComponent();
            InicializarPrecos();
        }

        private void InicializarPrecos()
        {
            precos.Add("Bolo", 10.00m);
            precos.Add("Pão", 2.50m);
            precos.Add("Suco", 5.00m);
            precos.Add("Refrigerante", 4.00m);
            precos.Add("Paçoca", 1.50m);
            precos.Add("Torta", 12.00m);
            precos.Add("Salgado", 3.00m);
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string produtoSelecionado = cbxProduto.SelectedItem?.ToString();
            int quantidade = (int)numeroQuantidade.Value;

            if (quantidade <= 0)
            {
                MessageBox.Show("A quantidade deve ser maior que zero.", "ATENÇÃO !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(produtoSelecionado))
            {
                string itemToAdd = $"{quantidade} x {produtoSelecionado}";
                listaProduto.Items.Add(itemToAdd);
            }
            else
            {
                MessageBox.Show("Produto selecionado não encontrado.", "ATENÇÃO !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarListBoxPedido()
        {
            listaProduto.Items.Clear();
            foreach (Produto produto in produtos)
            {
                listaProduto.Items.Add(produto.Nome);
            }
        }

        private decimal CalcularTotal()
        {
            decimal valorTotal = 0.00m;

            for (int i = 0; i < listaProduto.Items.Count; i++)
            {
                string item = listaProduto.Items[i].ToString();
                string[] partes = item.Split('x');

                if (partes.Length == 2)
                {
                    string nomeProduto = partes[1].Trim();
                    int quantidadeProdutos = int.Parse(partes[0].Trim());

                    if (precos.ContainsKey(nomeProduto))
                    {
                        decimal precoProduto = precos[nomeProduto];
                        valorTotal += (precoProduto * quantidadeProdutos);
                    }
                }
            }

            return valorTotal;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            decimal dinheiroRecebido;

            if (decimal.TryParse(txtDinheiro.Text, out dinheiroRecebido))
            {
                decimal valorTotal = CalcularTotal();

                decimal troco = dinheiroRecebido - valorTotal;

                if (troco >= 0)
                {
                    MessageBox.Show($"Troco: R$ {troco.ToString("0.00")}", "ATENÇÃO !!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Dinheiro insuficiente para pagar o pedido.", "ATENÇÃO !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Valor de dinheiro inválido.", "ATENÇÃO !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class Produto
        {
            public string Nome { get; }
            public decimal Preco { get; }

            public Produto(string nome, decimal preco)
            {
                Nome = nome;
                Preco = preco;
            }

            public override string ToString()
            {
                return $"{Nome} - R$ {Preco.ToString("0.00")}";
            }
        }
    }
}