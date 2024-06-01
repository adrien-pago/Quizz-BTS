-- MySQL Script generated by MySQL Workbench
-- 11/04/17 12:57:24
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema quizz_init
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `quizz_init` ;

-- -----------------------------------------------------
-- Schema quizz_init
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `quizz_init` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `quizz_init` ;

-- -----------------------------------------------------
-- Table `quizz_init`.`Joueurs`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `quizz_init`.`Joueurs` ;

CREATE TABLE IF NOT EXISTS `quizz_init`.`Joueurs` (
  `idJoueurs` INT NOT NULL AUTO_INCREMENT,
  `Pseudo` VARCHAR(105) NOT NULL,
  `score` TINYINT NOT NULL,
  PRIMARY KEY (`idJoueurs`))
ENGINE = INNODB;


-- -----------------------------------------------------
-- Table `quizz_init`.`Categories`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `quizz_init`.`Categories` ;

CREATE TABLE IF NOT EXISTS `quizz_init`.`Categories` (
  `idCategories` INT NOT NULL AUTO_INCREMENT,
  `Nom` TEXT NOT NULL,
  PRIMARY KEY (`idCategories`))
ENGINE = INNODB;


-- -----------------------------------------------------
-- Table `quizz_init_init`.`Question`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `quizz_init`.`Question` ;

CREATE TABLE IF NOT EXISTS `quizz_init`.`Question` (
  `idQuestion` INT NOT NULL AUTO_INCREMENT,
  `Question` TEXT NOT NULL,
  `Fkcategories` INT NOT NULL,
  `Reponse_1` TEXT NOT NULL,
  `Reponse_2` TEXT NOT NULL,
  `Reponse_3` TEXT NOT NULL,
  `Bonne` INT NOT NULL,
  PRIMARY KEY (`idQuestion`),
  INDEX `fk_Question_catégories1_idx` (`Fkcategories` ASC),
  CONSTRAINT `fk_Question_catégories1`
    FOREIGN KEY (`Fkcategories`)
    REFERENCES `quizz_init`.`Categories` (`idCategories`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = INNODB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;