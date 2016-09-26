using System;
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
            String idCliente = acessoBancoDados.ExecutarManipulacao(System.Data.CommandType.StoredProcedure,"uspClienteInserir").ToString();
            return idCliente;
            }
            catch (Exception exe)
            {
                return exe.Message;
            }
        }
    }
}
