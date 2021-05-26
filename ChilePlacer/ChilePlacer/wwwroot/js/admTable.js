

$(document).ready(function () {
    console.log("ready!");
    getIdentityUserAdm();
    getNameTables();
});


function inicio() {
    window.location.href = 'Index';
}

function goToCountry() {
    window.location.href = 'AdmTableCountry';
}


function getIdentityUserAdm() {

    $.ajax({
        type: "POST",
        url: "GetIdentityUserAdm",
        dataType: "json",
        success: function (data) {
            if (data === null)
                window.location.href = 'Index';
        },
        complete: function () {
            console.log('GetIdentityUserAdm');
        }
    });

    return false;
}

  function getNameTables() {

    $.ajax({
        type: "POST",
        url: "GetNameTables",
        dataType: "json",
        success: function (data) {
            $("#tables").empty();
            $('#tables').append('<option selected disabled value="-1">Seleccione tabla...</option>');
            $.each(data, function (index, value) {
                $('#tables').append('<option  value="' + value.idTabla + '">' + value.nombreTabla + '</option>');
            });
        }
    });

    return false;
}


function buildTable (tableName) {

    $.ajax({
        type: "POST",
        url: "GetRegisterTable",
        data: { tableName: tableName },
        dataType: "json",
        success: function (data) {
            console.log(data);
            $("#tablaPortada thead tr").remove();
            $('#tablaPortada tbody tr').remove();

            let title = `<tr>

                            <th> Identificador </th>
                            <th> Descripcion </th>
                            <th> </th>
                        </tr>`;

            $("#tablaPortada thead").append(title);

            $.each(data, function (index, item) {
                let tr = `<tr> 
                      <td> ${item.ide} </td>
                      <td> ${item.descripcion} </td>
                      <td> <input type='submit' class='btn btn-danger' onClick = "eliminarItem('${item.id}')" value='Eliminar'/> </td>
                      </tr>`;
                $('#tablaPortada tbody').append(tr);
            });
        },
        complete: function () {
            console.log('RegistrosTabla');
        }
    });

    return false;
}

function buscarRegistros() {

    var nombreTabla = $('#tables').val();
    $('#_tabla').val(nombreTabla);
    console.log(nombreTabla);
    buildTable(nombreTabla);
}

function nuevo() {
    var nombreTabla = $('#_tabla').val();
    if (nombreTabla === '') {
        alert('Seleccione una tabla para agregar item');
        return false;
    }

    $('#modal').show();
}


function cancelar() {
    $('#modal').hide();
}

function nuevoItem() {
    var nombreTabla = $('#_tabla').val();
    var descripcion = $('#_item').val();

    if (descripcion === '' || nombreTabla === '') {
        alert('Seleccione una tabla  e ingrese descripcion');
        return false;
    }

    $.ajax({
        type: "POST",
        url: "AdmTables/InsertRegisterTable",
        data: { tableName: nombreTabla, descripcion: descripcion },
        dataType: "json",
        success: function (data) {
            console.log(data);
            buildTable(nombreTabla);
            $('#modal').hide();
        },
        complete: function () {
            console.log('NuevoItem');
        }
    });

    return false;
}


function eliminarItem(id) {
    var nombreTabla = $('#_tabla').val();

    $.ajax({
        type: "POST",
        url: "DeleteRegisterTable",
        data: { tableName: nombreTabla, id: id },
        dataType: "json",
        success: function (data) {
            console.log(data);
            buildTable(nombreTabla);
        },
        complete: function () {
            console.log('NuevoItem');
        }
    });

    return false;
}