var oTabla = $('#tblReserva').DataTable();
$(document).ready(function () {
    $('#tblReserva tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        } else {
            oTabla.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }
    });

    $("#btnReservar").click(function () {
        ProcesarComandos("Reservar");
    });
    $("#btnActualizar").click(function () {
        ProcesarComandos("Actualizar");
    });
    $("#btnEliminar").click(function () {
        ProcesarComandos("Eliminar");
    });
    LlenarComboPlanAlimentacion();
    LlenarComboHabitacion();
    LlenarGridReserva();
    $('#tblReserva tbody').on('click', 'tr', function () {
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

function LlenarComboPlanAlimentacion() {
    LlenarComboControlador("../Comunes/ControladorCombos.ashx", "PLANALIMENTACION", null, "#cboPlanAlim");
}

function LlenarComboHabitacion() {
    LlenarComboControlador("../Comunes/ControladorCombos.ashx", "HABITACION", null, "#cboHabitacion");
}
function LlenarGridReserva() {
    LlenarGridControlador("../Comunes/ControladorGrids.ashx", "TABLARESERVAS", null, "#tblReserva");
}

function ProcesarComandos(Comando) {
    var IdReserva = $("#txtIdReserva").val();
    var NombrePersona = $("#txtNombrePersona").val();
    var DocumentoPersona = $("#txtDocumentoPersona").val();
    var NumeroNinos = $("#txtNumNinos").val();
    var NumAdultos = $("#txtNumAdultos").val();
    var FechaIngreso = $("#txtFechaIngreso").val();
    var FechaSalida = $("#txtFechaSalida").val();
    var PlanAlimentancion = $("#cboPlanAlim").val();
    var Habitacion = $("#cboHabitacion").val();

    if (Comando == "Eliminar") {
        NombrePersona = "";
        DocumentoPersona = "";
    }
    var DatosReserva = {
        IdReserva: IdReserva,
        NombrePersona: NombrePersona,
        DocumentoPersona: DocumentoPersona,
        NumeroNinos: NumeroNinos,
        NumAdultos: NumAdultos,
        FechaIngreso: FechaIngreso,
        FechaSalida: FechaSalida,
        PlanAlimentancion: PlanAlimentancion,
        Habitacion: Habitacion,
        Comando: Comando
    }
    $.ajax({
        type: "POST",
        url: "../Controladores/ReservaControlador.ashx",
        contentType: "json",
        data: JSON.stringify(DatosReserva),
        success: function (RespuestaProducto) {
            $("#dvMensaje").addClass("alert alert-success");
            $("#dvMensaje").html(RespuestaProducto);
            LlenarGridReserva();
        },
        error: function (RespuestaError) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(RespuestaError);
        }
    });
}
