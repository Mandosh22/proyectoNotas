$(function () {
    cargarDetalleSeccion();
    cargarSecciones();
    cargarMaterias();
});


$('#frmDetalleSecciones').submit(function (event) {
    event.preventDefault();
    guardar();
});




function cargarDetalleSeccion() {
    $.ajax({
        url: "/DetalleSeccion/Obtener",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var html = '';
            $.each(data, function (key, item) {
                html += "<tr>";
                html += "<td>" + item.Id + "</td>";
                html += "<td>" + item.IdSeccion + "</td>";
                html += "<td>" + item.IdMateria + "</td>";
                html += "<td>" + item.IdProfesor + "</td>";
                
                html += "<td>";
                html += "<a href='#' class='btn btn-info' data-toggle='modal' data-target='#miModal' onclick='verDetalle(" + item.Id + ")'>Detalle</a> | ";
                html += "<a href='#' class='btn btn-danger' onclick='eliminar(" + item.Id + ")'>Eliminar</a>";
                html += "</td>";
                html += "</tr>";
            });
            $("#detallesecciones tbody").html(html);
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



function ObtenerProfesores() {
  
    var id = $('#Materia').val();
    
    console.log(id);
    $.ajax({
        url: "/Profesor/ObtenerPorMateria?pId=" + id,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(data);
            $('#Profesor').empty();
            $('#Profesor').append('<option value="-1">Seleccione una opcion</option>');
            var html = '';
            $.each(data, function (key, item) {
                html += "  <option value='" + item.Id + "' >" + item.Nombre + " " + item.Apellido + " </option>";
            });
            $('#Profesor').append(html);
            
   

        },
        error: function (error) {
            alert("Ocurrio un error, no se puedo completar la peticion");
        }
    });
  
}


function verDetalle(id) {
    $.ajax({
        url: "/DetalleSeccion/ObtenerPorId?pId=" + id,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $('#Id').val(data.Id);

            $('#Seccion').val(data.IdSeccion);
            $('#Materia').val(data.IdMateria);
            $('#Profesor').val(data.IdProfesor);
            $('#btnGuardar').val('Guardar Cambios');

        },
        error: function (error) {
            alert("Ocurrio un error, no se puedo completar la peticion");
        }
    });
}



function guardar() {

    if (!($('#Seccion').val() === "-1"|| $('#Materia').val() === "-1" || $('#Profesor').val() === "-1")) {
        var url = '';
        var detalleseccion = {
            Id: $('#Id').val(),         
            IdSeccion: $('#Seccion').val(),
            IdMateria: $('#Materia').val(),
            IdProfesor: $('#Profesor').val()
        }

        if (detalleseccion.Id) {
            url = '/DetalleSeccion/Modificar';
        }
        else {
            url = '/DetalleSeccion/Agregar';
        }

        $.ajax({
            url: url,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(detalleseccion),
            success: function (data) {
                if ($('#btnGuardar').val() == "Guardar Cambios") {
                    alert("Se guardaron los cambios");
                } else if ($('#btnGuardar').val() == "Guardar") {
                    alert("Registro guardado con éxito");
                }
                $('#miModal').modal('hide');
                cargarDetalleSeccion();
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
    $('#Seccion').val("-1");
    $('#Materia').val("-1");
    $('#Profesor').val("-1");
    $('btnGuardar').val("");
}

function eliminar(id) {
    var resp = confirm("¿Estas seguro que quieres eliminar este registro?");
    if (resp) {
        $.ajax({
            url: "/DetalleSeccion/Eliminar?pId=" + id,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                alert("Registro eliminado con éxito");
                cargarDetalleSeccion();
                limpiar();
            },
            error: function (error) {
                alert("No se pudo eliminar el registro");
            }
        });
    }
}

