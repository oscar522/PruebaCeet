$("#respuesta").hide(1500);
$(".requerido").text("*");
$(".requerido").addClass("red-text");

function Ejecutar(Idtable, Idcontroll, IdAction) {
    $("#centralModalLGInfoDemo").modal();
    $.ajax({
        url: '/' + Idcontroll + '/' + IdAction + '?IdTable=' + Idtable,
        success: function (result) {
           
            $('.modal-body').html(result);
        }
    });
}

function EjecutarModalSlim(Idtable, Idcontroll, IdAction, NameCatalogo) {
    $("#centralModalLGInfoDemoSlim").modal();
    $.ajax({
        url: '/' + Idcontroll + '/' + IdAction + '?IdTable=' + Idtable,
        success: function (result) {
            $('#HeaderSlim').html(NameCatalogo)
            $('#BodySlim').html(result);
        }
    });
}

function Ejecutar2(IdP, Idcontroll, IdAction) {
    $("#centralModalLGInfoDemo").modal();
    $.ajax({
        url: '/' + Idcontroll + '/' + IdAction + '?IdP=' + IdP,
        success: function (result) {

            $('.modal-body').html(result);
        }
    });
}

function Redir(Idcontroll, IdAction) {
   
    var formContainer = $('#car-form');
  
        $.ajax({
            //url: '/' + Idcontroll + '/' + IdAction,
            url: '/' + IdAction + '/' + Idcontroll +'',
            type: 'POST',
            cache: false,
            data: formContainer.serialize(),
            success: function (result) {
                console.log(result);
                //alert("1");
                if (result.length > 0 && result != "OK" ) {
                  //  alert("2");
                    $('#respuesta').addClass("alert alert-danger col-md-10 ");
                    $('#respuesta').text('Error inesperado');
                    for (i = 0; i < result.length; i++) {
                        $("[data-valmsg-for='" + result[i]['Cam'] + "']").text(result[i]['Msg']);
                    }
                } else {
                    //alert("bien");
                    $('#car-form').trigger("reset");
                    $('#respuesta').addClass("alert alert-info col-md-10 ");
                    $('#respuesta').text('Bien hecho');
                    $("#respuesta").show();
                }
            },
            error: function (jqXHR, textStatus, error) {
                //alert("4"+error);
                $('#respuesta').addClass("alert alert-danger col-md-10 ");
                $('#respuesta').text('Error inesperado ' + error);
            }
        });
   
}   
