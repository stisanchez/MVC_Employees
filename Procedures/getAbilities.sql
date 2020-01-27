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
-- Description:	GetAllAbilities
-- =============================================
CREATE PROCEDURE getAbilities
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT DISTINCT NombreHabilidad, IdHabilidad FROM dbo.Empleado_Habilidad (NOLOCK)
END
GO
