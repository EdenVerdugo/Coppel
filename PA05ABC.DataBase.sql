
IF NOT EXISTS(SELECT name FROM sys.databases WHERE name = 'Prueba')
BEGIN
	CREATE DATABASE Prueba;
END

GO

USE Prueba

GO
IF NOT EXISTS(SELECT name FROM sys.objects WHERE name = 'CatArticulos' AND type='U')
BEGIN
	CREATE TABLE CatArticulos(
      CatArticulosID INT IDENTITY PRIMARY KEY, 
      Descripcion varchar(200), 
      Precio numeric(18,2), 
      Costo numeric(18,2)
    )
END

GO

IF EXISTS ( SELECT name FROM sys.objects WHERE name = 'CatArticulosGuardar')
BEGIN
	DROP PROCEDURE CatArticulosGuardar
END 

GO

CREATE PROCEDURE CatArticulosGuardar @pCatArticulosID INT, @pDescripcion VARCHAR(200), @pPrecio NUMERIC(18,2), @pCosto NUMERIC(18,2), @pResultado BIT = 0 OUTPUT, @pMsg VARCHAR(300) = '' OUTPUT
AS
BEGIN
	
	SELECT @pResultado = 1, @pMsg = 'Se han guardado los cambios correctamente'
	BEGIN TRY
		IF @pCatArticulosID = 0
		BEGIN
			INSERT INTO CatArticulos (Descripcion, Precio, Costo)
			SELECT @pDescripcion, @pPrecio, @pCosto
		END
		ELSE
		BEGIN
			UPDATE CatArticulos
			SET Descripcion = @pDescripcion, Precio = @pPrecio, Costo = @pCosto
			WHERE CatArticulosID = @pCatArticulosID
		END    	         
    END TRY
    BEGIN CATCH
		SELECT @pResultado = 0, @pMsg = ERROR_MESSAGE()
		        
    	DECLARE @errorMessage NVARCHAR(4000);
    	DECLARE @errorSeverity INT;
    	DECLARE @errorState INT;
        
    	SELECT	@errorMessage = ERROR_MESSAGE(),
    			@errorSeverity = ERROR_SEVERITY(),
    			@errorState = ERROR_STATE();
        
            
    	RAISERROR(	@errorMessage, 
    				@errorSeverity, 
    				@errorState 
    				);
    END CATCH
END 

GO

IF EXISTS ( SELECT name FROM sys.objects WHERE name = 'CatArticulosEliminar')
BEGIN
	DROP PROCEDURE CatArticulosEliminar
END 

GO 

CREATE PROCEDURE CatArticulosEliminar @pCatArticulosID INT,  @pResultado BIT = 0 OUTPUT, @pMsg VARCHAR(300) = '' OUTPUT
AS
BEGIN
	
	SELECT @pResultado = 1, @pMsg = 'Se ha eliminado correctamente'

	DELETE FROM CatArticulos WHERE CatArticulosID = @pCatArticulosID

END

GO

IF EXISTS ( SELECT name FROM sys.objects WHERE name = 'CatArticulosBuscar')
BEGIN
	DROP PROCEDURE CatArticulosBuscar
END 

GO

CREATE PROCEDURE CatArticulosBuscar 
AS
BEGIN
	SELECT 	ca.CatArticulosID,
			ca.Descripcion,
			ca.Precio,
			ca.Costo
	FROM CatArticulos ca	
END