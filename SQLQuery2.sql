SELECT Phones.Description, Brands.Name, Phones.Type
FROM Phones
INNER JOIN Brands ON Phones.Brands=Brands.ID;