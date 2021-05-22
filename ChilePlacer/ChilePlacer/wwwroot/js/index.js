$(document).ready(function () {
    console.log("ready!");
  
});


function autentificar() {

    var email = $('email').val();
    var password = $('password').val();

    if (email === '' || password === '') {
        return false;
    }

    $.ajax({
        type: "POST",
        url: "Admin/LoginAdm",
        data: { email: email, password: password },
        dataType: "json",
        success: function (data) {
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



