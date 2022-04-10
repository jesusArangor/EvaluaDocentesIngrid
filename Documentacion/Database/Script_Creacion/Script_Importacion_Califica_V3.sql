-- MySQL dump 10.13  Distrib 5.5.62, for Win64 (AMD64)
--
-- Host: localhost    Database: califica
-- ------------------------------------------------------
-- Server version	5.5.5-10.4.11-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `calificacion`
--

DROP TABLE IF EXISTS `calificacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `calificacion` (
  `id_calificacion` int(11) NOT NULL AUTO_INCREMENT,
  `eva_id` int(11) NOT NULL,
  `for_id` int(11) NOT NULL,
  `cal_nota` decimal(18,2) NOT NULL DEFAULT 0.00,
  `cal_observacion` varchar(255) DEFAULT NULL,
  `cal_plan_mejora` bit(1) DEFAULT NULL,
  `cal_usu_ing` int(11) NOT NULL,
  `cal_usu_mod` int(11) NOT NULL,
  PRIMARY KEY (`id_calificacion`),
  KEY `fk_movimiento_calificacion_idx` (`eva_id`),
  KEY `fk_formato_valificacion_idx` (`for_id`),
  KEY `fk_calificacion_usu_ing_idx` (`cal_usu_ing`),
  KEY `fk_calificacion_usu_mod_idx` (`cal_usu_mod`),
  CONSTRAINT `fk_calificacion_usu_ing` FOREIGN KEY (`cal_usu_ing`) REFERENCES `usuario` (`usu_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_calificacion_usu_mod` FOREIGN KEY (`cal_usu_mod`) REFERENCES `usuario` (`usu_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_evaluacion_calificacion` FOREIGN KEY (`eva_id`) REFERENCES `evaluacion` (`eva_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_formato_valificacion` FOREIGN KEY (`for_id`) REFERENCES `formato` (`for_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `calificacion`
--

