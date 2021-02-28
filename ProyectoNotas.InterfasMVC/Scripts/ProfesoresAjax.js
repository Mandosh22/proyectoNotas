$(function () {
    cargarProfesores();
    cargarMaterias();
});


$('#frmProfesores').submit(function (event) {
    event.preventDefault();
    guardar();
});


function cargarProfesores() {
    $.ajax({
        url: "/Profesor/Obtener",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var html = '';
            $.each(data, function (key, item) {
                html += "<tr>";
                html += "<td>" + item.Id + "</td>";
                html += "<td>" + item.UserName + "</td>";
                html += "<td>" + item.Contraseña + "</td>";
                html += "<td>" + item.Nombre + "</td>";
                html += "<td>" + item.Apellido + "</td>";
                html += "<td>" + item.Direccion + "</td>";
                html += "<td>" + item.Correo + "</td>";
                html += "<td>" + item.IdMateria + "</td>";
                html += "<td>";
                html += "<a href='#' class='btn btn-info' data-toggle='modal' data-target='#miModal' onclick='verDetalle(" + item.Id + ")'>Detalle</a> | ";
                html += "<a href='#' class='btn btn-danger' onclick='eliminar(" + item.Id + ")'>Eliminar</a>";
                html += "</td>";
                html += "</tr>";
            });
            $("#profesores tbody").html(html);
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}



function cargarMaterias() {
    $.ajax({
        url: "/Materia/Obtener",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var html = '';
            $.each(data, function (key, item) {
                html += "  <option value='" + item.Id + "' >" + item.Nombre + "</option>";
            });
            $('#Materia').append(html);
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}

function verDetalle(id) {
    $.ajax({
        url: "/Profesor/ObtenerPorId?pId=" + id,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $('#Id').val(data.Id);
            $('#UserName').val(data.UserName);
            $('#Contraseña').val(data.Contraseña);
            $('#Nombre').val(data.Nombre);
            $('#Apellido').val(data.Apellido);
            $('#Direccion').val(data.Direccion);
            $('#Correo').val(data.Correo);
            $('#Materia').val(data.IdMateria);
            $('#btnGuardar').val('Guardar Cambios');

        },
        error: function (error) {
            alert("Ocurrio un error, no se puedo completar la peticion");
        }
    });
}

function guardar() {
    if (!($('#Username').val() == "" || $('#Contraseña').val() == "" || $('#Nombre').val() == "" || $('#Apellido').val() == "" || $('#Direccion').val() == "" || $('#Correo').val() == "" || $('#Materia').val() == "-1")) {
        var url = '';
        var profesor = {
            Id: $('#Id').val(),
            UserName: $('#UserName').val(),
            Contraseña: $('#Contraseña').val(),
            Nombre: $('#Nombre').val(),
            Apellido: $('#Apellido').val(),
            Direccion: $('#Direccion').val(),
            Correo: $('#Correo').val(),
            IdMateria: $('#Materia').val()
        }

        if (profesor.Id) {
            url = '/Profesor/Modificar';
        }
        else {
            url = '/Profesor/Agregar';
        }

        $.ajax({
            url: url,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(profesor),
            success: function (data) {
                if ($('#btnGuardar').val() == "Guardar Cambios") {
                    alert("Se guardaron los cambios");
                } else if ($('#btnGuardar').val() == "Guardar") {
                    alert("Registro guardado con éxito");
                }
                $('#miModal').modal('hide');
                cargarProfesores();
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
    $('#UserName').val("");
    $('#Contraseña').val("");
    $('#Nombre').val("");
    $('#Apellido').val("");
    $('#Direccion').val("");
    $('#Correo').val("");
    $('#Materia').val("-1");
    $('btnGuardar').val("");
}

function eliminar(id) {
    var resp = confirm("¿Estas seguro que quieres eliminar este registro?");
    if (resp) {
        $.ajax({
            url: "/Profesor/Eliminar?pId=" + id,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                alert("Registro eliminado con éxito");
                cargarProfesores();
                limpiar();
            },
            error: function (error) {
                alert("No se pudo eliminar el registro");
            }
        });
    }
}