using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
       // private readonly ILogger<UsuarioDb> logger;

        public UsuarioDb(IConfiguration configuration
            //, ILogger<UsuarioDb> logger
            )
        {
            sqlConnectionString = configuration.GetConnectionString("DapperConnection");
            //this.logger = logger;
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
              //  logger.LogError( "Error al procesar los datos ", null);
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

    public class EvaluancionDb : IEvaluacionData
    {
        private string sqlConnectionString;
       // private ILogger<EvaluancionDb> logger;

        public EvaluancionDb(IConfiguration configuration
            //, ILogger<EvaluancionDb> logger
            )
        {
            sqlConnectionString = configuration.GetConnectionString("DapperConnection");
           // this.logger = logger;
        }

        public IEnumerable<Evaluacion> evaluaciones(int idDocente, int idCurso)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@idCurso", idCurso, dbType: DbType.Int32);
                p.Add("@idDoc", idDocente, dbType: DbType.Int32);

                using (var connection = new MySqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    var model = connection.Query<Evaluacion>("SELECT usu_id as Id " +
                                  ", usu_correo as Correo " +
                                  ", usu_nombre as Nombre " +
                                  //", usu_pass as Password " +
                                  ", usu_salt as Salt " +
                            " FROM V_evaluacion " +
                            " WHERE usu_id = @idCurso; " +
                            " AND  va2 = @idDoc", p).ToList();
                    connection.Close();
                    return model;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Evaluacion Obtener(int id)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@id", id, dbType: DbType.Int32);

                using (var connection = new MySqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    var model = connection.Query<Evaluacion>("SELECT usu_id as Id " +
                                  ", usu_correo as Correo " +
                                  ", usu_nombre as Nombre " +
                                  //", usu_pass as Password " +
                                  ", usu_salt as Salt " +
                            " FROM V_evaluacion " +
                            " WHERE usu_id = @idCurso; ", p).FirstOrDefault();
                    connection.Close();
                    return model;
                    }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Evaluacion> Obtener()
        {
            throw new NotImplementedException();
        }
    }
}
