SELECT Phones.Description,Phones.Id,
Phones.Stock,Phones.Price,
Brands.Name,
Phones.Type FROM Phones 
INNER JOIN Brands ON Phones.Brands = Brands.ID;

SELECT Phones.Description,Phones.Id,Phones.Stock,Phones.Price,Brands.Name,Phones.Type FROM Phones INNER JOIN Brands ON Phones.Brands = Brands.ID;

INSERT INTO phones (Price,Brands, Type, Description,stock) 
  VALUES({input.Price},7,'{input.Type}','{input.Description}''{input.Stock}');

  INSERT INTO phones (Price,Brands, Type, Description,stock) 
  VALUES(500,7,'4','deze nederlandse telefoon is fairtrade en heef 5g''8');