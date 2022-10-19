var oTabla = $('#tblGuest').DataTable();
$(document).ready(function () {
    $('#tblGuest tbody').on('click', 'tr', function () {
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
    $("#txtNombreHuespede").val(DatosFila[1]);
    $("#txtSexo").val(DatosFila[2]);
    $("#txtTipo").val(DatosFila[2]);
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
    var NombreHuespede = $("#txtNombreHuespede").val();
    var DocumentoPersona = $("#txtDocumentoPersona").val();
    var Sexo = $("#cboSexoHuespede").val();
    var TipoPersona = $("#cboTipoPersona").val();

    if (Comando == "Confirmar") {
        NombrePersona = "";
        NombreHuesped = "";
        DocumentoPersona = "";
    }
    var DatosReserva = {
        IdReserva: IdReserva,
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
        success: function (Respuesta) {
            $("#dvMensaje").addClass("alert alert-success");
            $("#dvMensaje").html(Respuesta);
            LlenarGridGuest();
        },
        error: function (RespuestaError) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(RespuestaError);
        }
    });
}
