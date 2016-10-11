using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObjetoTransferencia;
using Negocios;

namespace Apresentacao
{
    public partial class FrmClienteCadastrar : Form
    {
        AcaoNaTela acaoNaTelaSelecionado;
        //Construtor com enumerador com parametro
        public FrmClienteCadastrar(AcaoNaTela acaoNaTela, Cliente cliente)
        {
            InitializeComponent();

            this.acaoNaTelaSelecionado = acaoNaTela;

            if (acaoNaTela ==AcaoNaTela.Inserir)
            {
                this.Text = "Inserir Cliente";
            }
            else if (acaoNaTela == AcaoNaTela.Alterar)
            {
                this.Text = "Alterar Cliente";
                textBoxCodigo.Text = cliente.IdCiente.ToString();
                textBoxNome.Text = cliente.Nome;
                dateDataNascimento.Value = cliente.DataNascimento;
                if (cliente.Sexo == true)
                    radioButtonMas.Checked = true;
                else
                    radioButtonFem.Checked = true;
                textBoxLimite.Text = cliente.LimiteCompra.ToString();

            }
            else if (acaoNaTela == AcaoNaTela.Consultar)
            {
                this.Text = "Consultar Cliente";
                textBoxNome.Enabled = false;
                //Carregando os campos da tela
                textBoxCodigo.Text = cliente.IdCiente.ToString();
                textBoxNome.Text = cliente.Nome;
                dateDataNascimento.Value = cliente.DataNascimento;

                if (cliente.Sexo == true)
                    radioButtonMas.Checked = true;
                else
                    radioButtonFem.Checked = true;

                textBoxLimite.Text = cliente.LimiteCompra.ToString();
                //Desabilitando os campos da tela
                textBoxNome.ReadOnly=true;
                textBoxNome.TabStop = false;
                dateDataNascimento.Enabled = false;
                radioButtonMas.Enabled = false;
                radioButtonFem.Enabled = false;
                textBoxLimite.ReadOnly = true;
                textBoxLimite.TabStop = false;
                //Editando action dos botoes
                buttonSalvar.Visible = false;
                buttonCancelar.Text = "Fechar";
                buttonCancelar.Focus();
            }

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            //Verificando se é alteração ou inserção
            if(acaoNaTelaSelecionado == AcaoNaTela.Inserir)
            {
                //Instanciando o objeto cliente
                Cliente cliente = new Cliente();
                cliente.Nome = textBoxNome.Text;
                cliente.DataNascimento = dateDataNascimento.Value;
                if(radioButtonMas.Checked == true)
                {
                    cliente.Sexo = true;
                }
                else
                {
                    cliente.Sexo = false;
                }
                cliente.LimiteCompra = Convert.ToDecimal(textBoxLimite.Text);
                //Utilizando a regra de negocios para persistir o cliente
                ClienteNegocios clienteNegocios = new ClienteNegocios();
                string retorno = clienteNegocios.Inserir(cliente);
                //Experado na persistencia =  Convert.int , cod como retorno, excption
                try
                {
                    int idCliente = Convert.ToInt32(retorno);
                    MessageBox.Show("Cliente inserido com sucesso " + idCliente.ToString());
                    this.DialogResult = DialogResult.Yes;
                }
                catch (Exception)
                {

                    MessageBox.Show("Não foi possível realiza a operação. Detalhes: " + retorno, "Erro",MessageBoxButtons.OK ,MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.No;
                }
            }
            else if (acaoNaTelaSelecionado == AcaoNaTela.Alterar)
            {

            }
        }

        private void textBoxLimite_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
