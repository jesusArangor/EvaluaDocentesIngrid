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
    public class CursoDb : IDataReader<Curso, int>
    {
        private string sqlConnectionString;

        public CursoDb(IConfiguration configuration)
        {
            sqlConnectionString = configuration.GetConnectionString("DapperConnection");
        }

        public Curso Obtener(int id)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@Id", id, dbType: DbType.Int32);

                using (var connection = new MySqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    var model = connection.Query<Curso>("SELECT cur_id as Id " +
                                  ", cur_codigo as Codigo " +
                                  ", cur_nombre as Nombre " +
                                  ", cur_semestre as Semestre " +
                            " FROM califica.curso " +
                            " WHERE cur_id = @id; ",p).FirstOrDefault();
                    connection.Close();
                    return model;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Curso> Obtener()
        {
            try
            {
                using (var connection = new MySqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    var model = connection.Query<Curso>("SELECT cur_id as Id " +
                                  ", cur_codigo as Codigo " +
                                  ", cur_nombre as Nombre " +
                                  ", cur_semestre as Semestre " +
                            " FROM califica.curso ").ToList();
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
