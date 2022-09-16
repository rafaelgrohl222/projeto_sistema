using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Sistema.DAO;
using Projeto_Sistema.Entidades;
using System.Data;

namespace Projeto_Sistema.DAO
{
    public class UsuarioDAO
    {
        public int Inserir(UsuarioEnt objTabela)
        {
            using(SqlConnection con = new SqlConnection())
            {
                //Conexão BD
                con.ConnectionString = Properties.Settings.Default.banco;//add Default

                SqlCommand cn = new SqlCommand();

                //Tipo de command text
                cn.CommandType = CommandType.Text;

                //Iniciar Conexão BD - .ConnectionString
                con.Open();

                //Comando Sql_Server                     ( valores.nomes dos campos )        ( Valores ser inseridos )
                cn.CommandText = "INSERT INTO tb_usuario ([nome], [usuario], [senha]) VALUES (@nome, @usuario, @senha)";

                //Parametros
                cn.Parameters.Add("nome", SqlDbType.VarChar).Value = objTabela.Nome;
                cn.Parameters.Add("usuario", SqlDbType.VarChar).Value = objTabela.Usuario;
                cn.Parameters.Add("senha", SqlDbType.VarChar).Value = objTabela.Senha;

                //Associando .ConnectionString c/ .CommandType
                cn.Connection = con;

                //Exexutar CommandType - .ExecuteNonQuery()
                int qtd = cn.ExecuteNonQuery();//recebe nº 0/1 registro BD

                return qtd;
            }
        }

        public List<UsuarioEnt> Buscar(UsuarioEnt objTabela)
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
                cn.CommandText = "SELECT * from tb_usuario WHERE nome LIKE @nome";

                //Parametro
                //%Hugo Vasconcelos = Pesquisa todo o dados
                //Hugo Vasconcelos% = Inìcio igual
                cn.Parameters.Add("nome",SqlDbType.VarChar).Value = objTabela.Nome + "%";

                //Associando .ConnectionString c/ .CommandType
                cn.Connection = con;

                //Consula de dados - SqlDataReader
                SqlDataReader dr;

                List<UsuarioEnt> lista = new List<UsuarioEnt>();
                //Trazer dados da conexão p? reader
                dr = cn.ExecuteReader();//Executar reader

                //Verificar se existe linhas - .HasRows
                if (dr.HasRows)
                {
                    //Verificar dados dentro DataReader
                    while (dr.Read())
                    {
                        UsuarioEnt dado = new UsuarioEnt();

                        //Receber dados campo
                        dado.Id = Convert.ToInt32(dr["id_usuario"]);
                        dado.Nome = Convert.ToString(dr["nome"]);
                        dado.Usuario = Convert.ToString(dr["usuario"]);
                        dado.Senha = Convert.ToString(dr["senha"]);

                        //Add lista na grid
                        lista.Add(dado);
                    }
                }
                return lista;
            }
        }

        public int Editar(UsuarioEnt objTabela)
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
                cn.CommandText = "UPDATE tb_usuario SET nome = @nome, usuario = @usuario, senha = @senha where id_usuario = @id_usuario";

                //Parametros
                cn.Parameters.Add("nome", SqlDbType.VarChar).Value = objTabela.Nome;
                cn.Parameters.Add("usuario", SqlDbType.VarChar).Value = objTabela.Usuario;
                cn.Parameters.Add("senha", SqlDbType.VarChar).Value = objTabela.Senha;
                cn.Parameters.Add("id_usuario", SqlDbType.Int).Value = objTabela.Id;

                //Associando .ConnectionString c/ .CommandType
                cn.Connection = con;

                //Exexutar CommandType - .ExecuteNonQuery()
                int qtd = cn.ExecuteNonQuery();//recebe nº 0/1 registro BD

                return qtd;
            }
        }

        public int Excluir(UsuarioEnt objTabela)
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
                cn.CommandText = "DELETE FROM tb_usuario where id_usuario = @id";

                //Parametros
                cn.Parameters.Add("id", SqlDbType.Int).Value = objTabela.Id;

                //Associando .ConnectionString c/ .CommandType
                cn.Connection = con;

                //Exexutar CommandType - .ExecuteNonQuery()
                int qtd = cn.ExecuteNonQuery();//recebe nº 0/1 registro BD

                return qtd;
            }
        }

        public UsuarioEnt Login(UsuarioEnt obj)
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

                //Comando Sql_Server -                     onde  usuario = parametro "E" senha  = parametro
                cn.CommandText = "SELECT * from tb_usuario where usuario = @usuario AND senha = @senha";//ORDER BY = TIPO DE ORDENAÇÃO

                //Associando .ConnectionString c/ .CommandType
                cn.Connection = con;

                //Parametros
                cn.Parameters.Add("usuario", SqlDbType.VarChar).Value = obj.Usuario;
                cn.Parameters.Add("senha", SqlDbType.VarChar).Value = obj.Senha;

                //Consula de dados - SqlDataReader
                SqlDataReader dr;

                //Trazer dados da conexão p/ reader
                dr = cn.ExecuteReader();//Executar reader

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        UsuarioEnt dado = new UsuarioEnt();

                        dado.Usuario = Convert.ToString(dr["usuario"]);
                        dado.Senha = Convert.ToString(dr["senha"]);
                    }
                }
                //Não recebe valor
                else
                {
                    obj.Usuario = null;
                    obj.Senha = null;
                }
                return obj;
            }
        }

        public List<UsuarioEnt> lista()
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
                cn.CommandText = "SELECT * from tb_usuario ORDER BY id_usuario DESC";//ORDER BY = TIPO DE ORDENAÇÃO

                //Associando .ConnectionString c/ .CommandType
                cn.Connection = con;

                //Consula de dados - SqlDataReader
                SqlDataReader dr;

                List<UsuarioEnt> lista = new List<UsuarioEnt>();
                //Trazer dados da conexão p? reader
                dr = cn.ExecuteReader();//Executar reader

                //Verificar se existe linhas - .HasRows
                if (dr.HasRows)
                {
                    //Verificar dados dentro DataReader
                    while (dr.Read())
                    {
                        UsuarioEnt dado = new UsuarioEnt();

                        //Receber dados campo
                        dado.Id = Convert.ToInt32(dr["id_usuario"]);
                        dado.Nome = Convert.ToString(dr["nome"]);
                        dado.Usuario = Convert.ToString(dr["usuario"]);
                        dado.Senha = Convert.ToString(dr["senha"]);

                        //Add lista na grid
                        lista.Add(dado);
                    }
                }
                return lista;
            }
        }
    }
}//Aula 44, 02min
