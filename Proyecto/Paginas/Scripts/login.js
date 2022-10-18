$(document).ready(function () {

    $("#btnLogin").click(function () {
        Validar();
    });

});

function Validar() {
    var usuario = $("#txtUser").val();
    var contrasenia = $("#txtPassword").val();

    var login = {
        usuario: usuario,
        contrasenia: contrasenia,
    }
    $.ajax({
        //Función Ajax
        type: "POST",
        url: "../Controladores/loginControlador.ashx",
        contentType: "json",
        data: JSON.stringify(login),
        success: function (Respuestalogin) {
            //Hay que procesar la respuesta para identificar si hay un error
            if (Respuestalogin == '1') {
                window.location.replace('Reserva.html')
            }
            $("#dvMensaje").addClass("alert alert-success");
            $("#dvMensaje").html(Respuestalogin);
        },
        error: function (RespuestaError) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(RespuestaError);
        }
    }); 
}

