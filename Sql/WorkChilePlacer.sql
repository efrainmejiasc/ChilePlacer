SELECT * FROM ChilePlacer..Girls 
SELECT * FROM ChilePlacer..ProfileGirls 
SELECT * FROM ChilePlacer..ChangePassword
SELECT * FROM ChilePlacer..GaleriaGirls 
SELECT * FROM ChilePlacer..TypeGirls 
SELECT * FROM ChilePlacer..TypeSex


--TRUNCATE TABLE ChilePlacer..Girls
--TRUNCATE TABLE ChilePlacer..ProfileGirls
--DELETE ChilePlacer..Girls Where Id > 3
UPDATE ChilePlacer..Girls set Activo = 0 WHERE Id = 2
--UPDATE ChilePlacer..Girls Set password ='ZWZyYWlubWVqaWFzY0Bob3RtYWlsLmNvbSMxMjM0'
