﻿CREATE DATABASE [phoneshop];
CREATE TABLE [dbo].[Phones]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Brand] VARCHAR(50) NULL, 
    [Type] VARCHAR(50) NULL, 
    [Description] TEXT NULL, 
    [Price] DECIMAL NULL,
    [Stock ] INT NULL
)
CREATE TABLE [dbo].[Phones]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Brand] VARCHAR(50) NULL, 
    [Type] VARCHAR(50) NULL, 
    [Description] TEXT NULL, 
    [Price] DECIMAL NULL,
    [Stock ] INT NULL
)
INSERT INTO phones([Brand], [Type], [Description], [Price],[Stock])
VALUES ('Samsung', 'Galaxy A52', '64 megapixel camera,+
        " 4k videokwaliteit 6.5 inch AMOLED scherm 128 GB opslaggeheugen (Uitbreidbaar met Micro-sd)"+
        " Water- en stofbestendig(IP67)',  399,42
       )
,

 ('Samsung', 'Galaxy A52', '64 megapixel camera,'+
        ' 4k videokwaliteit 6.5 inch AMOLED scherm 128 GB opslaggeheugen (Uitbreidbaar met Micro-sd)'+
        ' Water- en stofbestendig(IP67)',  399,42
       )
  , (
 'Apple','IPhone 11',
         'Met de dubbele camera schiet je in elke situatie een perfecte foto of video '+
        'De krachtige A13-chipset zorgt voor razendsnelle prestaties '+
        'Met Face ID hoef je enkel en alleen naar je toestel te kijken om te ontgrendelen '+
        'Het toestel heeft een lange accuduur dankzij een energiezuinige processor', 619,54 
     )
        ,(
          'Google',  'Pixel 4a',
         '12.2 megapixel camera, 4k videokwaliteit 5.81 inch OLED scherm '+
        '128 GB opslaggeheugen 3140 mAh accucapaciteit',  411,58

     ), (
          'Xiaomi', 'Redmi Note 10 Pro',
           '108 megapixel camera, 4k videokwaliteit 6.67 inch AMOLED scherm '+
          '128 GB opslaggeheugen (Uitbreidbaar met Micro-sd) Water- en stofbestendig(IP53)',  298,91

     )
     ,
 ( 'Huawei', 'P30','6.47" FHD+ (2340x1080) OLED, Kirin 980 Octa-Core (2x Cortex-A76 2.6GHz + 2x Cortex-A76 1.92GHz + 4x Cortex-A55 1.8GHz), 8GB RAM, 128GB ROM, 40+20+8+TOF/32MP, Dual SIM, 4200mAh, Android 9.0 + EMUI 9.1',  697 ,32
       ),(
 'Apple','IPhone 11',
         'Met de dubbele camera schiet je in elke situatie een perfecte foto of video '+
        'De krachtige A13-chipset zorgt voor razendsnelle prestaties '+
        'Met Face ID hoef je enkel en alleen naar je toestel te kijken om te ontgrendelen '+
       ' Het toestel heeft een lange accuduur dankzij een energiezuinige processor', 619,54 
     )
        , (
          'Google',  'Pixel 4a',
         '12.2 megapixel camera, 4k videokwaliteit 5.81 inch OLED scherm '+
        '128 GB opslaggeheugen 3140 mAh accucapaciteit',  411,58

     ), (
          'Xiaomi', 'Redmi Note 10 Pro',
           '108 megapixel camera, 4k videokwaliteit 6.67 inch AMOLED scherm'+
          '128 GB opslaggeheugen (Uitbreidbaar met Micro-sd) Water- en stofbestendig(IP53)',  298,91

     );
     INSERT INTO phones( Brand, Type, Description, Price,Stock)
VALUES ( 'Huawei', 'P30','6.47" FHD+ (2340x1080) OLED, Kirin 980 Octa-Core (2x Cortex-A76 2.6GHz + 2x Cortex-A76 1.92GHz + 4x Cortex-A55 1.8GHz), 8GB RAM, 128GB ROM, 40+20+8+TOF/32MP, Dual SIM, 4200mAh, Android 9.0 + EMUI 9.1',  697 ,32
       );