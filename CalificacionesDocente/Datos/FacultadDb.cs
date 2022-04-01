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
    public class FacultadDb : IDataReader<Facultad, int>
    {
        private string sqlConnectionString;

        public FacultadDb(IConfigurationRoot configuration)
        {
            sqlConnectionString = configuration.GetConnectionString("DapperConnection");
        }        

        public Facultad Obtener(int id)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@Id", id, dbType: DbType.Int32);

                using (var connection = new SqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    var model = connection.Query<Facultad>("SELECT fac_id As Id, " +
                            "fac_codigo As Codigo, " +
                            "fac_nombre As Nombre " +
                            " FROM califica.facultad " +
                            " WHERE fac_id = @id; ", p).FirstOrDefault();
                    connection.Close();
                    return model;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Facultad> Obtener()
        {
            try
            {
                using (var connection = new SqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    var model = connection.Query<Facultad>("SELECT fac_id As Id, " +
                            "fac_codigo As Codigo," +
                            "fac_nombre As Nombre " +
                            " FROM califica.facultad ").ToList();
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
