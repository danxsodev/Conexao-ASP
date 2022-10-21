using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DanillobdApp
{
    internal class UsuarioDAO
    {
        private banco db;

        public void Insert(Usuario usuario)
        {
            var strQuery = "";
            strQuery += "INSERT INTO tbl_Usuario(nm_usuario, cargo_usuario, dt_nasc)";
            strQuery += string.Format("VALUES('{0}', '{1}', str_to_date('{2}', '%d/%m/%Y %H:%i:%s'));", usuario.nm_usuario, usuario.cargo_usuario, usuario.dt_nasc);

            using (db = new banco())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public void Atualizar(Usuario usuario)
        {
            var strQuery = "";
            strQuery += "UPDATE tbl_Usuario SET ";
            strQuery += string.Format(" nm_usuario = '{0}', ", usuario.nm_usuario);
            strQuery += string.Format(" cargo_usuario = '{0}', ", usuario.cargo_usuario);
            strQuery += string.Format(" dt_nasc = str_to_date('{0}', '%d/%m/%Y %H:%i:%s') ", usuario.dt_nasc);
            strQuery += string.Format(" WHERE id_usuario = {0}; ", usuario.id_usuario);

            using (db = new banco())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Usuario usuario)
        {
            if(usuario.id_usuario > 0)
            {
                Atualizar(usuario);
            }
            else
            {
                Insert(usuario);
            }
        }

        public void Excluir(Usuario usuario)
        {
            using(db = new banco())
            {
                var strQuery = string.Format(" DELETE FROM tbl_Usuario WHERE id_usuario = {0}", usuario.id_usuario);
                db.ExecutaComando(strQuery);
            }
        }

        public MySqlDataReader Listar()
        {
            var db = new banco();
            var strQuery = "SELECT * FROM tbl_Usuario;";
            return db.RetornaComando(strQuery);
            
        }
        /*
        public List<Usuario> ListaDeUsuario(MySqlDataReader retorno)
        {
            var usuarios = new List<Usuario>();
            while (retorno.Read())
            {
                var TempUsuario = new Usuario()
                {
                    id_usuario = int.Parse(retorno["id_usuario"].ToString()),
                    nm_usuario = retorno["nm_usuario"].ToString(),
                    cargo_usuario = retorno["cargo_usuario"].ToString(),
                    dt_nasc = DateTime.Parse(retorno["dt_nasc"].ToString())

                };
                usuarios.Add(TempUsuario);
            }
            retorno.Close();
            return usuarios;

        }*/

    }
}
