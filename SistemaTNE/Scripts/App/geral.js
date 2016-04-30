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

            $('#' + container).html(partialView);

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