
$(document).ready(function () {
    console.log("ready!");
    getIdentityUserAdm();
    buildTablePais()
});

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

function buildTablePais() {

    $.ajax({
        type: "POST",
        url: "GetPaises",
        dataType: "json",
        success: function (data) {
            console.log(data);
            $("#tablaPortada thead tr").remove();
            $('#tablaPortada tbody tr').remove();

            let title = `<tr>

                            <th> Pais </th>
                            <th> </th>
                            <th> </th>
                        </tr>`;

            $("#tablaPortada thead").append(title);

            $.each(data, function (index, item) {
                let tr = `<tr> 
                        <td> ${item.ide} </td>
                         <td> <input type='submit' class='btn btn-primary' onClick = "buildTableLocalidad( '${item.ide}')" value='Localidades'/> </td>
                        <td> <input type='submit' class='btn btn-success' onClick = "abrirLocalidadModal( '${item.ide}' )" value='Nueva localidad'/> </td>
                      <!--  <td> <input type='submit' class='btn btn-danger' onClick = "deletePais( '${item.id}' )" value='Eliminar'/> </td> -->
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


function deletePais(id) {

    $.ajax({
        type: "POST",
        url: "DeletePais",
        data: { id: id},
        dataType: "json",
        success: function (data) {
            buildTablePais();
        },
        complete: function () {
            console.log('DeletePais');
        }
    });

    return false;

}


function deleteLocalidad(id,pais) {

    var pais = $('#_country').val(pais);

    $.ajax({
        type: "POST",
        url: "DeleteLocalidad",
        data: { id: id },
        dataType: "json",
        success: function (data) {
            buildTableLocalidad(pais);
        },
        complete: function () {
            console.log('DeletePais');
        }
    });

    return false;

}

function abrirLocalidadModal(pais) {
    $('#_pais').val(pais);
    $('#lblPais').html(pais);
    $('#localidadModal').show();
}

function cerrarLocalidadModal() {
    $('#_pais').val('');
    $('#lblPais').html('');
    $('#localidadModal').hide();
}

function nuevaLocalidad() {

    var pais = $('#_pais').val();
    var localidad = $('#_localidad').val();

    if (pais === '' || localidad === '') {
        alert('Ingrese localidad');
        return false;
    }

    $.ajax({
        type: "POST",
        url: "InsertLocalidad",
        data: { pais: pais, localidad: localidad},
        dataType: "json",
        success: function (data) {
            alert(data.descripcion);
            cerrarLocalidadModal();
            setTimeout(buildTableLocalidad, 2000, pais);
        },
        complete: function () {

            console.log('InsertLocalidad');
            $('#_localidad').val('');
        }
    });

    return false;

}


function buildTableLocalidad(pais) {

    $('#_country').val(pais);

    $.ajax({
        type: "POST",
        url: "GetLocalidades",
        data: {pais: pais},
        dataType: "json",
        success: function (data) {
            console.log(data);
            $("#tablaPortada thead tr").remove();
            $('#tablaPortada tbody tr').remove();

            let title = `<tr>

                            <th> Localidades </th>
                            <th> </th>
                            <th> </th>
                        </tr>`;

            $("#tablaPortada thead").append(title);

            $.each(data, function (index, item) {
                let tr = `<tr> 
                        <td> ${item.ide} </td>
                        <td> <input type='submit' class='btn btn-danger' onClick = "deleteLocalidad('${item.id}, ${item.ide}')" value='Eliminar'/> </td>
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
