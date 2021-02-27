$(function () {
    cargarMaterias();
});

$('#frmMaterias').submit(function (event) {
    event.preventDefault();
    guardar();
})


function cargarMaterias() {
    $.ajax({
        url: "/Materia/Obtener",
        type: "GET",
        contentType: "application/json; charset-utf-8",
        dataType: "json",
        success: function (data) {
            var html = '';
            $.each(data, function (key, item) {
                html += "<tr>";
                html += "<td>" + item.Id + "</td>";
                html += "<td>" + item.Nombre + "</td>";
                html += "<td>";
                html += "<a href='#' class='btn btn-info' data-toggle='modal' data-target='#miModal' onclick='verDetalle(" + item.Id + ")'>Detalle</a> | ";
                html += "<a href='#' class='btn btn-danger' onclick='eliminar(" + item.Id + ")'>Eliminar</a>";
                html += "</td>";
                html += "</tr>";
            });
            $("#Materias tbody").html(html);
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}

function VerDetalle(id) {
    $.ajax({
        url: "/materia/ObtenerPorId?pId=" + id,
        type: "GET",
        contentType: "application/json; charset-utf-8",
        dataType: "json",
        success: function (data) {
            $('#Id').val(data.Id);
            $('#Nombre').val(data.Nombre);
            $('#btnGuardar').val('Guardar Cambios');

        },
        error: function (error) {
            alert("Ocurrio un error, no se puedo completar la peticion");
        }
    });
}

function guardar() {
    if (!($('#Nombre').val() == "")) {
        var url = "";
        var materia = {
            Id: $('#Id').val(),
            Nombre: $('#Nombre').val()
        }

        if (materia.Id) {
            url = '/Materia/Modificar';
        }
        else {
            url = '/Materia/Agregar';
        }

        console.log(materia);
        console.log(url);

        $.ajax({
            url: url,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(materia),
            success: function (data) {
                alert("Registro guardado con exito");
                $('#mimodal').modal('hide');
                cargarMaterias();
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

function limpiar(){
    $('#Id').val("");
    $('#Nombre').val("");
    $('btnGuardar').val("");
}

function eliminar(id) {
    var resp = confirm("¿Desea eliminar Registro?");
    if (resp) {
        $.ajax({
            url: "/Materias/Eliminar?pId=" + id,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                alert("Resgistro Eliminado");
                cargarMaterias();
            },
            error: function (error) {
                alert("Ocurrio un error al eliminar");
            }

        });
    }
}