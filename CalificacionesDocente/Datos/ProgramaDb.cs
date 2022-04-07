using Dapper;
using Microsoft.Extensions.Configuration;
using Modelo.Interfaces;
using Modelo.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos
{
    public class ProgramaDb : IDataReader<Programa, int>
    {
        private string sqlConnectionString;

        public ProgramaDb(IConfigurationRoot configuration)
        {
            sqlConnectionString = configuration.GetConnectionString("DapperConnection");
        }

        public Programa Obtener(int id)
        {
            try
            {
                var p= new DynamicParameters();
                p.Add("@Id", id, dbType: DbType.Int32);
                using (var connection = new SqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    var model = connection.Query<Programa>("SELECT prog_id As Id, " +
                            "prog_codigo As Codigo, " +
                            "prog_nombre As Nombre " +
                            " FROM califica.programa " +
                            " WHERE prog_id = @id; ", p).FirstOrDefault();
                    connection.Close();
                    return model;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Programa> Obtener()
        {
            try
            {
                using (var connection = new SqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    var model = connection.Query<Programa>("SELECT prog_id As Id, " +
                            "prog_codigo As Codigo, " +
                            "prog_nombre As Nombre " +
                            " FROM califica.programa ").ToList();
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
