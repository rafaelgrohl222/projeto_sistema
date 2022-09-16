using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Sistema.Entidades;
using Projeto_Sistema.DAO;

namespace Projeto_Sistema.Model
{
    public class UsuarioModel
    {
        public static int Inserir(UsuarioEnt objTabela)
        {
            return new UsuarioDAO().Inserir(objTabela);
        }

        public List<UsuarioEnt> Lista()
        {
            return new UsuarioDAO().lista();
        }

        public UsuarioEnt Login(UsuarioEnt obj)
        {
            return new UsuarioDAO().Login(obj);
        }

        public static int Excluir(UsuarioEnt objTabela)
        {
            return new UsuarioDAO().Excluir(objTabela);
        }

        public static int Editar(UsuarioEnt objTabela)
        {
            return new UsuarioDAO().Editar(objTabela);
        }

        public List<UsuarioEnt> Buscar(UsuarioEnt objTabela)
        {
            return new UsuarioDAO().Buscar(objTabela);
        }
    }
}
