CREATE PROCEDURE [dbo].[ClienteListar]
	AS
	BEGIN
	SET NOCOUNT ON

	SELECT 
		IdCliente
		,Nombre
	FROM dbo.Cliente

	END
