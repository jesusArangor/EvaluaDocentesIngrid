using Dapper;
using Microsoft.Extensions.Configuration;
using Modelo.Interfaces;
using Modelo.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Datos
{
    public class FormatoDb : IDataReader<Formato, int>
    {
        private string sqlConnectionString;

        public FormatoDb(IConfiguration configuration)
        {
            sqlConnectionString = configuration.GetConnectionString("DapperConnection");
        }

        public Formato Obtener(int id)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@Id", id, dbType: DbType.Int32);

                using (var connection = new MySqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    var model = connection.Query<Formato>("SELECT for_id as Id " +   
                                  ", for_item as Item " +
                                  ", for_fase as Fase " +
                                  ", for_calif_fase as CalificacionBase " +
                                  ", for_puntaje_max as PuntajeMax " +
                                  ", for_descripcion as Descripcion " +
                            " FROM califica.formato " +
                            " WHERE cur_id = @id; ", p).FirstOrDefault();
                    connection.Close();
                    return model;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Formato> Obtener()
        {
            try
            {
                using (var connection = new MySqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    var model = connection.Query<Formato>("SELECT for_id as Id " +   
                                  ", for_item as Item " +
                                  ", for_fase as Fase " +
                                  ", for_calif_fase as CalificacionBase " +
                                  ", for_puntaje_max as PuntajeMax " +
                                  ", for_descripcion as Descripcion " +
                            " FROM califica.formato ").ToList();
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
