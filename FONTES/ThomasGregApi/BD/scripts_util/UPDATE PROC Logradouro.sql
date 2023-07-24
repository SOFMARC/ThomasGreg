IF OBJECT_ID('dbo.UpdateLogradouro', 'P') IS NULL
BEGIN
    EXEC('
    CREATE PROCEDURE dbo.UpdateLogradouro
        @LogradouroId int,
        @Nome nvarchar(255)
    AS
    BEGIN
    
            UPDATE Logradouros
            SET Nome = @Nome
            WHERE id = @LogradouroId;

        
    END
    ');
END
