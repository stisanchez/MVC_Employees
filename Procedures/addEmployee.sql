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
-- Create date: 26/01/2020
-- Description:	add a new employee
-- =============================================

CREATE PROCEDURE addEmployee
	-- Add the parameters for the stored procedure here
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
		INSERT INTO [dbo].[Empleado]
			   ([NombreCompleto]
			   ,[Cedula]
			   ,[Correo]
			   ,[FechaNacimiento]
			   ,[FechaIngreso]
			   ,[IdJefe]
			   ,[IdArea]
			   ,[Foto])
		 VALUES
			   (@NombreCompleto
			   ,@Cedula
			   ,@Correo
			   ,@FechaNacimiento
			   ,@FechaIngreso
			   ,@IdJefe
			   ,@IdArea
			   ,@Foto)
		SET @msjError = ''
		SET @codeError = 0
	END TRY
	BEGIN CATCH
		SELECT @codeError = ERROR_NUMBER(), @msjError = ERROR_MESSAGE()
	END CATCH

END
GO
