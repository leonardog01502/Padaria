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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void FrmMenu_Shown(object sender, EventArgs e)
        {
            FrmSplash splash = new FrmSplash();
            splash.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Deseja realmente sair do programa !!!", "ATENÇÃO");
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmCadastro cadastro = new FrmCadastro();
            cadastro.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmPedidos pedidos = new FrmPedidos();
            pedidos.ShowDialog();
        }
    }
}
