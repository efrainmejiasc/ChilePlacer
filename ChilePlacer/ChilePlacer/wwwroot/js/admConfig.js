$(document).ready(function () {
    console.log("ready!");
    //getIdentityUserAdm();

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


function mostrar() {
    document.getElementById("sidebar").style.width = "300px";
    document.getElementById("contenido").style.marginLeft = "300px";
    document.getElementById("abrir").style.display = "none";
    document.getElementById("cerrar").style.display = "inline";
}

function ocultar() {
    document.getElementById("sidebar").style.width = "0";
    document.getElementById("contenido").style.marginLeft = "0";
    document.getElementById("abrir").style.display = "inline";
    document.getElementById("cerrar").style.display = "none";
}