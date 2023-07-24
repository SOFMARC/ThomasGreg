IF OBJECT_ID('dbo.GetClienteById', 'P') IS NULL
BEGIN
    EXEC('
    CREATE PROCEDURE dbo.GetClienteById
        @ClienteId int
    AS
	BEGIN
        SET NOCOUNT ON;

       SELECT Clientes.Id, Clientes.Nome, Clientes.Email, Clientes.Logotipo,
               Logradouros.Id AS LogradouroId, Logradouros.Nome AS LogradouroNome
        FROM Clientes
        LEFT JOIN Logradouros ON Clientes.Id = Logradouros.ID
        WHERE Clientes.Id = @ClienteId;
    END
    ');
END
