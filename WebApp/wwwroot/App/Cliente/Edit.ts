namespace ClienteEdit {

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

                        App.AxiosProvider.ClienteGuardar(this.Entity).then(data => {
                            Loading.close();

                            if (data.CodeError == 0) {

                                Toast.fire({ title: "El registro se inserto correctamente", icon: "success" })
                                    .then(() => window.location.href = "Cliente/Grid");

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