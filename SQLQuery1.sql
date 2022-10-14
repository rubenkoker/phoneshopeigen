SELECT Brand.Name ,Phones.type,Phones.Description,Phones.Price,Phones.Stock,Phones.Id
FROM Phones
INNER JOIN Brands ON Phones.BrandID=Brands.ID
WHERE Brand.name LIKE '%sams%' OR Type LIKE '%sams%' OR Description LIKE '%sams%';