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
    public partial class FrmClienteCadastrar : Form
    {
        public FrmClienteCadastrar(AcaoNaTela acaoNaTela)
        {
            InitializeComponent();
            if (acaoNaTela ==AcaoNaTela.Inserir)
            {
                this.Text = "Inserir Clinte";
            }
            else if (acaoNaTela == AcaoNaTela.Alterar)
            {
                this.Text = "Alterar Clinte";
            }
            else if (acaoNaTela == AcaoNaTela.Consultar)
            {
                this.Text = "Consultar Clinte";
            }
            
        }
    }
}
