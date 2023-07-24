IF OBJECT_ID('dbo.InsertLogradouro', 'P') IS NULL
BEGIN
    EXEC('
    CREATE PROCEDURE dbo.InsertLogradouro
        @Nome nvarchar(255),
        @ClienteId int
    AS
    BEGIN

       
    INSERT INTO Logradouros (Nome, ClienteId)
    VALUES (@Nome, @ClienteId)

    SELECT SCOPE_IDENTITY() AS Id;

          
    END
    ');
END
