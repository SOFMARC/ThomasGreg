IF OBJECT_ID('dbo.GetAllClientesLogradouros', 'P') IS NULL
BEGIN
    EXEC('
    CREATE PROCEDURE dbo.GetAllClientesLogradouros
    AS
    BEGIN
        SET NOCOUNT ON;

            SELECT 
            C.Id,
            C.Nome,
            C.Email,
            C.Logotipo,
            L.Id AS LogradouroId,
            L.Nome AS LogradouroNome
        FROM 
            Clientes C
        LEFT JOIN 
            Logradouros L ON C.Id = L.ClienteId;
    END
    ');
END
