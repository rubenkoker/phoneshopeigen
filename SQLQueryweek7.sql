
CREATE TABLE [dbo].[Brands]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(10) NULL
);

INSERT INTO Brands(
   
    Name
    )
VALUES
    (
       'Samsung'
    ),
    (
       'Apple'
    ),
    (
        'Huawei'
    )
    ,
    (
        'Google'
    ),
    (
        'Xiamei'
    ),
    (
        'Fairphone'
    );
    ALTER TABLE Phones
DROP COLUMN Brand;
ALTER TABLE Phones
ADD Brands INT; 