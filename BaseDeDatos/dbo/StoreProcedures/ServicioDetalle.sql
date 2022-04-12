CREATE PROCEDURE [dbo].[ServicioDetalle]
	@IdServicio INT = NULL
AS
BEGIN
	SET NOCOUNT ON

	SELECT
		IdServicio
		,NombreServicio
		,PlazoEntrega
		,CostoServicio
		,Estado
		,CuentaContable
	FROM
		dbo.Servicio
	WHERE
		(@IdServicio IS NULL OR IdServicio = @IdServicio)

END
