$(document).ready(function () {
    console.log("ready!");
  
});


function autentificar() {

    var email = $('#email').val();
    var password = $('#password').val();

    if (email === '' || password === '') {
        return false;
    }

    $.ajax({
        type: "POST",
        url: urlLoginAdm,
        data: { email: email, password: password },
        dataType: "json",
        success: function (data) {
            console.log(data.status);
            if (data.status === 'true')
                alert('Administrador autentificado correctamente');
            else
                alert('Datos ingresados incorrectos');
        },
        complete: function () {
            console.log('Autentificar');
        }
    });

    return false;
}

function abrirOlvido() {
    $('#olvido').show();
}

function cerrarOlvido() {
    $('#olvido').hide();
}

function validarEmail(email) {

    const regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;

    if (!regex.test(email)) {
        return false;
    }

    return true;
}

function enviarEmail() {

    var email = $('#email2').val();

    if (email === '') {
        $('#email2').val('');
        alert('El email no es una direccion valida');
        return false;
    }
    else if (!validarEmail(email)) {
        $('#email2').val('');
        alert('El email no es una direccion valida');
        return false;
    }

    $.ajax({
        type: "POST",
        url: urlOlvidoPassword,
        data: { email: email},
        dataType: "json",
        success: function (data) {
            console.log(data.status);
            if (data.status === 'true')
                alert('Enviamos un email  con una contraseña provicional');
            else
                alert('Datos ingresados incorrectos');

            cerrarOlvido();
        },
        complete: function () {
            console.log('OlvidoPassword');
        }
    });

    return false;

}



