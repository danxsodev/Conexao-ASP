using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanillobdApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var banco = new banco();
            var usuarioDAO = new UsuarioDAO();
            var usuario = new Usuario();

            Console.WriteLine("Digite o nome do usuário: ");
            string vNome = Console.ReadLine();

            Console.WriteLine("Digite o  cargo do usuário: ");
            string vCargo = Console.ReadLine();

            Console.WriteLine("Digite a data de nascimento do usuário: ");
            string vData =  Console.ReadLine();

            usuario.nm_usuario = vNome;
            usuario.cargo_usuario = vCargo;
            usuario.dt_nasc = DateTime.Parse(vData);

            usuario.id_usuario = 2;

            
            usuarioDAO.Insert(usuario);
            //usuarioDAO.Atualizar(usuario);//
            //usuarioDAO.Excluir(usuario);//

            MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
            conexao.Open();

            MySqlDataReader leitor = usuarioDAO.Listar();

             while (leitor.Read())
	         {
                Console.WriteLine("Id: {0}, Nome: {1}, Cargo: {2}, Data: {3}",
                    leitor["id_usuario"], leitor["nm_usuario"], leitor["cargo_usuario"], leitor["dt_nasc"]);
	         }
              Console.ReadLine();
        }
    }
}
