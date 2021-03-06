USE [Examen]
GO
/****** Object:  StoredProcedure [dbo].[getAreas]    Script Date: 1/26/2020 1:04:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Stiven Sánchez Rodríguez
-- Create date: 25/01/2020
-- Description:	Get all areas or the area sent through parameter
-- =============================================
ALTER PROCEDURE [dbo].[getAreas] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT idArea, Nombre, Descripcion 
	FROM [dbo].[Area] (NOLOCK)

END
