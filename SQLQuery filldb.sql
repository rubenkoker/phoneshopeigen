INSERT INTO Brands( Name)
VALUES ( 'Apple'); 
INSERT INTO Brands( Name)
VALUES ( 'OnePlus'); 
INSERT INTO Brands( Name)
VALUES ( 'Motorola'); 
INSERT INTO Brands( Name)
VALUES ( 'Poco');
INSERT INTO Brands( Name)
VALUES ( 'Huawei');
INSERT INTO Brands( Name)
VALUES ( 'Samsung');
INSERT INTO Brands( Name)
VALUES ( 'Google');
INSERT INTO Brands( Name)
VALUES ( 'Xiaomi');

INSERT INTO Phones(BrandId, Type, Description, Price,Stock)
VALUES (5, 'iPhone 12 Pro 128GB Zwart', 'wgehyhwr',1028 ,43);
INSERT INTO Phones(BrandId, Type, Description, Price,Stock)
VALUES (6, 'Nord 2 128GB Grijs', 'wgehyhwr',439 ,43);
INSERT INTO Phones(BrandId, Type, Description, Price,Stock)
VALUES (7, 'Moto G20 Blauw', 'wgehyhwr',129 ,43);
INSERT INTO Phones(BrandId, Type, Description, Price,Stock)
VALUES (8, 'X3 Pro 128GB Zwart', 'wgehyhwr',199 ,43);
INSERT INTO Phones(BrandId, Type, Description, Price,Stock)
VALUES (9,'Galaxy A52', '6.47" FHD+ (2340x1080) OLED, Kirin 980 Octa-Core (2x Cortex-A76 2.6GHz + 2x Cortex-A76 1.92GHz + 4x Cortex-A55 1.8GHz), 8GB RAM, 128GB ROM, 40+20+8+TOF/32MP, Dual SIM, 4200mAh, Android 9.0 + EMUI 9.1',199 ,43);

INSERT INTO Phones(BrandId, Type, Description, Price,Stock)
VALUES (5, 'iPhone 11', 'Met de dubbele camera schiet je in elke situatie een perfecte foto of video De krachtige A13-chipset zorgt voor razendsnelle prestaties Met Face ID hoef je enkel en alleen naar je toestel te kijken om te ontgrendelen Het toestel heeft een lange accuduur dankzij een energiezuinige processor',619 ,43);
INSERT INTO Phones(BrandId, Type, Description, Price,Stock)
VALUES (12,'Redmi Note 10 Pro', '108 megapixel camera, 4k videokwaliteit 6.67 inch AMOLED scherm 128 GB opslaggeheugen (Uitbreidbaar met Micro-sd) Water-en stofbestendig (IP53)',619 ,43);












ALTER TABLE Phones NOCHECK CONSTRAINT ALL;