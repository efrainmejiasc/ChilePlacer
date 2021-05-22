$(document).ready(function () {
    console.log("ready!");
    //classes();
    getIdentityUserAdm();
});

function classes() {

    $('#contenido').css(
        {
            "margin-left": "3000px",
            "background-color": "silver",
            "margin-top": "5%",
        });

    $('contenido').html('HOLA MUNDO');

   console.log('classes');
    
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

function abrirAdm() {
    $('#_adm').show();
}

function cerrarAdm() {
    $('#_adm').hide();
}

function validarPassword() {

    let valor = $('#password1').val();
    var nvalor = valor.toString();
    const soloNum = /^[0-9a]+$/;
    const soloLet = /^[aA-zZ]+$/;

    if (nvalor.length > 0) {

        if (soloNum.test(nvalor) || soloLet.test(nvalor)) {
            $('#password1').val('');
            alert('La contraseña debe contener numeros y letras');
            return false;
        }

        if (nvalor.length < 8) {
            $('#password1').val('');
            alert('La contraseña debe contener minimo ocho(8) caracteres');
            return false;
        }
    }

    return false;
}

function validarEmail() {
    var email = $('#email').val();
    const regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;

    if (!regex.test(email)) {
        $('#email').val('');
        alert('El email no es una direccion valida');
        return false;
    }
}

function nuevoAdm() {
    var email = $('#email').val();
    var password1 = $('#password1').val();
    var password2 = $('#password2').val();
    var robot = $('#robot').val();
    console.log(robot);

    if (email === '' || password1 === '' || password2 === '' || robot !== 'on') {
        alert('Todos los campos son requeridos');
        return false;
    }
    else if (password1 !== password2) {
        alert('Las contraseñas deben ser identicas');
        return false;
    }

    $.ajax({
        type: "POST",
        url: "RegistroAdm",
        data: {email: email, password: password1},
        dataType: "json",
        success: function (data) {
            alert(data.descripcion);
            window.location.href = 'Index';
        },
        complete: function () {
            console.log('NuevoAdministrador');
        }
    });

    return false;
}



function abrirAdmMod() {
    $('#_admMod').show();
}

function cerrarAdmMod() {
    $('#_admMod').hide();
}


function validarEmail2() {
    var email2 = $('#email2').val();
    const regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;

    if (!regex.test(email2)) {
        $('#email2').val('');
        alert('El email no es una direccion valida');
        return false;
    }
}

function validarPassword2() {

    let valor = $('#password3').val();
    var nvalor = valor.toString();
    const soloNum = /^[0-9a]+$/;
    const soloLet = /^[aA-zZ]+$/;

    if (nvalor.length > 0) {

        if (soloNum.test(nvalor) || soloLet.test(nvalor)) {
            $('#password3').val('');
            alert('La contraseña debe contener numeros y letras');
            return false;
        }

        if (nvalor.length < 8) {
            $('#password3').val('');
            alert('La contraseña debe contener minimo ocho(8) caracteres');
            return false;
        }
    }

    return false;
}

function modificarAdm() {
    var email = $('#email2').val();
    var password1 = $('#password3').val();
    var password2 = $('#password4').val();
    var robot = $('#robot2').val();
    console.log(robot);

    if (email === '' || password1 === '' || password2 === '' || robot !== 'on') {
        alert('Todos los campos son requeridos');
        return false;
    }
    else if (password1 !== password2) {
        alert('Las contraseñas deben ser identicas');
        return false;
    }

    $.ajax({
        type: "POST",
        url: "UpdateAdmPassword",
        data: { email: email, password: password1 },
        dataType: "json",
        success: function (data) {
            alert(data.descripcion);
            window.location.href = 'Index';
        },
        complete: function () {
            console.log('ModificarAdm');
        }
    });

    return false;
}


