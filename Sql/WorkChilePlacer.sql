SELECT * FROM ChilePlacer..Girls 
SELECT * FROM ChilePlacer..ProfileGirls 
SELECT * FROM ChilePlacer..TypeGirls 
SELECT * FROM ChilePlacer..TypeSex
SELECT * FROM ChilePlacer..GaleriaGirls 

TRUNCATE TABLE ChilePlacer..Girls
TRUNCATE TABLE ChilePlacer..ProfileGirls
DELETE ChilePlacer..Girls Where Id > 3
update ChilePlacer..Girls set Activo = 0