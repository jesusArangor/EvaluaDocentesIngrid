using Dapper;
using Microsoft.Extensions.Configuration;
using Modelo.Interfaces;
using Modelo.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Datos
{
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

        public int AprobarCarga(int idCarga)
        {
            return 0;
        }

        public List<EvaluacionTemporal> CargaTemporales(Stream datos, string extension, ref int idCarga)
        {
            return null;
        }

        public IEnumerable<Evaluacion> Evaluaciones(int idDocente, int idCurso)
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
