/*
// INSIRA O HTML NA PÁGINA QUE IRÁ EXIBIR O MODEL

<!-- Modal -->
<div class="modal fade" id="bsModelCustom" tabindex="-1" role="dialog" aria-labelledby="bsModelCustomLabel">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title" id="bsModelCustomLabel"></h4>
            </div>
            <div class="modal-body">
                
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal" id="btnModalCancel">Fechar</button>
                <button type="button" class="btn btn-primary" data-dismiss="modal" id="btnModalOK">Salvar</button>
            </div>
        </div>
    </div>
</div>

*/

/*
            [Obrigatório]
            options: {
                title: string,          [Obrigatório]
                bodyModal: string,      [Obrigatório]
                onOK: function,
                onCancel: function,
                onShow: function,
                modelOptions: object,
                btnOKLabel: string,
                btnCancelLabel
            }
*/

function ModelShow(options) {

    $('#btnModalOK').off();
    $('#btnModalOK').on('click', function (e) {

        if ((options.onOK != undefined) && (options.onOK != null))
            options.onOK(e);
    });

    $('#btnModalCancel').off();
    $('#btnModalCancel').on('click', function (e) {

        if ((options.onCancel != undefined) && (options.onCancel != null))
            options.onCancel(e);
    });

    if ((options.onShow != undefined) && (options.onShow != null)) {
        $('#bsModelCustom').off('show.bs.modal');
        $('#bsModelCustom').on('show.bs.modal', options.onShow);
    }

    $('.modal-body').empty().html(options.bodyModel);

    if ((options.title != undefined) && (options.title != null))
        $('#bsModelCustomLabel').html(options.title);

    if ((options.btnOKLabel != null) && (options.btnOKLabel != undefined))
        $('#btnModalOK').val(options.btnOKLabel);

    if ((options.btnCancelLabel != null) && (options.btnCancelLabel != undefined))
        $('#btnModalCancel').val(options.btnCancelLabel);

    if ((options.modelOptions != undefined) && (options.modelOptions != null))
        $('#bsModelCustom').modal(options.modelOptions);
    else
        $('#bsModelCustom').modal();
}

function ModelHide()
{
    $('#bsModelCustom').modal('hide');
}