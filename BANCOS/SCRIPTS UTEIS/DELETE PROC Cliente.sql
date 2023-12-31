IF OBJECT_ID('dbo.DeleteCliente', 'P') IS NULL
BEGIN
    EXEC('
    CREATE PROCEDURE dbo.DeleteCliente
        @ClienteId int
    AS
    BEGIN
        SET NOCOUNT ON;
        DECLARE @TransactionName nvarchar(20) = ''DeleteCliente_Transaction'';

        BEGIN TRANSACTION @TransactionName;
        BEGIN TRY
            -- Excluir o cliente
            DELETE FROM Clientes
            WHERE Id = @ClienteId;

            COMMIT TRANSACTION @TransactionName;
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION @TransactionName;

        END CATCH
    END
    ');
END
