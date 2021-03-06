
$('#frmLogin').submit(function (event) {
    event.preventDefault();
    auntentificar();
});



$('#frmLoginAdmi').submit(function (event) {
    event.preventDefault();
    auntentificarAdmin();
});



function auntentificar() {

    if (!$('#UserName').val == "" || $('#Contraseña').val == "") {
        var usuario = {
            UserName: $('#UserName').val(),
            Contraseña: $('#Contraseña').val()


        }


        $.ajax({
            url: "/Login/Login",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(usuario),
            success: function (resp) {
                alert("Bienvenido " +  resp.Nombre +''+ resp.Apellido);
                location.href = "/Nota/Index";
                localStorage.setItem('IdUsuario', resp.Id);
           //     EnviarIdProfe(IdProfesor);
            },
            error: function (error) {
                alert("Error en la solicitud");
            }
        });


    } else {
        alert("Todos los campos son requeridos");
    }
}
 
function auntentificarAdmin() {

    if (!$('#UserNameAdmi').val == "" || $('#ContraseñaAdmi').val == "") {
        var usuario = {
            UserName: $('#UserNameAdmi').val(),
            Contraseña: $('#ContraseñaAdmi').val()


        }


        $.ajax({
            url: "/Login/LoginAdmin",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(usuario),
            success: function (resp) {
                alert("Bienvenido " );
                location.href = "/Administrador/Index";
                localStorage.setItem('IdUsuario', resp.Id);
                //     EnviarIdProfe(IdProfesor);
            },
            error: function (error) {
                alert("Error en la solicitud");
            }
        });


    } else {
        alert("Todos los campos son requeridos");
    }
}