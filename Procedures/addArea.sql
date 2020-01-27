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
-- Author:		Stiven Sanchez Rodriguez
-- Create date: 25/01/2020
-- Description:	Add a new area 
-- =============================================
CREATE PROCEDURE addArea 
	-- Add the parameters for the stored procedure here
	@nombre VARCHAR(100),
	@descripcion VARCHAR(2000),
	@codeError INT OUTPUT,
	@msjError VARCHAR(200) OUTPUT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    BEGIN TRY

		INSERT INTO [dbo].[Area]
				   ([Nombre]
				   ,[Descripcion])
		 VALUES
			   (@nombre
			   ,@descripcion)
		
		SET @codeError = 0
		SET @msjError = ''

	END TRY
	BEGIN CATCH
		SELECT @codeError = ERROR_NUMBER(), @msjError = ERROR_MESSAGE()
	END CATCH
END
GO
