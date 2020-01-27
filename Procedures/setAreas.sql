-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Stiven Sánchez Rodríguez
-- Create date: 25/01/2020
-- Description:	Set the new values of the area specicated in the parameter
-- =============================================
CREATE PROCEDURE setArea
	-- Add the parameters for the stored procedure 
	@idArea	INT,
	@nombre VARCHAR (100),
	@descripcion VARCHAR (2000),
	@codeError INT OUTPUT,
	@msjError VARCHAR(200) OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	BEGIN TRY
		UPDATE dbo.Area
		SET Nombre = @nombre
			,Descripcion = @descripcion
			,@codeError = 0
			,@msjError = ''
		WHERE IdArea = @idArea
	END TRY
	BEGIN CATCH
		SELECT @codeError = ERROR_NUMBER(), @msjError = ERROR_MESSAGE()
	END CATCH
END
GO
