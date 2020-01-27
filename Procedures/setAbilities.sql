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

CREATE PROCEDURE setAbilities
	@idEmployee INT,
	@idHabilidad INT,
	@insertAbility INT,
	@nombre VARCHAR(100),
	@codeError INT OUTPUT,
	@msjError VARCHAR(100) OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    	BEGIN TRY

		IF(@insertAbility = 1)
		BEGIN
			INSERT INTO [dbo].[Empleado_Habilidad]
			   ([IdEmpleado]
			   ,[NombreHabilidad])
			VALUES
			   (@idEmployee
			   ,@nombre
			   )
		END
		ELSE
		BEGIN
			DELETE FROM Empleado_Habilidad
			WHERE IdHabilidad = @idHabilidad
		END

		
		SET @msjError = ''
		SET @codeError = 0
	END TRY
	BEGIN CATCH
		SELECT @codeError = ERROR_NUMBER(), @msjError = ERROR_MESSAGE()
	END CATCH
END
GO
