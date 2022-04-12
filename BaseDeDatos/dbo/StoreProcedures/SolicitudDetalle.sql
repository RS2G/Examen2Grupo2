CREATE PROCEDURE [dbo].[SolicitudDetalle]
	@IdSolicitud INT = NULL
AS
BEGIN
	SET NOCOUNT ON

	SELECT
		C.IdCliente
		,E.IdServicio
		,S.Cantidad
		,S.Monto
		,S.FechaEntrega
		,S.UsuarioEntrega
		,S.Observaciones


	FROM
		dbo.Solicitud S
		INNER JOIN dbo.Cliente C
			ON S.IdCliente = C.IdCliente
		INNER JOIN dbo.Servicio E
			ON S.IdServicio = E.IdServicio
	WHERE
		(@IdSolicitud IS NULL OR S.IdSolicitud = @IdSolicitud)

END
