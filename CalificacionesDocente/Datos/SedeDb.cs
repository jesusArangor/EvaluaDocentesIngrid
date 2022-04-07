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
    public class SedeDb : IDataReader<Sede, int>
    {
        private string sqlConnectionString;

        public SedeDb(IConfigurationRoot configuration)
        {
            sqlConnectionString = configuration.GetConnectionString("DapperConnection");
        }

        public Sede Obtener(int id)
        {
            try
            {
                
                var p = new DynamicParameters();
                p.Add("@Id", id, dbType: DbType.Int32);
                using (var connection = new SqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    var model = connection.Query<Sede>("SELECT sed_id As Id, " +
                            "sed_codigo As Codigo, " +
                            "sed_nombre As Nombre " +
                            "From sede" +
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

        public IEnumerable<Sede> Obtener()
        {
            
        }
    }//fin clase
}
