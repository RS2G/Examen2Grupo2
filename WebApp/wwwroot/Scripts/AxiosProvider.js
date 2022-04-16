"use strict";
var App;
(function (App) {
    var AxiosProvider;
    (function (AxiosProvider) {

        AxiosProvider.SolicitudEliminar = function (id) { return axios.delete("Solicitud/Grid?handler=Eliminar&id=" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.SolicitudGuardar = function (entity) { return axios.post("Solicitud/Edit", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.ServicioEliminar = function (id) { return axios.delete("Servicio/Grid?handler=Eliminar&id=" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.ServicioGuardar = function (entity) { return axios.post("Servicio/Edit", entity).then(function (_a) {

        AxiosProvider.ClienteEliminar = function (id) { return axios.delete("Cliente/Grid?handler=Eliminar&id=" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.ClienteGuardar = function (entity) { return axios.post("Cliente/Edit", entity).then(function (_a) {

            var data = _a.data;
            return data;
        }); };
    })(AxiosProvider = App.AxiosProvider || (App.AxiosProvider = {}));
})(App || (App = {}));
//# sourceMappingURL=AxiosProvider.js.map