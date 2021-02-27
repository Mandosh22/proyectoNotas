$(function () {
    Cargar();
});

$('#frmSecciones').submit(function (event) {
    event.preventDefault();
    Guardar();
});

// ID = #
// Clases = .

function Cargar() {
    $.ajax({
        url: "/Seccion/Obtener",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var html = '';
            $.each(data, function (key, item) {
                html += "<tr>";
                html += "<td>" + item.Id + "</td>";
                html += "<td>" + item.Nombre + "</td>";
                html += "<td>";
                html += "<a href='#' class='btn btn-info' data-toggle='modal' data-target='#miModal' onclick='VerDetalle(" + item.Id + ")'>Detalle</a> | ";
                html += "<a href='#' class='btn btn-danger' onclick='Eliminar(" + item.Id + ")'>Eliminar</a>";
                html += "</td>";
                html += "</tr>";
            });

            $("#Secciones tbody").html(html);
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}

function VerDetalle(id) {
    $.ajax({
        url: "/Seccion/ObtenerPorId?pId=" + id,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $('#Id').val(data.Id);
            $('#Nombre').val(data.Nombre);
            $('#exampleModalLabel').text("Modificar Seccion");
            $('#btnGuardar').val("Guardar Cambios");
        },
        error: function (error) {
            alert("Parece que hubo un error al hacer la petición");
            alert(error)
        }
    });
}


function Guardar() {
    if ($('#Nombre').val() == "") {
        alert("Todos los campos son requeridos!");
    } else {
        var url = ' ';
        var seccion = {
            Id: $('#Id').val(),
            Nombre: $('#Nombre').val(),
        }

        if (seccion.Id) {
            url = '/Seccion/Modificar';
        } else {
            url = '/Seccion/Agregar';
        }

        $.ajax({
            url: url,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(seccion),
            success: function (data) {
                if ($('#btnGuardar').val() == "Guardar Cambios") {
                    alert("Se guardaron los cambios");
                } else if ($('#btnGuardar').val() == "Guardar") {
                    alert("Registro guardado con éxito");
                }
                $('#miModal').modal('hide');
                Cargar();
                Limpiar();
            },
            error: function (error) {
                alert("No se pudo guardar el registro");
            }
        });
    }
}

function Limpiar() {
    $('#Id').val("");
    $('#Nombre').val("");
    $('#exampleModalLabel').text("Crear Seccion");
    $('#btnGuardar').val("Guardar");
}

function Eliminar(id) {
    var resp = confirm("¿Estas seguro que quieres eliminar este registro?");
    if (resp) {
        $.ajax({
            url: "/Horario/Eliminar?pId=" + id,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                alert("Registro eliminado con éxito");
                Cargar();
                Limpiar();
            },
            error: function (error) {
                alert("No se pudo eliminar el registro");
            }
        });
    }
}