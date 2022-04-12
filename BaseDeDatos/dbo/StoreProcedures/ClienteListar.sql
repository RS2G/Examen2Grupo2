CREATE PROCEDURE [dbo].[ClienteListar]
	AS
	BEGIN
	SET NOCOUNT ON

	SELECT 
		IdCliente
		,Nombre
		,PrimerApellido
		,SegundoApellido
	FROM dbo.Cliente

	END
