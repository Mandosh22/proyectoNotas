$(function () {
    cargarAlumnos();
    cargarSecciones();
});


$('#frmAlumnos').submit(function (event) {
    event.preventDefault();
    guardar();
});


function cargarAlumnos() {
    $.ajax({
        url: "/Alumno/Obtener",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var html = '';
            $.each(data, function (key, item) {
                html += "<tr>";
                html += "<td>" + item.Id + "</td>";
                html += "<td>" + item.Nombre + "</td>";
                html += "<td>" + item.Apellido + "</td>";
                html += "<td>" + item.UserName + "</td>";
                html += "<td>" + item.Contraseña + "</td>";
                html += "<td>" + item.Direccion + "</td>";
                html += "<td>" + item.Correo + "</td>";
                html += "<td>" + item.NombreSeccion + "</td>";
                html += "<td>";
                html += "<a href='#' class='btn btn-info' data-toggle='modal' data-target='#miModal' onclick='verDetalle(" + item.Id + ")'>Detalle</a> | ";
                html += "<a href='#' class='btn btn-danger' onclick='eliminar(" + item.Id + ")'>Eliminar</a>";
                html += "</td>";
                html += "</tr>";
            });
            $("#alumnos tbody").html(html);
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}



function cargarSecciones() {
    $.ajax({
        url: "/Seccion/Obtener",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var html = '';
            $.each(data, function (key, item) {
                html += "  <option value='" + item.Id + "' >" + item.Nombre + "</option>";
            });
            $('#Seccion').append(html);
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}

function verDetalle(id) {
    $.ajax({
        url: "/alumno/ObtenerPorId?pId=" + id,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $('#Id').val(data.Id);
            $('#Nombre').val(data.Nombre);
            $('#Apellido').val(data.Apellido);
            $('#Username').val(data.UserName);
            $('#Contraseña').val(data.Contraseña);
            $('#Direccion').val(data.Direccion);
            $('#Correo').val(data.Correo);
            $('#Seccion').val(data.IdSeccion);
            $('#btnGuardar').val('Guardar Cambios');

        },
        error: function (error) {
            alert("Ocurrio un error, no se puedo completar la peticion");
        }
    });
}

function guardar() {
    if (!($('#Nombre').val() == "" || $('#Apellido').val() == "" || $('#Username').val() == "" || $('#Contraseña').val() == "" || $('#Direccion').val() == "" || $('#Correo').val() == "" || $('#Seccion').val() == "-1")) {
        var url = '';
        var alumno = {
            Id: $('#Id').val(),
            Nombre: $('#Nombre').val(),
            Apellido: $('#Apellido').val(),
            UserName: $('#Username').val(),
            Contraseña: $('#Contraseña').val(),
            Direccion: $('#Direccion').val(),
            Correo: $('#Correo').val(),
            IdSeccion: $('#Seccion').val()
        }

        if (alumno.Id) {
            url = '/Alumno/Modificar';
        }
        else {
            url = '/Alumno/Agregar';
        }

        $.ajax({
            url: url,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(alumno),
            success: function (data) {
                if ($('#btnGuardar').val() == "Guardar Cambios") {
                    alert("Se guardaron los cambios");
                } else if ($('#btnGuardar').val() == "Guardar") {
                    alert("Registro guardado con éxito");
                }
                $('#miModal').modal('hide');
                cargarAlumnos();
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
    $('#Nombre').val("");
    $('#Apellido').val("");
    $('#Username').val("");
    $('#Contraseña').val("");
    $('#Direccion').val("");
    $('#Correo').val("");
    $('#Seccion').val("-1");
    $('btnGuardar').val("");
}

function eliminar(id) {
    var resp = confirm("¿Estas seguro que quieres eliminar este registro?");
    if (resp) {
        $.ajax({
            url: "/Alumno/Eliminar?pId=" + id,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                alert("Registro eliminado con éxito");
                cargarAlumnos();
                limpiar();
            },
            error: function (error) {
                alert("No se pudo eliminar el registro");
            }
        });
    }
}