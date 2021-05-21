SELECT * FROM ChilePlacer..Girls 
SELECT * FROM ChilePlacer..ProfileGirls
SELECT * FROM ChilePlacer..GaleriaGirls  
SELECT * FROM ChilePlacer..ChangePassword
SELECT * FROM ChilePlacer..PortadaGirls 
SELECT * FROM ChilePlacer..AppLog


SELECT * FROM ChilePlacer..TypeAtencion                                SELECT * FROM ChilePlacer..TypeLocation
SELECT * FROM ChilePlacer..TypeContextura
SELECT * FROM ChilePlacer..TypeCountry
SELECT * FROM ChilePlacer..TypeDepilacion
SELECT * FROM ChilePlacer..TypeDrink
SELECT * FROM ChilePlacer..TypeEscort
SELECT * FROM ChilePlacer..TypeEyes
SELECT * FROM ChilePlacer..TypeGirls 
--SELECT * FROM ChilePlacer..TypeGirlServices
--SELECT * FROM ChilePlacer..TypeAtencionGirl

SELECT * FROM ChilePlacer..TypeHair 
SELECT * FROM ChilePlacer..TypeNacionalidad
SELECT * FROM ChilePlacer..TypePiel
SELECT * FROM ChilePlacer..TypeServicesSex
SELECT * FROM ChilePlacer..TypeSex
SELECT * FROM ChilePlacer..TypeSmoke


SELECT * FROM ChilePlacer..TypeGirlServices

SELECT * FROM ChilePlacer..Girls 
SELECT * FROM ChilePlacer..ProfileGirls
SELECT * FROM ChilePlacer..GaleriaGirls
SELECT * FROM ChilePlacer..AppLog

--TRUNCATE TABLE ChilePlacer..Girls
--TRUNCATE TABLE ChilePlacer..ProfileGirls
--TRUNCATE TABLE ChilePlacer..GaleriaGirls
--TRUNCATE TABLE ChilePlacer..ChangePassword
--TRUNCATE TABLE ChilePlacer..TypeGirls
 --TRUNCATE TABLE ChilePlacer..AppLog
--DELETE ChilePlacer..Girls Where Id > 1
   UPDATE ChilePlacer..Girls set Activo = 0 Where Id = 4
--UPDATE ChilePlacer..TypeNacionalidad set Nacionalidad = 'Chile', Ide = 'Chile' 
--UPDATE ChilePlacer..TypeDrink set Drink= 'Ocacionalmente', Ide = 'Ocacionalmente' Where Id = 3 
--UPDATE ChilePlacer..Girls Set password ='ZWZyYWlubWVqaWFzY0Bob3RtYWlsLmNvbSMxMjM0'
