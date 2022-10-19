var oTabla = $('#tblHuespedes').DataTable();
$(document).ready(function () {
    $('#tblHuespedes tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        } else {
            oTabla.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }
    });

    $("#btnConfirmar").click(function () {
        ProcesarComandos("Confirmar");
    });
    $("#btnRegistrarHuesped").click(function () {
        ProcesarComandos("RegistrarHuesped");
    });
    LlenarComboSexo();
    LlenarComboTipoDePersonas();
    LlenarGridGuest();
    $('#tblGuest tbody').on('click', 'tr', function () {
        EditarFila(oTabla.row(this).data());
    });
});
function EditarFila(DatosFila) {
    $("#txtIdReserva").val(DatosFila[0]);
    $("#txtNombrePersona").val(DatosFila[1]);
    $("#txtFechaInicio").val(DatosFila[2]);
    $("#txtFechaFin").val(DatosFila[3]);
    $("#txtHabitacion").val(DatosFila[4]);
    $("#txtValor").val(DatosFila[5]);
}

function LlenarComboSexo() {
    LlenarComboControlador("../Comunes/ControladorCombos.ashx", "SEXO", null, "#cboSexoHuespede");
}

function LlenarComboTipoDePersonas() {
    LlenarComboControlador("../Comunes/ControladorCombos.ashx", "TIPODEPERSONA", null, "#cboTipoPersona");
}
function LlenarGridGuest() {
    LlenarGridControlador("../Comunes/ControladorGrids.ashx", "TABLAGUEST", null, "#tblGuest");
}

function ProcesarComandos(Comando) {
    var IdReserva = $("#txtIdReserva").val();
    var NombrePersona = $("#txtNombrePersona").val();
    var NombreHuespede = $("#txtNombreHuespede").val();
    var DocumentoPersona = $("#txtDocumentoPersona").val();
    var Sexo = $("#cboSexoHuespede").val();
    var TipoPersona = $("#cboTipoPersona").val();

    if (Comando == "Confirmar" || Comando == "RegistrarHuesped") {
        NombrePersona = "";
        NombreHuesped = "";
        DocumentoPersona = "";
    }
    var DatosReserva = {
        IdReserva: IdReserva,
        NombrePersona: NombrePersona,
        NombreHuespede: NombreHuespede,
        DocumentoPersona: DocumentoPersona,
        Sexo: Sexo,
        TipoPersona: TipoPersona,
        Comando: Comando
    }
    $.ajax({
        type: "POST",
        url: "../Controladores/ReservaControlador.ashx",
        contentType: "json",
        data: JSON.stringify(DatosReserva),
        success: function (RespuestaProducto) {
            if (Comando != "Confirmar") {
                //Hay que procesar la respuesta para identificar si hay un error
                $("#dvMensaje").addClass("alert alert-success");
                $("#dvMensaje").html(RespuestaProducto);
                LlenarGridReserva();
            }
            else {
                alert(RespuestaProducto.NombrePersona);
                $("#txtNombrePersona").val(RespuestaProducto.NombrePersona);
                $("#txtDocumentoPersona").val(RespuestaProducto.DocumentoPersona);
            }
        },
        error: function (RespuestaError) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(RespuestaError);
        }
    });
}
