ALTER TABLE phones
DROP COLUMN Stock2, column_name;

UPDATE Phones
SET Brands = 1
WHERE ID = 11;
UPDATE Phones
SET Brands = 2
WHERE ID = 12;
UPDATE Phones
SET Brands = 3
WHERE ID = 15;
UPDATE Phones
SET Brands = 4
WHERE ID = 13;
UPDATE Phones
SET Brands = 5
WHERE ID = 14;
UPDATE Phones
SET Brands = 6
WHERE ID = 16;