namespace SolicitudEdit {

    var Entity = $("#AppEdit").data("entity")

    var Formulario = new Vue(
        {
            data:
            {
                Formulario: "#FormEdit",
                Entity: Entity
            },

            methods: {

                Save() {

                    if (BValidateData(this.Formulario)) {
                        Loading.fire("Guardando...");

                        App.AxiosProvider.SolicitudGuardar(this.Entity).then(data => {
                            Loading.close();

                            if (data.CodeError == 0) {

                                Toast.fire({ title: "La solicitud se guardó correctamente", icon: "success" })
                                    .then(() => window.location.href = "Solicitud/Grid");

                            } else {
                                Toast.fire({ title: data.MsgError, icon: "error" });
                            }

                        });

                    }
                    else {
                        Toast.fire({ title: "Por favor complete los campos requeridos", icon: "error" });
                    }
                }
            },

            mounted() {
                CreateValidator(this.Formulario);
            }

        }
    );

    Formulario.$mount("#AppEdit");

}
