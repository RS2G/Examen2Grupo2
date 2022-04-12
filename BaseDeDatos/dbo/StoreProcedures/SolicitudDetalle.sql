CREATE PROCEDURE [dbo].[SolicitudDetalle]
	@IdSolicitud INT = NULL
AS
BEGIN
	SET NOCOUNT ON

	SELECT
		S.IdSolicitud
		,S.Cantidad
		,S.Monto
		,S.FechaEntrega
		,S.UsuarioEntrega
		,S.Observaciones
		,C.IdCliente
		,C.Nombre
		,C.PrimerApellido
		,C.SegundoApellido
		,E.IdServicio
		,E.NombreServicio


	FROM
		dbo.Solicitud S
		INNER JOIN dbo.Cliente C
			ON S.IdCliente = C.IdCliente
		INNER JOIN dbo.Servicio E
			ON S.IdServicio = E.IdServicio
	WHERE
		(@IdSolicitud IS NULL OR S.IdSolicitud = @IdSolicitud)

END
