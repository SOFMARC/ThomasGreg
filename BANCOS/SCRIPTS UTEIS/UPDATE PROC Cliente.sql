IF OBJECT_ID('dbo.UpdateCliente', 'P') IS NULL
BEGIN
    EXEC('
    CREATE PROCEDURE dbo.UpdateCliente
        @ClienteId int,
        @Nome nvarchar(255),
        @Email nvarchar(255),
        @Logotipo varbinary(max)
    AS
    BEGIN

            -- Atualizar informa��es do Cliente
            UPDATE Cliente
            SET Nome = @Nome,
                Email = @Email,
                Logotipo = @Logotipo
            WHERE ClienteId = @ClienteId;

          
    END
    ');
END
