

$(document).ready(function () {
    console.log("ready!");
    getNameTables();
});


  function getNameTables() {

    $.ajax({
        type: "POST",
        url: "AdmTables/GetNameTables",
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


function buildTable () {

    $.ajax({
        type: "POST",
        url: "AdmTables/GetRegisterTable",
        //data: { nombreTabla: nombreTabla },
        dataType: "json",
        success: function (data) {
            console.log(data);
            $("#tablaPortada thead tr").remove();
            $('#tablaPortada tbody tr').remove();

            let title = `<tr>
                            <th> Id </th>
                            <th> Identificador </th>
                            <th> Descripcion </th>
                            <th> </th>
                        </tr>`;

            $("#tablaPortada thead").append(title);

            $.each(data, function (index, item) {
                let tr = `<tr> 
                      <td> ${item.id} </td>
                      <td> ${item.ide} </td>
                      <td> ${item.descripcion} </td>
                      <td> <input type='submit' class='btn btn-primary' onClick ='eliminar(${item.id})' value='Eliminar'/> </td>
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
    console.log(nombreTabla);
    buildTable();
}