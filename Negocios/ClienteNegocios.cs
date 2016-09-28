using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoBancoDados;
using ObjetoTransferencia;
namespace Negocios
{
    public  class ClienteNegocios
    {
        AcessoDadosSqlServer acessoBancoDados = new AcessoDadosSqlServer();
        
        public string Inserir(Cliente cliente)
        {
            try
            { 
            acessoBancoDados.LimparParametros();
            acessoBancoDados.AdicionarParametros("@Nome",cliente.Nome);
            acessoBancoDados.AdicionarParametros("@DataNascimento", cliente.DataNascimento);
            acessoBancoDados.AdicionarParametros("Sexo", cliente.Sexo);
            acessoBancoDados.AdicionarParametros("@LimiteCompra", cliente.LimiteCompra);
            //retorando o id cliento e confirmado assert ou erro
            String idCliente = acessoBancoDados.ExecutarManipulacao(CommandType.StoredProcedure,"uspClienteInserir").ToString();
            return idCliente;
            }
            catch (Exception exe)
            {
                return exe.Message;
            }
        }
        public string Alterar (Cliente cliente)
        {
            try
            {
                acessoBancoDados.LimparParametros();
                acessoBancoDados.AdicionarParametros("@IdCliente", cliente.IdCiente);
                acessoBancoDados.AdicionarParametros("@Nome", cliente.Nome);
                acessoBancoDados.AdicionarParametros("@DataNascimento", cliente.DataNascimento);
                acessoBancoDados.AdicionarParametros("@Sexo", cliente.Sexo);
                acessoBancoDados.AdicionarParametros("@LimiteCompra", cliente.LimiteCompra);
                String idCliente =  acessoBancoDados.ExecutarManipulacao(CommandType.StoredProcedure, "uspClienteAlterar").ToString();
                return idCliente;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Excluir(Cliente cliente)
        {
            try
            {
                acessoBancoDados.LimparParametros();
                acessoBancoDados.AdicionarParametros("@IdCliente", cliente.IdCiente);
                string idCliente = acessoBancoDados.ExecutarManipulacao(CommandType.StoredProcedure, "uspClienteExcluir").ToString();
                return idCliente;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public ClienteColecao ConsultarPorNome(string nome)
        {
            try
            {
                ClienteColecao clienteColecao = new ClienteColecao();

                acessoBancoDados.LimparParametros();
                acessoBancoDados.AdicionarParametros("@Nome", nome);
                DataTable dataTableCliente = acessoBancoDados.ExecutarConsulta(CommandType.StoredProcedure, "uspClienteConsultarPorNome");
                foreach (DataRow linha in dataTableCliente.Rows)
                {
                    //montando o cliente
                    Cliente cliente = new Cliente();
                    cliente.IdCiente = Convert.ToInt32(linha["IdCliente"]);
                    cliente.Nome = Convert.ToString(linha["Nome"]);
                    cliente.DataNascimento = Convert.ToDateTime(linha["DataNascimento"]);
                    cliente.Sexo = Convert.ToBoolean(linha["Sexo"]);
                    cliente.LimiteCompra = Convert.ToDecimal(linha["LimiteCompra"]);

                    clienteColecao.Add(cliente);
                }
                return clienteColecao;
            }
            catch (Exception ex)
            {
                //enviando a mensagem de erro para tela, nesse caso nao tem jeito tem q dar um trow new Excption
                 throw new  Exception("Não foi possivel realizar a consulta, detalhes do erro :"+ex.Message);
            }
        }
        public ClienteColecao ConsultarPotId(int idCliente)
        {
            try
            {
                ClienteColecao clienteColecao = new ClienteColecao();
                acessoBancoDados.LimparParametros();
                acessoBancoDados.AdicionarParametros("@IdCliente", idCliente);
                DataTable dataTableCliente = acessoBancoDados.ExecutarConsulta(CommandType.StoredProcedure, "uspClienteConsultarPorId");

                foreach (DataRow linha in dataTableCliente.Rows)
                {
                    Cliente cliente = new Cliente();
                    cliente.IdCiente = Convert.ToInt32(linha["idCliente"]);
                    cliente.Nome = Convert.ToString(linha["Nome"]);
                    cliente.DataNascimento = Convert.ToDateTime(linha["DataNascimento"]);
                    cliente.Sexo = Convert.ToBoolean(linha["Sexo"]);
                    cliente.LimiteCompra = Convert.ToDecimal(linha["LimiteCompra"]);

                    clienteColecao.Add(cliente);
                }
                return clienteColecao;
            }
            catch (Exception ex)
            {

                throw new Exception("Não foi possivel localizar o id do cliente, detalhes do erro: "+ex.Message);
            }
        }

    }
   

}
