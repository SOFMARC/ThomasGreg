IF OBJECT_ID('dbo.InsertCliente', 'P') IS NULL
BEGIN
    EXEC('
 CREATE PROCEDURE [dbo].[InsertCliente]
    @Nome nvarchar(255),
    @Email nvarchar(255),
    @Logotipo varbinary(max) = NULL,
    @Id int OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Clientes (Nome, Email, Logotipo)
    VALUES (@Nome, @Email, @Logotipo)
        
    SET @Id = SCOPE_IDENTITY();

         
    END
    ');
END