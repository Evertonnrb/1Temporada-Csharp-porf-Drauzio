using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//usando as usings 
using Negocios;
using ObjetoTransferencia;

namespace Apresentacao
{
    public partial class FrmClienteSelecionar : Form
    {
        public FrmClienteSelecionar()
        {
            InitializeComponent();
            //avisando a aaplicação para nao gerar info no grid auto
            dataGridViewPrincipal.AutoGenerateColumns = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonPesquisa_Click(object sender, EventArgs e)
        {
            atualizarGrid();

        }

        private void atualizarGrid()
        {
            ClienteNegocios clienteNegocios = new ClienteNegocios();
            ClienteColecao clienteColecao = new ClienteColecao();
            clienteColecao = clienteNegocios.ConsultarPorNome(textBoxPesquisa.Text);
            dataGridViewPrincipal.DataSource = null;
            dataGridViewPrincipal.DataSource = clienteColecao;
            dataGridViewPrincipal.Update();
            dataGridViewPrincipal.Refresh();
        }

        private void buttonFechar_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        private void buttonExlcuir_Click(object sender, EventArgs e)
        {
            //Verificando se tem cliente selecionado
            if (dataGridViewPrincipal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhuma linha foi selecionada");
                return;
            }

            DialogResult resultado = MessageBox.Show("Certeza que deseja excluir? ", "Ação não pode ser desfeita ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(resultado == DialogResult.No)
            {
                return;
            }

            //convertendo o cliente com um casting grid para cliente
            Cliente clienteEnccontrado = (dataGridViewPrincipal.SelectedRows[0].DataBoundItem as Cliente);
            //Insância da regra de negocio
            ClienteNegocios clienteNegocios = new ClienteNegocios();
            //chamando o método para excuir
            string retorno = clienteNegocios.Excluir(clienteEnccontrado);
            try
            {
                int idCliente = Convert.ToInt32(retorno);
                MessageBox.Show("Cliente excluido com sucesso ", "Mensagem", MessageBoxButtons.OK);
                atualizarGrid();
            }
            catch (Exception )
            {

                MessageBox.Show("Não foi possivel realizar a operação " + retorno,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void buttonInserir_Click(object sender, EventArgs e)
        {
            //insciando cliente Inserir
            FrmClienteCadastrar frmClienteCadastrar = new FrmClienteCadastrar(AcaoNaTela.Inserir,null);
           DialogResult dialogResult = frmClienteCadastrar.ShowDialog();
            if(dialogResult == DialogResult.Yes)
            {
                atualizarGrid();
            }
        }

        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            //Verificando se tem cliente selecionado
            if (dataGridViewPrincipal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhuma linha foi selecionada");
                return;
            }
            //convertendo o cliente com um casting grid para cliente
            Cliente clienteEnccontrado = (dataGridViewPrincipal.SelectedRows[0].DataBoundItem as Cliente);

            //insciando cliente Alterar
            FrmClienteCadastrar frmClienteCadastrar = new FrmClienteCadastrar(AcaoNaTela.Alterar,clienteEnccontrado);
            DialogResult resultado = frmClienteCadastrar.ShowDialog();
            if(resultado == DialogResult.Yes)
            {
                atualizarGrid();
            }
        }

        private void buttonConsultar_Click(object sender, EventArgs e)
        {
            //Verificando se tem cliente selecionado
            if (dataGridViewPrincipal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhuma linha foi selecionada");
                return;
            }
            //convertendo o cliente com um casting grid para cliente
            Cliente clienteEnccontrado = (dataGridViewPrincipal.SelectedRows[0].DataBoundItem as Cliente);
            //insciando cliente Consultar
            FrmClienteCadastrar frmClienteCadastrar = new FrmClienteCadastrar(AcaoNaTela.Consultar,clienteEnccontrado);
            frmClienteCadastrar.ShowDialog();
        }
    }
}
