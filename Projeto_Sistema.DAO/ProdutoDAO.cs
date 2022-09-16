using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Sistema.DAO;
using Projeto_Sistema.Entidades;
using System.Data;
using Projeto_Sistem.Entidades;

namespace Projeto_Sistema.DAO
{
    public class ProdutoDAO
    {
        public List<ProdutoEnt> lista()
        {
            using (SqlConnection con = new SqlConnection())
            {
                //Conexão BD
                con.ConnectionString = Properties.Settings.Default.banco;//add Default

                SqlCommand cn = new SqlCommand();

                //Tipo de command text
                cn.CommandType = CommandType.Text;

                //Iniciar Conexão BD - .ConnectionString
                con.Open();

                //Comando Sql_Server - Decrescente: DESC, Alfabetica: ASC
                cn.CommandText = "SELECT * from tb_produtos ORDER BY id_produto DESC";//ORDER BY = TIPO DE ORDENAÇÃO

                //Associando .ConnectionString c/ .CommandType
                cn.Connection = con;

                //Consula de dados - SqlDataReader
                SqlDataReader dr;

                List<ProdutoEnt> lista = new List<ProdutoEnt>();
                //Trazer dados da conexão p? reader
                dr = cn.ExecuteReader();//Executar reader

                //Verificar se existe linhas - .HasRows
                if (dr.HasRows)
                {
                    //Verificar dados dentro DataReader
                    while (dr.Read())
                    {
                        ProdutoEnt dado = new ProdutoEnt();

                        //Receber dados campo
                        dado.Id = Convert.ToInt32(dr["id_produto"]);
                        dado.Nome_produto = Convert.ToString(dr["nomeProduto"]);
                        dado.Descricao = Convert.ToString(dr["descricao_produto"]);
                        dado.Valor = Convert.ToInt32(dr["valor"]);

                        //Add lista na grid
                        lista.Add(dado);
                    }
                }
                return lista;
            }
        }

        public List<ProdutoEnt> Buscar(ProdutoEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                //Conexão BD
                con.ConnectionString = Properties.Settings.Default.banco;//add Default

                SqlCommand cn = new SqlCommand();

                //Tipo de command text
                cn.CommandType = CommandType.Text;

                //Iniciar Conexão BD - .ConnectionString
                con.Open();

                //Comando Sql_Server -                     onde       Busca aproximada
                cn.CommandText = "SELECT * from tb_produtos WHERE nomeProduto LIKE @nomeProduto";

                //Parametro
                //%Hugo Vasconcelos = Pesquisa todo o dados
                //Hugo Vasconcelos% = Inìcio igual
                cn.Parameters.Add("nomeProduto", SqlDbType.VarChar).Value = objTabela.Nome_produto + "%";

                //Associando .ConnectionString c/ .CommandType
                cn.Connection = con;

                //Consula de dados - SqlDataReader
                SqlDataReader dr;

                List<ProdutoEnt> lista = new List<ProdutoEnt>();
                //Trazer dados da conexão p? reader
                dr = cn.ExecuteReader();//Executar reader

                //Verificar se existe linhas - .HasRows
                if (dr.HasRows)
                {
                    //Verificar dados dentro DataReader
                    while (dr.Read())
                    {
                        ProdutoEnt dado = new ProdutoEnt();

                        //Receber dados campo
                        dado.Id = Convert.ToInt32(dr["id_produto"]);
                        dado.Nome_produto = Convert.ToString(dr["nomeProduto"]);
                        dado.Descricao = Convert.ToString(dr["descricao_produto"]);
                        dado.Valor = Convert.ToDecimal(dr["valor"]);

                        //Add lista na grid
                        lista.Add(dado);
                    }
                }
                return lista;
            }
        }

        public int Editar(ProdutoEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                //Conexão BD
                con.ConnectionString = Properties.Settings.Default.banco;//add Default

                SqlCommand cn = new SqlCommand();

                //Tipo de command text
                cn.CommandType = CommandType.Text;

                //Iniciar Conexão BD - .ConnectionString
                con.Open();

                //Comando Sql_Server                 onde o campo                                        quando / condição
                cn.CommandText = "UPDATE tb_produtos SET nomeProduto = @nomeProduto, descricao_produto = @descricao_produto, valor = @valor where id_produto = @id_produto";

                //Parametros
                cn.Parameters.Add("nomeProduto", SqlDbType.VarChar).Value = objTabela.Nome_produto;
                cn.Parameters.Add("descricao_produto", SqlDbType.VarChar).Value = objTabela.Descricao;
                cn.Parameters.Add("valor", SqlDbType.Decimal).Value = objTabela.Valor;
                cn.Parameters.Add("id_produto", SqlDbType.Int).Value = objTabela.Id;

                //Associando .ConnectionString c/ .CommandType
                cn.Connection = con;

                //Exexutar CommandType - .ExecuteNonQuery()
                int qtd = cn.ExecuteNonQuery();//recebe nº 0/1 registro BD

                return qtd;
            }
        }

        public int Excluir(ProdutoEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                //Conexão BD
                con.ConnectionString = Properties.Settings.Default.banco;//add Default

                SqlCommand cn = new SqlCommand();

                //Tipo de command text
                cn.CommandType = CommandType.Text;

                //Iniciar Conexão BD - .ConnectionString
                con.Open();

                //Comando Sql_Server                     onde  id seja = @parametro
                cn.CommandText = "DELETE FROM tb_produtos where id_produto = @id_produto";

                //Parametros
                cn.Parameters.Add("id_produto", SqlDbType.Int).Value = objTabela.Id;

                //Associando .ConnectionString c/ .CommandType
                cn.Connection = con;

                //Exexutar CommandType - .ExecuteNonQuery()
                int qtd = cn.ExecuteNonQuery();//recebe nº 0/1 registro BD

                return qtd;
            }
        }

        public int Inserir(ProdutoEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                //Conexão BD
                con.ConnectionString = Properties.Settings.Default.banco;//add Default

                SqlCommand cn = new SqlCommand();

                //Tipo de command text
                cn.CommandType = CommandType.Text;

                //Iniciar Conexão BD - .ConnectionString
                con.Open();

                //Comando Sql_Server                     ( valores.nomes dos campos )        ( Valores ser inseridos )
                cn.CommandText = "INSERT INTO tb_produtos ([nomeProduto], [descricao_produto], [valor]) VALUES (@nomeProduto, @descricao_produto, @valor)";

                //Parametros
                cn.Parameters.Add("nomeProduto", SqlDbType.VarChar).Value = objTabela.Nome_produto;
                cn.Parameters.Add("descricao_produto", SqlDbType.VarChar).Value = objTabela.Descricao;
                cn.Parameters.Add("valor", SqlDbType.Decimal).Value = objTabela.Valor;

                //Associando .ConnectionString c/ .CommandType
                cn.Connection = con;

                //Exexutar CommandType - .ExecuteNonQuery()
                int qtd = cn.ExecuteNonQuery();//recebe nº 0/1 registro BD

                return qtd;
            }
        }
    }
}
