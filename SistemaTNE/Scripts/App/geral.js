/*
*/

function AtivarSpin() {
    $('#' + PARTIAL_VIEW_CONTAINER).waitMe({
        effect: 'roundBounce',
        text: 'Aguarde por favor...',
        bg: 'rgba(0,0,0,0.7)',
        color: '#FFF',
        maxSize: '',
        source: 'img.svg',
        onClose: function () { }
    });
}


function DesativarSpin() {
    $('#' + PARTIAL_VIEW_CONTAINER).waitMe('hide');
}


function CarregarPartialView(action, controller, onSuccess, onError, container)
{
    AtivarSpin();

    if ((container === null) || (container === undefined))
        container = PARTIAL_VIEW_CONTAINER;

    $.ajax({
        url: "../" + controller + "/" + action,
        success: function (partialView, status, xhr) {

            if (VaParaAutenticacaoSeSignOut(partialView))
                return;

            $('#' + container).append(partialView);

            InicializarEstilos(container);

            if ((onSuccess != null) && (onSuccess != undefined))
                onSuccess(partialView, status, xhr);
        },
        erro: onError,
        complete: function () {
            DesativarSpin();
        }
    });
}

function InicializarEstilos(raiz)
{
    $('#' + raiz + ' select.select2-single,.select2-mult').select2();
}

function VaParaAutenticacaoSeSignOut(html)
{
    if (html.indexOf('pagina_autenticacao') >= 0) {
        window.location.assign("../Home/Autenticacao");
        return true;
    }

    return false;
}

/*
 <input class="input-validation-error" name="Senha" type="text" value="">
 <span class="text-danger field-validation-error" data-valmsg-for="Senha" data-valmsg-replace="true">
    <span for="Senha" class="">O campo Senha é obrigatório.</span>
  </span>

*/

function HabilitarValidacao(campoId, erroMsg) {

    $('span[data-valmsg-for="' + campoId + '"]').append(
       '<span for="' + campoId + '" class="">' + erroMsg + '</span><br/>'
    );
}

function DesabilitarValidacao(campoId) {
    $("span[data-valmsg-for='" + campoId + "']").html("");
}

function DesabilitarTodasValidacoes() {
    $("span[data-valmsg-for]").html("");
}

function AlertaSucesso(msg)
{
    BootstrapDialog.alert({
        title: 'Sucesso',
        message: msg,
        type: BootstrapDialog.TYPE_SUCCESS, // <-- Default value is BootstrapDialog.TYPE_PRIMARY
        closable: true, // <-- Default value is false
        draggable: true // <-- Default value is false
    });
}


function AlertaErroInterno(msg) {

    if ((msg === null) || (msg === undefined))
        msg = 'Desculpe. Ocorreu um erro inesperado. Favor entrar em contato com o suporte.';

    BootstrapDialog.alert({
        title: 'Erro',
        message: msg,
        type: BootstrapDialog.TYPE_DANGER, // <-- Default value is BootstrapDialog.TYPE_PRIMARY
        closable: true, // <-- Default value is false
        draggable: true // <-- Default value is false
    });
}

function AtivarAlert(tipo, msg, divContainer) {
    try {
        var _alert;
        switch (tipo) {
            case 'danger':
                _alert = '<div class="alert-dismissible alert alert-' + tipo + '"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button><h4><i class="icon fa fa-ban"></i> Atenção!</h4>' + msg + '</div>';
                break;
            case 'info':
                _alert = '<div class="alert-dismissible alert alert-' + tipo + '"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button><h4><i class="icon fa fa-info"></i> Atenção!</h4>' + msg + '</div>';
                break;
            case 'success':
                _alert = '<div class="alert-dismissible alert alert-' + tipo + '"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button><h4><i class="icon fa fa-check"></i> Atenção!</h4>' + msg + '</div>';
                break;
            case 'warning':
                _alert = '<div class="alert-dismissible alert alert-' + tipo + '"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button><h4><i class="icon fa fa-warning"></i> Atenção!</h4>' + msg + '</div>';
                break;
        }
        if ($("#" + divContainer).hasClass("text-center") != true) {
            $('#' + divContainer).addClass('text-center');
        }
        $('#' + divContainer + '').empty().html(_alert);
    } catch (e) {
        console.log('GERAL - MÉTODO AtivarAlert(tipo: ' + tipo + ', msg: ' + msg + ', divContainer: ' + divContainer + ') - ' + e.message);
    }
}


function AtivarPartialView(tab, action, controller, onLoad, onShow) {
    if ($('#' + tab).length === 0) {
        CarregarPartialView(action, controller, function () {

            if ((onLoad != null) && (onLoad != undefined))
                onLoad();

            AtivarTab(tab);

            if ((onShow != null) && (onShow != undefined))
                onShow();
        });
    }
    else {
        AtivarTab(tab);

        if ((onShow != null) && (onShow != undefined))
            onShow();
    }
}

function AtivarTab(tab)
{
    if (!TabAtiva(tab)) {
        $('.tab-content > .active').removeClass('in active');
        $('.tab-content > #' + tab).addClass('in active');
    }
}

function TabAtiva(tab)
{
    return $('.tab-content > #' + tab).hasClass('active');
}

function LimparCampos(container)
{
    $(':input', '#' + container).not(':button, :submit, :reset, :hidden, select').val('');
    $('select option', '#' + container)[0].selected = true;
}