CREATE SCHEMA IF NOT EXISTS `fitly` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `fitly` ;

-- -----------------------------------------------------
-- Table `fitly`.`type`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `fitly`.`type` (
  `idType` INT NOT NULL AUTO_INCREMENT,
  `Spieren` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`idType`),
  UNIQUE INDEX `idType_UNIQUE` (`idType` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 26
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

LOCK TABLES `type` WRITE;
/*!40000 ALTER TABLE `type` DISABLE KEYS */;
INSERT INTO `type` VALUES (1,'Borstspieren'),(3,'Rugspieren'),(4,'Schouderspieren'),(5,'Biceps'),(6,'Triceps'),(7,'Buikspieren'),(8,'Beenspieren'),(9,'Onderarmspieren');
/*!40000 ALTER TABLE `type` ENABLE KEYS */;
UNLOCK TABLES;


-- -----------------------------------------------------
-- Table `fitly`.`oefening`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `fitly`.`oefening` (
  `idOefening` INT NOT NULL AUTO_INCREMENT,
  `Naam` VARCHAR(45) NOT NULL,
  `Omschrijving` LONGTEXT NULL,
  `Calorieen` LONGTEXT NULL DEFAULT NULL,
  `fkType` INT NOT NULL,
  `Herhalingen` INT NULL DEFAULT NULL,
  `Duur` DOUBLE NULL DEFAULT NULL,
  PRIMARY KEY (`idOefening`),
  UNIQUE INDEX `idOefening_UNIQUE` (`idOefening` ASC) VISIBLE,
  INDEX `fk_Oefening_Type_idx` (`fkType` ASC) VISIBLE,
  CONSTRAINT `fk_Oefening_Type`
    FOREIGN KEY (`fkType`)
    REFERENCES `fitly`.`type` (`idType`))
ENGINE = InnoDB
AUTO_INCREMENT = 36
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

LOCK TABLES `oefening` WRITE;
/*!40000 ALTER TABLE `oefening` DISABLE KEYS */;
INSERT INTO `oefening` (idOefening,Naam, Omschrijving, Calorieen, fkType, Herhalingen, Duur) VALUES 
(1,'Push-ups','Een oefening waarbij je jezelf omhoog duwt vanuit een plankpositie, gericht op de borst, triceps en core.','8',1,12,2),
(2,'Squats','Sta rechtop, buig door de knieën en kom weer omhoog voor sterke benen en billen.','10',8,12,1),
(3,'Deadlifts','Til een halterstang vanaf de grond omhoog voor een volledige lichaamsoefening.','12',3,5,1),
(4,'Jump Rope','Springtouw oefening die het uithoudingsvermogen en de coördinatie verbetert.','12',7,NULL,1),
(5,'Burpees','Een explosieve beweging met springen, planken en push-ups voor een full-body workout.','10',1,10,1),
(6,'Mountain Climbers','In plankpositie snel je knieën naar de borst trekken voor een intensieve cardio-oefening.','9',7,NULL,1),
(7,'Running op de plaats','Hardlopen zonder vooruit te bewegen, ideaal voor indoor cardio.','11',8,NULL,1),
(8,'Yoga Poses','Rustige houdingen zoals Downward Dog en Cobra Stretch om flexibiliteit te verbeteren.','4',7,NULL,1),
(9,'Dynamic Stretching','Bewegende stretches zoals beenzwaaien en armcirkels voor warming-up.','4',8,NULL,1),
(10,'Plank to Cobra Stretch','Een vloeiende overgang van plank naar cobra stretch voor flexibiliteit en core.','4',7,NULL,1),
(11,'Kettlebell Swings','Een dynamische oefening waarbij een kettlebell heen en weer wordt gezwaaid.','12',3,null,10),
(12,'Battle Ropes','Snelle bewegingen met zware touwen om kracht en conditie te verbeteren.','10',6,NULL,7),
(13,'Box Jumps','Spring op een verhoogd platform en land gecontroleerd voor explosieve kracht.','9',8,8,7),
(14,'Farmer’s Carry','Loop een bepaalde afstand met zware gewichten in elke hand om grip en kracht te verbeteren.','8',9,NULL,7),
(15,'Sprints','Ren op maximale snelheid voor korte afstanden voor kracht en uithoudingsvermogen.','14',8,NULL,1),
(16,'Agility Ladder Drills','Snelle voetbewegingen door een ladder op de grond voor snelheid en coördinatie.','10',8,NULL,1),
(17,'Medicine Ball Slams','Gooi een medicine bal krachtig op de grond en vang hem opnieuw.','9',4,10,1),
(18,'Shadow Boxing','Slaan in de lucht met snelle bewegingen om reactievermogen en cardio te verbeteren.','10',3,NULL,1),
(19,'Zumba','Dans-gebaseerde workout met hoge energie en ritmische bewegingen.','9',8,NULL,1),
(20,'Aerobics','Lichaamsbeweging op muziek met veel beweging voor conditie en coördinatie.','9',8,NULL,1),
(21,'Step-ups','Stap op een verhoging en wissel af met de benen voor beenkracht en balans.','8',8,NULL,1),
(22,'Foam Rolling','Zelfmassage techniek met een foam roller om spierherstel te bevorderen.','3',8,NULL,1),
(23,'Stretching','Statische rekoefeningen om de spieren te verlengen en herstel te versnellen.','3',7,NULL,1),
(24,'Ademhalingsoefeningen','Diepe ademhaling en meditatie voor ontspanning en stressvermindering.','2',7,NULL,1);
/*!40000 ALTER TABLE `oefening` ENABLE KEYS */;
UNLOCK TABLES;

-- -----------------------------------------------------
-- Table `fitly`.`sporter`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `fitly`.`sporter` (
  `idSporter` INT NOT NULL AUTO_INCREMENT,
  `Naam` TINYTEXT NULL DEFAULT NULL,
  `Voornaam` TINYTEXT NULL DEFAULT NULL,
  `Email` VARCHAR(45) NULL DEFAULT NULL,
  `Wachtwoord` VARCHAR(45) NULL DEFAULT NULL,
  `Geboortedatum` DATE NULL DEFAULT NULL,
  `Geslacht` VARCHAR(45) NULL DEFAULT NULL,
  `Lengte` DOUBLE NULL DEFAULT NULL,
  PRIMARY KEY (`idSporter`),
  UNIQUE INDEX `idSporter_UNIQUE` (`idSporter` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 9
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

LOCK TABLES `sporter` WRITE;
/*!40000 ALTER TABLE `sporter` DISABLE KEYS */;
INSERT INTO `sporter` VALUES (2,'Branders','Lander','/','/','2007-02-09','Man',1.82),(3,'Yorben','Yorben','Yorben','Yorben','2007-03-15','man',1.8),(4,'De Peuter','Tibe','TibeDePeuter7@gmail.com','TIBE','2007-09-15','Man',1.8);
/*!40000 ALTER TABLE `sporter` ENABLE KEYS */;
UNLOCK TABLES;	

-- -----------------------------------------------------
-- Table `fitly`.`workout`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `fitly`.`workout` (
  `idWorkout` INT NOT NULL AUTO_INCREMENT,
  `Herhalingen` INT NULL DEFAULT NULL,
  `NaamWorkout` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idWorkout`),
  UNIQUE INDEX `idWorkout_UNIQUE` (`idWorkout` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 15
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

LOCK TABLES `workout` WRITE;
/*!40000 ALTER TABLE `workout` DISABLE KEYS */;
INSERT INTO `workout` VALUES (1,NULL,'Krachttraining'),(2,NULL,'Cardiotraining'),(3,NULL,'Flexibiliteit en mobiliteit'),(4,NULL,'Functionele training'),(5,NULL,'Sport-specifieke training'),(6,NULL,'Groepslessen en dans'),(7,NULL,'Hersteltraining');
/*!40000 ALTER TABLE `workout` ENABLE KEYS */;
UNLOCK TABLES;

-- -----------------------------------------------------
-- Table `fitly`.`sporter_has_workout`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `fitly`.`sporter_has_workout` (
  `PKSporter` INT NOT NULL,
  `PKWorkout` INT NOT NULL,
  `Datum` DATE NULL DEFAULT NULL,
  PRIMARY KEY (`PKSporter`, `PKWorkout`),
  UNIQUE INDEX `PKSporter_UNIQUE` (`PKSporter` ASC) VISIBLE,
  UNIQUE INDEX `PKWorkout_UNIQUE` (`PKWorkout` ASC) VISIBLE,
  INDEX `fk_Sporter_has_Workout_Workout1_idx` (`PKWorkout` ASC) VISIBLE,
  INDEX `fk_Sporter_has_Workout_Sporter1_idx` (`PKSporter` ASC) VISIBLE,
  CONSTRAINT `fk_Sporter_has_Workout_Sporter1`
    FOREIGN KEY (`PKSporter`)
    REFERENCES `fitly`.`sporter` (`idSporter`),
  CONSTRAINT `fk_Sporter_has_Workout_Workout1`
    FOREIGN KEY (`PKWorkout`)
    REFERENCES `fitly`.`workout` (`idWorkout`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;



-- -----------------------------------------------------
-- Table `fitly`.`workout_has_oefening`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `fitly`.`workout_has_oefening` (
  `FKWorkout` INT NOT NULL,
  `FKoefening` INT NOT NULL,
  PRIMARY KEY (`FKWorkout`, `FKoefening`),
  INDEX `fk_workout_has_oefening_oefening1_idx` (`FKoefening` ASC) VISIBLE,
  INDEX `fk_workout_has_oefening_workout1_idx` (`FKWorkout` ASC) VISIBLE,
  CONSTRAINT `fk_workout_has_oefening_workout1`
    FOREIGN KEY (`FKWorkout`)
    REFERENCES `fitly`.`workout` (`idWorkout`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_workout_has_oefening_oefening1`
    FOREIGN KEY (`FKoefening`)
    REFERENCES `fitly`.`oefening` (`idOefening`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

LOCK TABLES `workout_has_oefening` WRITE;
/*!40000 ALTER TABLE `sporter` DISABLE KEYS */;
INSERT INTO `workout_has_oefening` VALUES 
(1,12),(1,13),(1,14),(1,15),(1,17),(1,21),
(2,6),(2,7),(2,18),(2,19),(2,20),(2,12),
(3,8),(3,10),
(7,22),(7,23),
(6,19),(6,20);
/*!40000 ALTER TABLE `workout_has_oefening` ENABLE KEYS */;
UNLOCK TABLES;	

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
