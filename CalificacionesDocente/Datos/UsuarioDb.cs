using Dapper;
using Microsoft.Extensions.Configuration;
using Modelo.Interfaces;
using Modelo.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Datos
{
    public class UsuarioDb : IUsuarioData
    {
        private string sqlConnectionString;

        public UsuarioDb(IConfiguration configuration)
        {
            sqlConnectionString = configuration.GetConnectionString("DapperConnection");
        }

        public Usuario Autenticar(string correo, string password)
        {
            // TODO cambiar por procedimiento que valida usuario
            return ObtenerxLogin(correo);
        }

        public Usuario ObtenerxLogin(string correo)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@correo", correo, dbType: DbType.String);

                using (var connection = new MySqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    var model = connection.Query<Usuario>("SELECT usu_id as Id " +
                                  ", usu_correo as Correo " +
                                  ", usu_nombre as Nombre " +
                                  //", usu_pass as Password " +
                                  ", usu_salt as Salt " +
                            " FROM usuario " +
                            " WHERE usu_correo = @correo; ", p).FirstOrDefault();
                    connection.Close();
                    return model;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Usuario Obtener(int id)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@Id", id, dbType: DbType.Int32);

                using (var connection = new MySqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    var model = connection.Query<Usuario>("SELECT usu_id as Id " +
                                  ", usu_correo as Correo " +
                                  ", usu_nombre as Nombre " +
                                  //", usu_pass as Password " +
                                  ", usu_salt as Salt " +
                            " FROM usuario " +
                            " WHERE usu_id = @id; ", p).FirstOrDefault();
                    connection.Close();
                    return model;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Usuario> Obtener()
        {
            try
            {
                using (var connection = new MySqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    var model = connection.Query<Usuario>("SELECT sed_id as Id " +
                                  ", sed_codigo as Codigo " +
                                  ", sed_nombre as Nombre " +
                            " FROM sede ").ToList();
                    connection.Close();
                    return model;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
