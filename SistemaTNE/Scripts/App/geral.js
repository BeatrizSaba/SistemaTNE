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