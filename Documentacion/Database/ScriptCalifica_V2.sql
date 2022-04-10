-- MySQL Script generated by MySQL Workbench
-- Thu Mar 24 20:58:51 2022
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

-- Schema mydb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `califica` DEFAULT CHARACTER SET utf8 ;
USE `califica` ;
-- -----------------------------------------------------
-- Table `usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `usuario` (
  `usu_id` INT NOT NULL AUTO_INCREMENT,
  `usu_correo` VARCHAR(255) NOT NULL,
  `usu_nombre` VARCHAR(150) NULL,
  `usu_pass` VARBINARY(255) NULL,
  `usu_salt` TINYINT NULL,
  PRIMARY KEY (`usu_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `carga_docente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `carga_docente` (
  `card_fecha` DATETIME NULL,
  `card_usu_id` INT NULL,
  `card_completo` BIT NULL,
  `card_cantidad` INT NULL,
  `card_observacion` VARCHAR(255) NULL,
  `card_errores` INT NULL,
  `card_id` INT NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`card_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `docente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `docente` (
  `doc_id` INT NOT NULL AUTO_INCREMENT,
  `doc_documento` VARCHAR(20) NOT NULL,
  `doc_nombre` VARCHAR(150) NOT NULL,
  `doc_correo` VARCHAR(60) NULL,
  `doc_telefono` VARCHAR(45) NULL,
  `doc_fecing` DATE NULL,
  `doc_fecmod` DATE NULL,
  `doc_usu_ing_id` INT NULL,
  `doc_usu_mod_id` INT NULL,
  `doc_idcarga` INT NULL,
  PRIMARY KEY (`doc_id`),
  CONSTRAINT `fk_docente_usu_mod`
    FOREIGN KEY (`doc_usu_mod_id`)
    REFERENCES `usuario` (`usu_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_docente_usu_ing`
    FOREIGN KEY (`doc_usu_ing_id`)
    REFERENCES `usuario` (`usu_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_docente_card`
    FOREIGN KEY (`doc_idcarga`)
    REFERENCES `carga_docente` (`card_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `curso`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `curso` (
  `cur_id` INT NOT NULL AUTO_INCREMENT,
  `cur_nombre` VARCHAR(45) NOT NULL,
  `cur_codigo` VARCHAR(45) NULL,
  `cur_semestre` INT NULL,
  PRIMARY KEY (`cur_id`),
  UNIQUE INDEX `cur_codigo_UNIQUE` (`cur_codigo` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `sede`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sede` (
  `sed_codigo` VARCHAR(25) NOT NULL,
  `sed_nombre` VARCHAR(45) NOT NULL,
  `sed_id` INT NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`sed_id`),
  UNIQUE INDEX `sed_codigo_UNIQUE` (`sed_codigo` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `programa`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `programa` (
  `prog_codigo` VARCHAR(25) NOT NULL,
  `prog_nombre` VARCHAR(45) NOT NULL,
  `prog_id` INT NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`prog_id`),
  UNIQUE INDEX `prog_codigo_UNIQUE` (`prog_codigo` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `facultad`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `facultad` (
  `fac_codigo` VARCHAR(30) NOT NULL,
  `fac_nombre` VARCHAR(60) NULL,
  `fac_id` INT NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`fac_id`),
  UNIQUE INDEX `fac_codigo_UNIQUE` (`fac_codigo` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `carga_evaluacion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `carga_evaluacion` (
  `care_id` INT NOT NULL AUTO_INCREMENT,
  `care_fecha` DATETIME NULL,
  `care_usu_id` INT NULL,
  `care_completo` BIT NULL,
  `care_cantidad` INT NULL,
  `care_observacion` VARCHAR(255) NULL,
  `care_errores` INT NULL,
  `care_semestre` INT NULL,
  `care_ano` INT NULL,
  `care_nomarchivo` VARCHAR(255) NULL,
  PRIMARY KEY (`care_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `evaluacion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `evaluacion` (
  `eva_id` INT NOT NULL AUTO_INCREMENT,
  `cur_id` INT NOT NULL,
  `sed_id` INT NOT NULL,
  `fac_id` INT NOT NULL,
  `prog_id` INT NOT NULL,
  `eva_doc_id` INT NULL,
  `eva_care_id` INT NULL,
  `eva_modulo` VARCHAR(45) NULL,
  `eva_curriculo` VARCHAR(45) NULL,
  `eva_plan_aula` VARCHAR(60) NULL,
  `eva_fecing` DATE NULL,
  `eva_fecmod` DATE NULL,
  `eva_usu_mod_id` INT NOT NULL,
  `eva_usu_ing_id` INT NOT NULL,
  `eva_estado` INT NULL,
  PRIMARY KEY (`eva_id`),
  INDEX `fk_curso_movimiento_idx` (`cur_id` ASC) ,
  INDEX `fk_facultad_movimiento_idx` (`fac_id` ASC) ,
  INDEX `fk_sede_movimiento_idx` (`sed_id` ASC) ,
  INDEX `fk_programa_movimiento_idx` (`prog_id` ASC) ,
  INDEX `fk_docente_evaluacion_idx` (`eva_doc_id` ASC) ,
  INDEX `fk_care_evaluacion_idx` (`eva_care_id` ASC) ,
  INDEX `fk_evalucion_usu_ing_idx` (`eva_usu_mod_id` ASC) ,
  CONSTRAINT `fk_curso_evaluacion`
    FOREIGN KEY (`cur_id`)
    REFERENCES `curso` (`cur_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_sede_evaluacion`
    FOREIGN KEY (`sed_id`)
    REFERENCES `sede` (`sed_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_facultad_evaluacion`
    FOREIGN KEY (`fac_id`)
    REFERENCES `facultad` (`fac_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_programa_evaluacion`
    FOREIGN KEY (`prog_id`)
    REFERENCES `programa` (`prog_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_docente_evaluacion`
    FOREIGN KEY (`eva_doc_id`)
    REFERENCES `docente` (`doc_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_care_evaluacion`
    FOREIGN KEY (`eva_care_id`)
    REFERENCES `carga_evaluacion` (`care_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_evalucion_usu_ing`
    FOREIGN KEY (`eva_usu_mod_id`)
    REFERENCES `usuario` (`usu_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_evalucion_usu_mod`
    FOREIGN KEY (`eva_usu_ing_id`)
    REFERENCES `usuario` (`usu_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `temporal_docente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `temporal_docente` (
  `doc_documento` VARCHAR(255) NULL,
  `doc_nombre` VARCHAR(255) NULL,
  `doc_correo` VARCHAR(255) NULL,
  `doc_telefono` VARCHAR(255) NULL)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `temporal_evaluacion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `temporal_evaluacion` (
  `curso_n` VARCHAR(255) NULL,
  `semestre` VARCHAR(255) NULL,
  `sede` VARCHAR(255) NULL,
  `fecini_bloque` VARCHAR(255) NULL,
  `fecfin_bloque` VARCHAR(255) NULL,
  `fac_codigo` VARCHAR(255) NULL,
  `facultad` VARCHAR(255) NULL,
  `programa` VARCHAR(255) NULL,
  `curso` VARCHAR(255) NULL,
  `cedula` VARCHAR(255) NULL,
  `docente` VARCHAR(255) NULL,
  `modulo` VARCHAR(255) NULL,
  `curriculo` VARCHAR(255) NULL,
  `plan_aula` VARCHAR(255) NULL)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `formato`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `formato` (
  `for_id` INT NOT NULL AUTO_INCREMENT,
  `for_fase` VARCHAR(45) NOT NULL,
  `for_calif_fase` DECIMAL(18,2) NOT NULL,
  `for_item` INT NOT NULL,
  `for_descripcion` VARCHAR(255) NOT NULL,
  `for_puntaje_max` DECIMAL(18,2) NOT NULL,
  PRIMARY KEY (`for_id`))
ENGINE = InnoDB; 


-- -----------------------------------------------------
-- Table `calificacion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `calificacion` (
  `id_calificacion` INT NOT NULL AUTO_INCREMENT,
  `eva_id` INT NOT NULL,
  `for_id` INT NOT NULL,
  `cal_nota` DECIMAL(18,2) NOT NULL DEFAULT 0,
  `cal_observacion` VARCHAR(255) NULL,
  `cal_plan_mejora` BIT NULL,
  `cal_usu_ing` INT NOT NULL,
  `cal_usu_mod` INT NOT NULL,
  INDEX `fk_movimiento_calificacion_idx` (`eva_id` ASC) ,
  INDEX `fk_formato_valificacion_idx` (`for_id` ASC) ,
  PRIMARY KEY (`id_calificacion`),
  INDEX `fk_calificacion_usu_ing_idx` (`cal_usu_ing` ASC) ,
  INDEX `fk_calificacion_usu_mod_idx` (`cal_usu_mod` ASC) ,
  CONSTRAINT `fk_evaluacion_calificacion`
    FOREIGN KEY (`eva_id`)
    REFERENCES `evaluacion` (`eva_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_formato_valificacion`
    FOREIGN KEY (`for_id`)
    REFERENCES `formato` (`for_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_calificacion_usu_ing`
    FOREIGN KEY (`cal_usu_ing`)
    REFERENCES `usuario` (`usu_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_calificacion_usu_mod`
    FOREIGN KEY (`cal_usu_mod`)
    REFERENCES `usuario` (`usu_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;