LOCK TABLES `calificacion` WRITE;
/*!40000 ALTER TABLE `calificacion` DISABLE KEYS */;
/*!40000 ALTER TABLE `calificacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `carga_docente`
--

DROP TABLE IF EXISTS `carga_docente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `carga_docente` (
  `card_fecha` datetime DEFAULT NULL,
  `card_usu_id` int(11) DEFAULT NULL,
  `card_completo` bit(1) DEFAULT NULL,
  `card_cantidad` int(11) DEFAULT NULL,
  `card_observacion` varchar(255) DEFAULT NULL,
  `card_errores` int(11) DEFAULT NULL,
  `card_id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`card_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `carga_docente`
--

LOCK TABLES `carga_docente` WRITE;
/*!40000 ALTER TABLE `carga_docente` DISABLE KEYS */;
/*!40000 ALTER TABLE `carga_docente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `carga_evaluacion`
--

DROP TABLE IF EXISTS `carga_evaluacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `carga_evaluacion` (
  `care_id` int(11) NOT NULL AUTO_INCREMENT,
  `care_fecha` datetime DEFAULT NULL,
  `care_usu_id` int(11) DEFAULT NULL,
  `care_completo` bit(1) DEFAULT NULL,
  `care_cantidad` int(11) DEFAULT NULL,
  `care_observacion` varchar(255) DEFAULT NULL,
  `care_errores` int(11) DEFAULT NULL,
  `care_semestre` int(11) DEFAULT NULL,
  `care_ano` int(11) DEFAULT NULL,
  `care_nomarchivo` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`care_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `carga_evaluacion`
--

LOCK TABLES `carga_evaluacion` WRITE;
/*!40000 ALTER TABLE `carga_evaluacion` DISABLE KEYS */;
/*!40000 ALTER TABLE `carga_evaluacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `curso`
--

DROP TABLE IF EXISTS `curso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `curso` (
  `cur_id` int(11) NOT NULL AUTO_INCREMENT,
  `cur_nombre` varchar(45) NOT NULL,
  `cur_codigo` varchar(45) DEFAULT NULL,
  `cur_semestre` int(11) DEFAULT NULL,
  PRIMARY KEY (`cur_id`),
  UNIQUE KEY `cur_codigo_UNIQUE` (`cur_codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `curso`
--

LOCK TABLES `curso` WRITE;
/*!40000 ALTER TABLE `curso` DISABLE KEYS */;
/*!40000 ALTER TABLE `curso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `docente`
--

DROP TABLE IF EXISTS `docente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `docente` (
  `doc_id` int(11) NOT NULL AUTO_INCREMENT,
  `doc_documento` varchar(20) NOT NULL,
  `doc_nombre` varchar(150) NOT NULL,
  `doc_correo` varchar(60) DEFAULT NULL,
  `doc_telefono` varchar(45) DEFAULT NULL,
  `doc_fecing` date DEFAULT NULL,
  `doc_fecmod` date DEFAULT NULL,
  `doc_usu_ing_id` int(11) DEFAULT NULL,
  `doc_usu_mod_id` int(11) DEFAULT NULL,
  `doc_idcarga` int(11) DEFAULT NULL,
  PRIMARY KEY (`doc_id`),
  KEY `fk_docente_usu_mod` (`doc_usu_mod_id`),
  KEY `fk_docente_usu_ing` (`doc_usu_ing_id`),
  KEY `fk_docente_card` (`doc_idcarga`),
  CONSTRAINT `fk_docente_card` FOREIGN KEY (`doc_idcarga`) REFERENCES `carga_docente` (`card_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_docente_usu_ing` FOREIGN KEY (`doc_usu_ing_id`) REFERENCES `usuario` (`usu_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_docente_usu_mod` FOREIGN KEY (`doc_usu_mod_id`) REFERENCES `usuario` (`usu_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `docente`
--

LOCK TABLES `docente` WRITE;
/*!40000 ALTER TABLE `docente` DISABLE KEYS */;
/*!40000 ALTER TABLE `docente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `evaluacion`
--

DROP TABLE IF EXISTS `evaluacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `evaluacion` (
  `eva_id` int(11) NOT NULL AUTO_INCREMENT,
  `cur_id` int(11) NOT NULL,
  `sed_id` int(11) NOT NULL,
  `fac_id` int(11) NOT NULL,
  `prog_id` int(11) NOT NULL,
  `eva_doc_id` int(11) DEFAULT NULL,
  `eva_care_id` int(11) DEFAULT NULL,
  `eva_modulo` varchar(45) DEFAULT NULL,
  `eva_curriculo` varchar(45) DEFAULT NULL,
  `eva_plan_aula` varchar(60) DEFAULT NULL,
  `eva_fecing` date DEFAULT NULL,
  `eva_fecmod` date DEFAULT NULL,
  `eva_usu_mod_id` int(11) NOT NULL,
  `eva_usu_ing_id` int(11) NOT NULL,
  `eva_estado` int(11) DEFAULT NULL,
  PRIMARY KEY (`eva_id`),
  KEY `fk_curso_movimiento_idx` (`cur_id`),
  KEY `fk_facultad_movimiento_idx` (`fac_id`),
  KEY `fk_sede_movimiento_idx` (`sed_id`),
  KEY `fk_programa_movimiento_idx` (`prog_id`),
  KEY `fk_docente_evaluacion_idx` (`eva_doc_id`),
  KEY `fk_care_evaluacion_idx` (`eva_care_id`),
  KEY `fk_evalucion_usu_ing_idx` (`eva_usu_mod_id`),
  KEY `fk_evalucion_usu_mod` (`eva_usu_ing_id`),
  CONSTRAINT `fk_care_evaluacion` FOREIGN KEY (`eva_care_id`) REFERENCES `carga_evaluacion` (`care_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_curso_evaluacion` FOREIGN KEY (`cur_id`) REFERENCES `curso` (`cur_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_docente_evaluacion` FOREIGN KEY (`eva_doc_id`) REFERENCES `docente` (`doc_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_evalucion_usu_ing` FOREIGN KEY (`eva_usu_mod_id`) REFERENCES `usuario` (`usu_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_evalucion_usu_mod` FOREIGN KEY (`eva_usu_ing_id`) REFERENCES `usuario` (`usu_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_facultad_evaluacion` FOREIGN KEY (`fac_id`) REFERENCES `facultad` (`fac_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_programa_evaluacion` FOREIGN KEY (`prog_id`) REFERENCES `programa` (`prog_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_sede_evaluacion` FOREIGN KEY (`sed_id`) REFERENCES `sede` (`sed_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `evaluacion`
--

LOCK TABLES `evaluacion` WRITE;
/*!40000 ALTER TABLE `evaluacion` DISABLE KEYS */;
/*!40000 ALTER TABLE `evaluacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `facultad`
--

DROP TABLE IF EXISTS `facultad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `facultad` (
  `fac_codigo` varchar(30) NOT NULL,
  `fac_nombre` varchar(60) DEFAULT NULL,
  `fac_id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`fac_id`),
  UNIQUE KEY `fac_codigo_UNIQUE` (`fac_codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `facultad`
--

LOCK TABLES `facultad` WRITE;
/*!40000 ALTER TABLE `facultad` DISABLE KEYS */;
/*!40000 ALTER TABLE `facultad` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `formato`
--

DROP TABLE IF EXISTS `formato`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `formato` (
  `for_id` int(11) NOT NULL AUTO_INCREMENT,
  `for_fase` varchar(45) NOT NULL,
  `for_calif_fase` decimal(18,2) NOT NULL,
  `for_item` int(11) NOT NULL,
  `for_descripcion` varchar(255) NOT NULL,
  `for_puntaje_max` decimal(18,2) NOT NULL,
  PRIMARY KEY (`for_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `formato`
--

LOCK TABLES `formato` WRITE;
/*!40000 ALTER TABLE `formato` DISABLE KEYS */;
/*!40000 ALTER TABLE `formato` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `programa`
--

DROP TABLE IF EXISTS `programa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `programa` (
  `prog_codigo` varchar(25) NOT NULL,
  `prog_nombre` varchar(45) NOT NULL,
  `prog_id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`prog_id`),
  UNIQUE KEY `prog_codigo_UNIQUE` (`prog_codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `programa`
--

LOCK TABLES `programa` WRITE;
/*!40000 ALTER TABLE `programa` DISABLE KEYS */;
/*!40000 ALTER TABLE `programa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sede`
--

DROP TABLE IF EXISTS `sede`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sede` (
  `sed_codigo` varchar(25) NOT NULL,
  `sed_nombre` varchar(45) NOT NULL,
  `sed_id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`sed_id`),
  UNIQUE KEY `sed_codigo_UNIQUE` (`sed_codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sede`
--

LOCK TABLES `sede` WRITE;
/*!40000 ALTER TABLE `sede` DISABLE KEYS */;
/*!40000 ALTER TABLE `sede` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `temporal_docente`
--

DROP TABLE IF EXISTS `temporal_docente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `temporal_docente` (
  `doc_documento` varchar(255) DEFAULT NULL,
  `doc_nombre` varchar(255) DEFAULT NULL,
  `doc_correo` varchar(255) DEFAULT NULL,
  `doc_telefono` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `temporal_docente`
--

LOCK TABLES `temporal_docente` WRITE;
/*!40000 ALTER TABLE `temporal_docente` DISABLE KEYS */;
/*!40000 ALTER TABLE `temporal_docente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `temporal_evaluacion`
--

DROP TABLE IF EXISTS `temporal_evaluacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `temporal_evaluacion` (
  `curso_n` varchar(255) DEFAULT NULL,
  `semestre` varchar(255) DEFAULT NULL,
  `sede` varchar(255) DEFAULT NULL,
  `fecini_bloque` varchar(255) DEFAULT NULL,
  `fecfin_bloque` varchar(255) DEFAULT NULL,
  `fac_codigo` varchar(255) DEFAULT NULL,
  `facultad` varchar(255) DEFAULT NULL,
  `programa` varchar(255) DEFAULT NULL,
  `curso` varchar(255) DEFAULT NULL,
  `cedula` varchar(255) DEFAULT NULL,
  `docente` varchar(255) DEFAULT NULL,
  `modulo` varchar(255) DEFAULT NULL,
  `curriculo` varchar(255) DEFAULT NULL,
  `plan_aula` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `temporal_evaluacion`
--

LOCK TABLES `temporal_evaluacion` WRITE;
/*!40000 ALTER TABLE `temporal_evaluacion` DISABLE KEYS */;
/*!40000 ALTER TABLE `temporal_evaluacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuario` (
  `usu_id` int(11) NOT NULL AUTO_INCREMENT,
  `usu_correo` varchar(255) NOT NULL,
  `usu_nombre` varchar(150) DEFAULT NULL,
  `usu_pass` varbinary(255) DEFAULT NULL,
  `usu_salt` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`usu_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary table structure for view `v_calificacion`
--

DROP TABLE IF EXISTS `v_calificacion`;
/*!50001 DROP VIEW IF EXISTS `v_calificacion`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `v_calificacion` (
  `id_calificacion` tinyint NOT NULL,
  `nota_calificada` tinyint NOT NULL,
  `observacion_calificacion` tinyint NOT NULL,
  `plan_mejora` tinyint NOT NULL,
  `id_usuario_ingresa` tinyint NOT NULL,
  `id_usuario_modifica` tinyint NOT NULL,
  `id_Formulario` tinyint NOT NULL,
  `Fase_formato` tinyint NOT NULL,
  `Fase_califica_formato` tinyint NOT NULL,
  `item_formato` tinyint NOT NULL,
  `descripcion_formato` tinyint NOT NULL,
  `puntaje_max_formato` tinyint NOT NULL,
  `id_Evalucion` tinyint NOT NULL,
  `cur_id` tinyint NOT NULL,
  `Nombre_Curso` tinyint NOT NULL,
  `sed_id` tinyint NOT NULL,
  `Nombre_Sede` tinyint NOT NULL,
  `fac_id` tinyint NOT NULL,
  `Nombre_Facultad` tinyint NOT NULL,
  `prog_id` tinyint NOT NULL,
  `Nombre_Programa` tinyint NOT NULL,
  `eva_doc_id` tinyint NOT NULL,
  `Nombre_Docente` tinyint NOT NULL,
  `Docu_Docente` tinyint NOT NULL,
  `Correo_Docente` tinyint NOT NULL,
  `Tel_Docente` tinyint NOT NULL,
  `eva_care_id` tinyint NOT NULL,
  `eva_modulo` tinyint NOT NULL,
  `eva_curriculo` tinyint NOT NULL,
  `eva_plan_aula` tinyint NOT NULL,
  `eva_fecing` tinyint NOT NULL,
  `eva_fecmod` tinyint NOT NULL,
  `eva_usu_mod_id` tinyint NOT NULL,
  `Nombre_usu_modifica` tinyint NOT NULL,
  `eva_usu_ing_id` tinyint NOT NULL,
  `Nombre_Usu_Ingresa` tinyint NOT NULL,
  `eva_estado` tinyint NOT NULL,
  `Nombre_Archivo_Carga` tinyint NOT NULL,
  `Semestre_carga` tinyint NOT NULL,
  `Anio_carga` tinyint NOT NULL,
  `Observaciones_Carga` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `v_docente`
--

DROP TABLE IF EXISTS `v_docente`;
/*!50001 DROP VIEW IF EXISTS `v_docente`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `v_docente` (
  `doc_id` tinyint NOT NULL,
  `doc_documento` tinyint NOT NULL,
  `doc_nombre` tinyint NOT NULL,
  `doc_correo` tinyint NOT NULL,
  `doc_telefono` tinyint NOT NULL,
  `doc_fecing` tinyint NOT NULL,
  `doc_fecmod` tinyint NOT NULL,
  `doc_usu_ing_id` tinyint NOT NULL,
  `Nombre_usu_ingresa` tinyint NOT NULL,
  `doc_usu_mod_id` tinyint NOT NULL,
  `Nombre_us_modifica` tinyint NOT NULL,
  `doc_idcarga` tinyint NOT NULL,
  `Fecha_carga` tinyint NOT NULL,
  `Usuario_carga` tinyint NOT NULL,
  `completo_carga` tinyint NOT NULL,
  `Observacion_carga` tinyint NOT NULL,
  `Errores_carga` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `v_evalucion`
--

DROP TABLE IF EXISTS `v_evalucion`;
/*!50001 DROP VIEW IF EXISTS `v_evalucion`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `v_evalucion` (
  `id_evalucion` tinyint NOT NULL,
  `cur_id` tinyint NOT NULL,
  `Nombre_Curso` tinyint NOT NULL,
  `sed_id` tinyint NOT NULL,
  `Nombre_Sede` tinyint NOT NULL,
  `fac_id` tinyint NOT NULL,
  `Nombre_Facultad` tinyint NOT NULL,
  `prog_id` tinyint NOT NULL,
  `Nombre_Programa` tinyint NOT NULL,
  `eva_doc_id` tinyint NOT NULL,
  `Nombre_Docente` tinyint NOT NULL,
  `Docu_Docente` tinyint NOT NULL,
  `Correo_Docente` tinyint NOT NULL,
  `Tel_Docente` tinyint NOT NULL,
  `eva_care_id` tinyint NOT NULL,
  `eva_modulo` tinyint NOT NULL,
  `eva_curriculo` tinyint NOT NULL,
  `eva_plan_aula` tinyint NOT NULL,
  `eva_fecing` tinyint NOT NULL,
  `eva_fecmod` tinyint NOT NULL,
  `eva_usu_mod_id` tinyint NOT NULL,
  `Nombre_usu_modifica` tinyint NOT NULL,
  `eva_usu_ing_id` tinyint NOT NULL,
  `Nombre_Usu_Ingresa` tinyint NOT NULL,
  `eva_estado` tinyint NOT NULL,
  `Nombre_Archivo_Carga` tinyint NOT NULL,
  `Semestre_carga` tinyint NOT NULL,
  `Anio_carga` tinyint NOT NULL,
  `Observaciones_Carga` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

--
-- Dumping routines for database 'califica'
--

--
-- Final view structure for view `v_calificacion`
--

/*!50001 DROP TABLE IF EXISTS `v_calificacion`*/;
/*!50001 DROP VIEW IF EXISTS `v_calificacion`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `v_calificacion` AS (select `c`.`id_calificacion` AS `id_calificacion`,`c`.`cal_nota` AS `nota_calificada`,`c`.`cal_observacion` AS `observacion_calificacion`,`c`.`cal_plan_mejora` AS `plan_mejora`,`c`.`cal_usu_ing` AS `id_usuario_ingresa`,`c`.`cal_usu_mod` AS `id_usuario_modifica`,`c`.`for_id` AS `id_Formulario`,`f`.`for_fase` AS `Fase_formato`,`f`.`for_calif_fase` AS `Fase_califica_formato`,`f`.`for_item` AS `item_formato`,`f`.`for_descripcion` AS `descripcion_formato`,`f`.`for_puntaje_max` AS `puntaje_max_formato`,`c`.`eva_id` AS `id_Evalucion`,`e`.`cur_id` AS `cur_id`,`cu`.`cur_nombre` AS `Nombre_Curso`,`e`.`sed_id` AS `sed_id`,`s`.`sed_nombre` AS `Nombre_Sede`,`e`.`fac_id` AS `fac_id`,`fa`.`fac_nombre` AS `Nombre_Facultad`,`e`.`prog_id` AS `prog_id`,`p`.`prog_nombre` AS `Nombre_Programa`,`e`.`eva_doc_id` AS `eva_doc_id`,`d`.`doc_nombre` AS `Nombre_Docente`,`d`.`doc_documento` AS `Docu_Docente`,`d`.`doc_correo` AS `Correo_Docente`,`d`.`doc_telefono` AS `Tel_Docente`,`e`.`eva_care_id` AS `eva_care_id`,`e`.`eva_modulo` AS `eva_modulo`,`e`.`eva_curriculo` AS `eva_curriculo`,`e`.`eva_plan_aula` AS `eva_plan_aula`,`e`.`eva_fecing` AS `eva_fecing`,`e`.`eva_fecmod` AS `eva_fecmod`,`e`.`eva_usu_mod_id` AS `eva_usu_mod_id`,`u`.`usu_nombre` AS `Nombre_usu_modifica`,`e`.`eva_usu_ing_id` AS `eva_usu_ing_id`,`u2`.`usu_nombre` AS `Nombre_Usu_Ingresa`,`e`.`eva_estado` AS `eva_estado`,`ce`.`care_nomarchivo` AS `Nombre_Archivo_Carga`,`ce`.`care_semestre` AS `Semestre_carga`,`ce`.`care_ano` AS `Anio_carga`,`ce`.`care_observacion` AS `Observaciones_Carga` from ((((((((((`calificacion` `c` join `formato` `f` on(`f`.`for_id` = `c`.`for_id`)) join `evaluacion` `e` on(`e`.`eva_id` = `c`.`eva_id`)) join `curso` `cu` on(`cu`.`cur_id` = `e`.`cur_id`)) join `sede` `s` on(`s`.`sed_id` = `e`.`sed_id`)) join `facultad` `fa` on(`fa`.`fac_id` = `e`.`fac_id`)) join `programa` `p` on(`p`.`prog_id` = `e`.`prog_id`)) join `docente` `d` on(`d`.`doc_id` = `e`.`eva_doc_id`)) join `usuario` `u` on(`u`.`usu_id` = `e`.`eva_usu_mod_id`)) join `usuario` `u2` on(`u2`.`usu_id` = `e`.`eva_usu_ing_id`)) join `carga_evaluacion` `ce` on(`ce`.`care_id` = `e`.`eva_care_id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `v_docente`
--

/*!50001 DROP TABLE IF EXISTS `v_docente`*/;
/*!50001 DROP VIEW IF EXISTS `v_docente`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `v_docente` AS (select `d`.`doc_id` AS `doc_id`,`d`.`doc_documento` AS `doc_documento`,`d`.`doc_nombre` AS `doc_nombre`,`d`.`doc_correo` AS `doc_correo`,`d`.`doc_telefono` AS `doc_telefono`,`d`.`doc_fecing` AS `doc_fecing`,`d`.`doc_fecmod` AS `doc_fecmod`,`d`.`doc_usu_ing_id` AS `doc_usu_ing_id`,`u`.`usu_nombre` AS `Nombre_usu_ingresa`,`d`.`doc_usu_mod_id` AS `doc_usu_mod_id`,`u2`.`usu_nombre` AS `Nombre_us_modifica`,`d`.`doc_idcarga` AS `doc_idcarga`,`cd`.`card_fecha` AS `Fecha_carga`,`cd`.`card_usu_id` AS `Usuario_carga`,`cd`.`card_completo` AS `completo_carga`,`cd`.`card_observacion` AS `Observacion_carga`,`cd`.`card_errores` AS `Errores_carga` from (((`docente` `d` join `carga_docente` `cd` on(`cd`.`card_id` = `d`.`doc_idcarga`)) join `usuario` `u` on(`u`.`usu_id` = `d`.`doc_usu_ing_id`)) join `usuario` `u2` on(`u2`.`usu_id` = `d`.`doc_usu_mod_id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `v_evalucion`
--

/*!50001 DROP TABLE IF EXISTS `v_evalucion`*/;
/*!50001 DROP VIEW IF EXISTS `v_evalucion`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `v_evalucion` AS (select `e`.`eva_id` AS `id_evalucion`,`e`.`cur_id` AS `cur_id`,`c`.`cur_nombre` AS `Nombre_Curso`,`e`.`sed_id` AS `sed_id`,`s`.`sed_nombre` AS `Nombre_Sede`,`e`.`fac_id` AS `fac_id`,`f`.`fac_nombre` AS `Nombre_Facultad`,`e`.`prog_id` AS `prog_id`,`p`.`prog_nombre` AS `Nombre_Programa`,`e`.`eva_doc_id` AS `eva_doc_id`,`d`.`doc_nombre` AS `Nombre_Docente`,`d`.`doc_documento` AS `Docu_Docente`,`d`.`doc_correo` AS `Correo_Docente`,`d`.`doc_telefono` AS `Tel_Docente`,`e`.`eva_care_id` AS `eva_care_id`,`e`.`eva_modulo` AS `eva_modulo`,`e`.`eva_curriculo` AS `eva_curriculo`,`e`.`eva_plan_aula` AS `eva_plan_aula`,`e`.`eva_fecing` AS `eva_fecing`,`e`.`eva_fecmod` AS `eva_fecmod`,`e`.`eva_usu_mod_id` AS `eva_usu_mod_id`,`u`.`usu_nombre` AS `Nombre_usu_modifica`,`e`.`eva_usu_ing_id` AS `eva_usu_ing_id`,`u2`.`usu_nombre` AS `Nombre_Usu_Ingresa`,`e`.`eva_estado` AS `eva_estado`,`ce`.`care_nomarchivo` AS `Nombre_Archivo_Carga`,`ce`.`care_semestre` AS `Semestre_carga`,`ce`.`care_ano` AS `Anio_carga`,`ce`.`care_observacion` AS `Observaciones_Carga` from ((((((((`evaluacion` `e` join `curso` `c` on(`c`.`cur_id` = `e`.`cur_id`)) join `sede` `s` on(`s`.`sed_id` = `e`.`sed_id`)) join `facultad` `f` on(`f`.`fac_id` = `e`.`fac_id`)) join `programa` `p` on(`p`.`prog_id` = `e`.`prog_id`)) join `docente` `d` on(`d`.`doc_id` = `e`.`eva_doc_id`)) join `usuario` `u` on(`u`.`usu_id` = `e`.`eva_usu_mod_id`)) join `usuario` `u2` on(`u2`.`usu_id` = `e`.`eva_usu_ing_id`)) join `carga_evaluacion` `ce` on(`ce`.`care_id` = `e`.`eva_care_id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-04-10 13:51:14
