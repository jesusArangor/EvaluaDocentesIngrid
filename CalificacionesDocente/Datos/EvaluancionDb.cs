using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private ILogger<EvaluancionDb> logger;

        public EvaluancionDb(IConfiguration configuration, ILogger<EvaluancionDb> logger
            )
        {
            sqlConnectionString = configuration.GetConnectionString("DapperConnection");
            this.logger = logger;
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
                    var model = connection.Query<Evaluacion>("SELECT id_evalucion AS Id " +
                                  ",cur_id AS CursoId" +
                                  ",Nombre_Curso AS NombreCurso" +
                                  ",sed_id AS Sedeid" +
                                  ",Nombre_Sede AS NombreSede" +
                                  ",fac_id AS FacultadId" +
                                  ",Nombre_Facultad AS NombreFacultad" +
                                  ",prog_id AS ProgramaId" +
                                  ",Nombre_Programa AS NombrePrograma" +
                                  ",eva_doc_id AS DocenteId" +
                                  ",Nombre_Docente AS NombreDocente" +
                                  ",Docu_Docente AS DocumentoDocente" +
                                  ",Correo_Docente AS CorreoDocente" +
                                  ",Tel_Docente AS TelefonoDocente" +
                                  ",eva_care_id AS CargaEvaluacionId" +
                                  ",eva_modulo AS Modulo" +
                                  ",eva_curriculo AS Curriculo" +
                                  ",eva_plan_aula AS PlanAula" +
                                  ",eva_fecing AS FechaCrea" +
                                  ",eva_fecmod AS FechaMod" +
                                  ",eva_usu_mod_id AS UsuarioMod" +
                                  ",Nombre_usu_modifica AS Nombreusumodifica" +
                                  ",eva_usu_ing_id AS UsuarioCrea" +
                                  ",Nombre_Usu_Ingresa AS NombreUsuIngresa" +
                                  ",eva_estado AS Estado" +
                                  ",Nombre_Archivo_Carga AS NombreArchivoCarga" +
                                  ",Semestre_carga AS SemestreCarga" +
                                  ",Anio_carga AS AnioCarga" +
                            " FROM V_evaluacion " +
                            " WHERE cur_id = @idCurso; " +
                            " AND eva_doc_id = @idDoc", p).ToList();
                    connection.Close();
                    return model;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al acceder a la base de datos.");
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
                    var model = connection.Query<Evaluacion>("SELECT id_evalucion AS Id " +
                                  ",cur_id AS CursoId" +
                                  ",Nombre_Curso AS NombreCurso" +
                                  ",sed_id AS Sedeid" +
                                  ",Nombre_Sede AS NombreSede" +
                                  ",fac_id AS FacultadId" +
                                  ",Nombre_Facultad AS NombreFacultad" +
                                  ",prog_id AS ProgramaId" +
                                  ",Nombre_Programa AS NombrePrograma" +
                                  ",eva_doc_id AS DocenteId" +
                                  ",Nombre_Docente AS NombreDocente" +
                                  ",Docu_Docente AS DocumentoDocente" +
                                  ",Correo_Docente AS CorreoDocente" +
                                  ",Tel_Docente AS TelefonoDocente" +
                                  ",eva_care_id AS CargaEvaluacionId" +
                                  ",eva_modulo AS Modulo" +
                                  ",eva_curriculo AS Curriculo" +
                                  ",eva_plan_aula AS PlanAula" +
                                  ",eva_fecing AS FechaCrea" +
                                  ",eva_fecmod AS FechaMod" +
                                  ",eva_usu_mod_id AS UsuarioMod" +
                                  ",Nombre_usu_modifica AS Nombreusumodifica" +
                                  ",eva_usu_ing_id AS UsuarioCrea" +
                                  ",Nombre_Usu_Ingresa AS NombreUsuIngresa" +
                                  ",eva_estado AS Estado" +
                                  ",Nombre_Archivo_Carga AS NombreArchivoCarga" +
                                  ",Semestre_carga AS SemestreCarga" +
                                  ",Anio_carga AS AnioCarga" +
                            " FROM V_evaluacion " +
                            " WHERE id_evalucion = @id; ", p).FirstOrDefault();
                    connection.Close();
                    return model;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al acceder a la base de datos.");
                return null;
            }
        }

        public IEnumerable<Evaluacion> Obtener()
        {
            try
            {          
                using (var connection = new MySqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    var model = connection.Query<Evaluacion>("SELECT id_evalucion AS Id " +
                                  ",cur_id AS CursoId" +
                                  ",Nombre_Curso AS NombreCurso" +
                                  ",sed_id AS Sedeid" +
                                  ",Nombre_Sede AS NombreSede" +
                                  ",fac_id AS FacultadId" +
                                  ",Nombre_Facultad AS NombreFacultad" +
                                  ",prog_id AS ProgramaId" +
                                  ",Nombre_Programa AS NombrePrograma" +
                                  ",eva_doc_id AS DocenteId" +
                                  ",Nombre_Docente AS NombreDocente" +
                                  ",Docu_Docente AS DocumentoDocente" +
                                  ",Correo_Docente AS CorreoDocente" +
                                  ",Tel_Docente AS TelefonoDocente" +
                                  ",eva_care_id AS CargaEvaluacionId" +
                                  ",eva_modulo AS Modulo" +
                                  ",eva_curriculo AS Curriculo" +
                                  ",eva_plan_aula AS PlanAula" +
                                  ",eva_fecing AS FechaCrea" +
                                  ",eva_fecmod AS FechaMod" +
                                  ",eva_usu_mod_id AS UsuarioMod" +
                                  ",Nombre_usu_modifica AS Nombreusumodifica" +
                                  ",eva_usu_ing_id AS UsuarioCrea" +
                                  ",Nombre_Usu_Ingresa AS NombreUsuIngresa" +
                                  ",eva_estado AS Estado" +
                                  ",Nombre_Archivo_Carga AS NombreArchivoCarga" +
                                  ",Semestre_carga AS SemestreCarga" +
                                  ",Anio_carga AS AnioCarga" +
                            " FROM V_evaluacion ").ToList();
                    connection.Close();
                    return model;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al acceder a la base de datos.");
                return null;
            }
        }
    }
}