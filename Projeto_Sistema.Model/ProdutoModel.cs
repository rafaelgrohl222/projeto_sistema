using Projeto_Sistem.Entidades;
using Projeto_Sistema.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Sistema.Model
{
    public class ProdutoModel
    {
        public List<ProdutoEnt> Lista()
        {
            return new ProdutoDAO().lista();
        }

        public static int Inserir(ProdutoEnt objTabela)
        {
            return new ProdutoDAO().Inserir(objTabela);
        }

        public static int Excluir(ProdutoEnt objTabela)
        {
            return new ProdutoDAO().Excluir(objTabela);
        }

        public static int Editar(ProdutoEnt objTabela)
        {
            return new ProdutoDAO().Editar(objTabela);
        }

        public List<ProdutoEnt> Buscar(ProdutoEnt objTabela)
        {
            return new ProdutoDAO().Buscar(objTabela);
        }
    }
}
