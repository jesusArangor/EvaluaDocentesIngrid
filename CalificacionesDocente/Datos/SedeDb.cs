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
    public class SedeDb : IDataReader<Sede, int>
    {
        private string sqlConnectionString;

        public SedeDb(IConfiguration configuration)
        {
            sqlConnectionString = configuration.GetConnectionString("DapperConnection");
        }

        public Sede Obtener(int id)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@Id", id, dbType: DbType.Int32);

                using (var connection = new MySqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    var model = connection.Query<Sede>("SELECT sed_id as Id " +
                                  ", sed_codigo as Codigo " +
                                  ", sed_nombre as Nombre " +
                            " FROM sede " +
                            " WHERE sed_id = @id; ", p).FirstOrDefault();
                    connection.Close();
                    return model;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Sede> Obtener()
        {
            try
            {
                using (var connection = new MySqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    var model = connection.Query<Sede>("SELECT sed_id as Id " +
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
