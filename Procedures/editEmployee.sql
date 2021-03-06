USE [Examen]
GO
/****** Object:  StoredProcedure [dbo].[editEmployee]    Script Date: 1/26/2020 8:54:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Stiven Sanchez Rodriguez
-- Create date: 26/01/2020
-- Description:	add a new employee
-- =============================================

ALTER PROCEDURE [dbo].[editEmployee]
	-- Add the parameters for the stored procedure here
	@idEmployee INT,
	@NombreCompleto VARCHAR(100),
    @Cedula VARCHAR(50),
    @Correo VARCHAR(100),
    @FechaNacimiento DATE,
    @FechaIngreso DATE,
    @IdJefe INT,
    @IdArea INT,
    @Foto VARBINARY(MAX) = NULL,
	@codeError INT OUTPUT,
	@msjError VARCHAR(200) OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN TRY
		
	UPDATE [dbo].[Empleado]
	   SET [NombreCompleto] = @NombreCompleto
		  ,[Cedula] = @Cedula
		  ,[Correo] = @Correo
		  ,[FechaNacimiento] = @FechaNacimiento
		  ,[FechaIngreso] = @FechaIngreso
		  ,[IdJefe] = @IdJefe
		  ,[IdArea] = @IdArea
		  ,[Foto] = @Foto
	 WHERE IdEmpleado = @idEmployee

		
		SET @msjError = ''
		SET @codeError = 0
	END TRY
	BEGIN CATCH
		SELECT @codeError = ERROR_NUMBER(), @msjError = ERROR_MESSAGE()
	END CATCH

END
