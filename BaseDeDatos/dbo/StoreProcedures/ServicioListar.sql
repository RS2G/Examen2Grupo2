CREATE PROCEDURE [dbo].[ServicioListar]
	AS
	BEGIN
	SET NOCOUNT ON

	SELECT 
		IdServicio
		,NombreServicio
	FROM dbo.Servicio

	END
