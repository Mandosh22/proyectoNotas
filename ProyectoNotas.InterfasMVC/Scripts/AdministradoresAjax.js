$(function () {
    cargarAdministradores();
});

$('#frmAdministradores').submit(function (event) {
    event.preventDefault();
    guardar();
})


function cargarAdministradores() {
    $.ajax({
        url: "/Administrador/Obtener",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var html = '';
            $.each(data, function (key, item) {
                html += "<tr>";
                html += "<td>" + item.Id + "</td>";
                html += "<td>" + item.Username + "</td>";
                html += "<td>" + item.Contraseña + "</td>";
                html += "<td>" + item.Nombre + "</td>";
                html += "<td>" + item.ApellidO + "</td>";
                html += "<td>" + item.Direccion + "</td>";
                html += "<td>" + item.Correo + "</td>";
                html += "<td>";
                html += "<a href='#' class='btn btn-info' data-toggle='modal' data-target='#miModal' onclick='verDetalle(" + item.Id + ")'>Detalle</a> | ";
                html += "<a href='#' class='btn btn-danger' onclick='eliminar(" + item.Id + ")'>Eliminar</a>";
                html += "</td>";
                html += "</tr>";
            });
            $("#administradores tbody").html(html);
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}

function verDetalle(id) {
    $.ajax({
        url: "/administrador/ObtenerPorId?pId=" + id,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $('#Id').val(data.Id);
            $('#Username').val(data.Username);
            $('#Contraseña').val(data.Contraseña);
            $('#Nombre').val(data.Nombre);
            $('#ApellidO').val(data.ApellidO);
            $('#Direccion').val(data.Direccion);
            $('#Correo').val(data.Correo);
            $('#btnGuardar').val('Guardar Cambios');

        },
        error: function (error) {
            alert("Ocurrio un error, no se puedo completar la peticion");
        }
    });
}

function guardar() {
    if (!($('#Username').val() == "" || $('#Contraseña').val() == "" || $('#Nombre').val() == "" || $('#ApellidO').val() == "" || $('#Direccion').val() == "" || $('#Correo').val() == "")) {
        var url = '';
        var administrador = {
            Id: $('#Id').val(),
            Username: $('#Username').val(),
            Contraseña: $('#Contraseña').val(),
            Nombre: $('#Nombre').val(),
            ApellidO: $('#ApellidO').val(),
            Direccion: $('#Direccion').val(),
            Correo: $('#Correo').val(),
        }

        if (administrador.Id) {
            url = '/Administrador/Modificar';
        }
        else {
            url = '/Administrador/Agregar';
        }

        $.ajax({
            url: url,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(administrador),
            success: function (data) {
                if ($('#btnGuardar').val() == "Guardar Cambios") {
                    alert("Se guardaron los cambios");
                } else if ($('#btnGuardar').val() == "Guardar") {
                    alert("Registro guardado con éxito");
                }
                $('#miModal').modal('hide');
                cargarAdministradores();
                limpiar();
            },
            error: function (error) {
                alert("No se pudo guardar el registro");
            }
        });
    }
    else {
        alert("Todos los campos son requeridos");
    }
}

function limpiar() {
    $('#Id').val("");
    $('#Username').val("");
    $('#Contraseña').val("");
    $('#Nombre').val("");
    $('#ApellidO').val("");
    $('#Direccion').val("");
    $('#Correo').val("");
    $('btnGuardar').val("");
}

function eliminar(id) {
    var resp = confirm("¿Estas seguro que quieres eliminar este registro?");
    if (resp) {
        $.ajax({
            url: "/Administrador/Eliminar?pId=" + id,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                alert("Registro eliminado con éxito");
                cargarAdministradores();
                Limpiar();
            },
            error: function (error) {
                alert("No se pudo eliminar el registro");
            }
        });
    }
}