
var IdUsuario = localStorage.getItem('IdUsuario');
console.log(IdUsuario);
$(function () {
  
    cargarSecciones();
    cargarNotas();
});

$('#frmNotas').submit(function (event) {
    event.preventDefault();
    guardar();
});


function cargarNotas() {
    $.ajax({
        url: "/Nota/Obtener?pId=" + IdUsuario,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var html = '';
            $.each(data, function (key, item) {
                html += "<tr>";
                html += "<td>" + item.Id + "</td>";
                html += "<td>" + item.NombreAlumno + "</td>";
                html += "<td>" + item.NombreProfesor + "</td>";
                html += "<td>" + item.Notas + "</td>";

                html += "<td>";
                html += "<a href='#' class='btn btn-info' data-toggle='modal' data-target='#miModal' onclick='verDetalle(" + item.Id + ")'>Detalle</a> | ";
                html += "<a href='#' class='btn btn-danger' onclick='eliminar(" + item.Id + ")'>Eliminar</a>";
                html += "</td>";
                html += "</tr>";
            });
            $("#notasalumnos tbody").html(html);
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}

function cargarSecciones() {

  


    $.ajax({
       
        url: "/DetalleSeccion/ObtenerPorSeccionPorProfesor?pId=" + IdUsuario,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(data)
            var html = '';
            $.each(data, function (key, item) {
                html += "  <option value='" + item.IdSeccion + "' >" + item.NombreSeccion + "</option>";
            });
            $('#Seccion').append(html);
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
  
}



function ObtenerAlumnosPorSeccion() {

    var id = $('#Seccion').val();

    console.log(id);
    $.ajax({
  
        url: "/Alumno/ObtenerPorS?pId=" + id,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(data);
            $('#Alumno').empty();
            $('#Alumno').append('<option value="-1">Seleccione una alumno</option>');
            var html = '';
            $.each(data, function (key, item) {
                html += "  <option value='" + item.Id + "' >" + item.Nombre + " " + item.Apellido + " </option>";
            });
            $('#Alumno').append(html);



        },
        error: function (error) {
            alert("Ocurrio un error, no se puedo completar la peticion");
        }
    });

}


function guardar() {

    if (!($('#Seccion').val() === "-1" || $('#Materia').val() === "-1" || $('#Profesor').val() === "-1")) {
        var url = '';
        var notaalumno = {
            Id: $('#Id').val(),
            IdSeccion: $('#Seccion').val(),
            IdAlumno: $('#Alumno').val(),
            IdProfesor: IdUsuario,
            Notas: $('#Nota').val()

        }

        if (notaalumno.Id) {
            url = '/Nota/Modificar';
        }
        else {
            url = '/Nota/Agregar';
        }

        $.ajax({
            url: url,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(notaalumno),
            success: function (data) {
                if ($('#btnGuardar').val() == "Guardar Cambios") {
                    alert("Se guardaron los cambios");
                } else if ($('#btnGuardar').val() == "Guardar") {
                    alert("Registro guardado con éxito");
                }
                $('#miModal').modal('hide');
                cargarNotas();
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





function verDetalle(id) {


    $.ajax({
        url: "/Nota/ObtenerPorId?pId=" + id,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(data);
         //  var Profe = data.IdProfesor;
            $('#Id').val(data.Id);

            $('#Seccion').val(data.IdSeccion);
            $('#Alumno').val(data.IdAlumno);
            $('#Nota').val(data.Notas);
     
            $('#btnGuardar').val('Guardar Cambios');

        },
        error: function (error) {
            alert("Ocurrio un error, no se puedo completar la peticion");
        }
    });
}



function limpiar() {
    $('#Id').val("");
    $('#Seccion').val("-1");
    $('#Alumno').val("-1");
    $('#Nota').val("");
    $('btnGuardar').val("");
}

function eliminar(id) {
    var resp = confirm("¿Estas seguro que quieres eliminar este registro?");
    if (resp) {
        $.ajax({
            url: "/Nota/Eliminar?pId=" + id,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                alert("Registro eliminado con éxito");
                cargarSecciones();
                limpiar();
            },
            error: function (error) {
                alert("No se pudo eliminar el registro");
            }
        });
    }
}
