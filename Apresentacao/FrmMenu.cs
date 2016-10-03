using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apresentacao
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuCliente_Click(object sender, EventArgs e)
        {
            FrmClienteSelecionar frmClienteSelecionar = new FrmClienteSelecionar();
            //referenciando o pai do form
            frmClienteSelecionar.MdiParent = this;
            frmClienteSelecionar.Show();
        }
    }
}
