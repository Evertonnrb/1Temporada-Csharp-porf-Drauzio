using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using's para manipulação de dados no SQLServer
using System.Data;
using System.Data.SqlClient;
//apontando a classe de conexao
using AcessoBancoDados.Properties;

namespace AcessoBancoDados
{
    public class AcessoDadosSqlServer
    {
        

        
        //Criando conexao
        private SqlConnection CriarConexao()
        {
            return new SqlConnection(Settings.Default.stringConexao);
        }
        //Manipulando os parametros
        private SqlParameterCollection sqlParameterCollection = new SqlCommand().Parameters;
        public void LimparParametros()
        {
            //garantindo a limpeza do comando com clear nao coletar lixo da memória
            sqlParameterCollection.Clear();
        }
        //persistindo dados com  nomeParametro e valorParametro
        public void AdicionarParametros(string nomeParametro, object valorParametro)
        {
            sqlParameterCollection.Add(new SqlParameter(nomeParametro, valorParametro));
        }

        //Persistência
        public object ExecutarManipulacao(CommandType commandType, string nomeStoredeProcedureOuComandoSql)
        {
        
            try
            {
                //Criando a conexão
                SqlConnection sqlConnection = CriarConexao();
                //Abrindo a conexao
                sqlConnection.Open();
                //Criando o comando de persistencia
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nomeStoredeProcedureOuComandoSql;
                sqlCommand.CommandTimeout = 7200;
                //Adiciona os parametros  no comando
                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }
                //Executando o comando que irá levar os parametros para o banco de dados
                return sqlCommand.ExecuteScalar();

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
           //consultar dados
           public DataTable ExecutarConsulta(CommandType commandType,string nomeStoredeProcedureOuComandoSql)
        {
            try
            {
                //Criando a conexão
                SqlConnection sqlConnection = CriarConexao();
                //Abrindo a conexao
                sqlConnection.Open();
                //Criando o comando de persistencia
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nomeStoredeProcedureOuComandoSql;
                sqlCommand.CommandTimeout = 7200;
                //Adiciona os parametros  no comando
                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }
                //criando um adaptador
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                //INstaciando =  preenchendo o datatable
                DataTable dataTable = new DataTable();
                //Mandando o comando para o banco e executar a busca dos dados
                sqlDataAdapter.Fill(dataTable);

                return dataTable;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }


}
