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
-- Description:	Get all employees
-- =============================================
CREATE PROCEDURE getEmployees 
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	WITH jefe_CTE (idJefe, nombreJefe)
	AS
	(
		SELECT idEmpleado, NombreCompleto FROM dbo.Empleado (NOLOCK) 
	)

    /****** Script for SelectTopNRows command from SSMS  ******/
	SELECT IdEmpleado
		  ,NombreCompleto
		  ,Cedula
		  ,Correo
		  ,FechaNacimiento
		  ,FechaIngreso
		  ,E.IdJefe
		  ,ISNULL(J.nombreJefe,'') NombreJefe
		  ,A.IdArea
		  ,A.Nombre NombreArea
		  ,Foto
	 FROM dbo.Empleado E (NOLOCK)
	 INNER JOIN dbo.Area A (NOLOCK) ON E.IdArea = A.IdArea
	 LEFT JOIN jefe_CTE J (NOLOCK) ON J.idJefe = E.IdJefe
END
GO
