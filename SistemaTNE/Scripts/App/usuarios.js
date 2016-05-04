$(document).ready(function () {

    $("#NovoUsuario").on('click', function () {

        AtivarPartialView('tabNovoUsuario','Novo', 'Usuarios', function () {

                $('#btnSalvarUsuario').on('click', function () {
                    AtivarSpin();
                });
        });
    });

    $('#ListaUsuarios').on('click', function () {

        AtivarPartialViewListaUsuarios();
    });

    $('#ImportarDados').on('click', function () {

        AtivarPartialView('tabImportarDados','ImportarDados', 'Ferramentas');
    });
});


function CriarTabelaUsuarios() {

    $('#tblUsuarios').bootstrapTable({
        uniqueId: 'UsuarioID',
        columns: [{
            radio: true,
        }, {
            field: 'UsuarioID',
            title: 'ID',
            visible: false
        }, {
            field: 'Nome',
            title: 'Nome'
        }, {
            field: 'Login',
            title: 'Login'
        }, {
            field: 'Papel',
            title: 'Tipo'
        }, {
            field: 'Bloqueado',
            title: 'Bloqueado'
        }],
        showRefresh: true,
        //sidePagination: 'server',
        pagination: true,
        striped: true,
        method: "post",
        url: "../Usuarios/Pesquisar",
        //toolbar: '#toolbarAbaAvaliados-Gerenciar',
        search: true,
        showToggle: true,
        showExport: true,
        pageSize: 10,
        showColumns: true
    });
}


function PostUsuarioOnSuccess(data, status, xhr) {

    DesabilitarTodasValidacoes('tabNovoUsuario');

    if (data.Status === "OK") {

        LimparCampos('tabNovoUsuario');

        AtivarPartialViewListaUsuarios(function () {
            AtivarAlert('success', 'Usuário cadastrado.', 'listaUsuariosAlerta');
        });
       
    }
    else if (data.Status === "VALIDACAO") {
        data.Mensagem.forEach(function (val) {
            HabilitarValidacao('tabNovoUsuario', val.Campo, val.Erro);
        });
    } else if (data.Status === "ERRO") {
        AlertaErroInterno(data.Mensagem);
    }
}

function PostUsuarioOnErro() {
    AlertaErroInterno();
}

function PostUsuarioOnComplete() {
    DesativarSpin();
}

function AjusteBarraAcoes(container)
{
    var toolbar = $('.fixed-table-toolbar', '#' + container);
    var btngroup = $('.btn-actions.btn-group', '#' + container);

    $(toolbar).prepend(btngroup);
}

function AtivarPartialViewListaUsuarios(onShow) {

    AtivarPartialView('divListaUsarios', 'Lista', 'Usuarios', function () {
        CriarTabelaUsuarios();
        AjusteBarraAcoes('divListaUsarios');

        $("#AlterarSenhaUsuario").on('click', function () {

            DesativarAlert('listaUsuariosAlerta');

            var id = getSelectedUsuarioID();

            if (id === null) {
                AtivarAlert('warning', 'Selecione um usuário', 'listaUsuariosAlerta');
            }
            else {

                AtivarSpin();

                $.ajax({
                    url: '../Usuarios/AlterarSenha',
                    method: 'GET',
                    success: function (partialView) {
                        ModelShow({
                            title: 'Alterar senha',
                            bodyModel: partialView,
                            onOK: function () {

                                //AtivarSpin();
                                DesabilitarTodasValidacoes('tabNovoUsuario');

                                var id = getSelectedUsuarioID();

                                $.ajax({
                                    url: '../Usuarios/AlterarSenha/' + id,
                                    method: 'POST',
                                    data: $('#frmAlterarSenha').serialize(),
                                    success: function (data, status ,xhr) {

                                        if (data.Status === 'VALIDACAO') {

                                            data.Mensagem.forEach(function (val) {
                                                HabilitarValidacao('tabNovoUsuario', val.Campo, val.Erro);
                                            });

                                        } else if (data.Status === 'OK') {

                                            ModelHide();
                                            AtivarAlert('success', data.Mensagem, 'listaUsuariosAlerta');

                                        } else if (data.Status === 'ERRO') {
                                            ModelHide();
                                            AlertaErroInterno(data.Mensagem);
                                        }

                                    },
                                    error: function () {
                                        AlertaErroInterno();
                                    },
                                    complete: function () {
                                        // DesativarSpin();
                                    }
                                });
                            }
                        });
                    },
                    error: function () {
                        AlertaErroInterno();
                    },
                    complete: function () {
                        DesativarSpin();
                    }
                });          
            }
        });

        $("#BloquearUsuario").on('click', function () {

            DesativarAlert('listaUsuariosAlerta');

            var id = getSelectedUsuarioID();

            if (id === null) {
                AtivarAlert('warning', 'Selecione um usuário', 'listaUsuariosAlerta');
            }
            else {
                AtivarSpin();

                $.ajax({
                    url: '../Usuarios/MudarBloqueio/' + id,
                    method: 'POST',
                    success: function (data) {
                        if (data.Status === 'OK') {

                            /*
                            var id =  getSelectedUsuarioID();
                            var data = $('#tblUsuarios').bootstrapTable('getRowByUniqueId', id);
                            var bloq = data.Mensagem.indexOf('bloqueado') >= 0;
                            data.Bloqueado = bloq ? 'Sim' : 'Não';
                            $('#tblUsuarios').bootstrapTable('updateByUniqueId', id, data);
                            */
                            AtivarAlert('success', data.Mensagem, 'listaUsuariosAlerta');
                        } else if (data.Status === 'ERRO') {
                            AlertaErroInterno(data.Mensagem);
                        }
                    },
                    error: function () {
                        AlertaErroInterno();
                    },
                    complete: function () {
                        DesativarSpin();
                    }
                });
            }
        });

    }, onShow);
}

function getSelectedUsuarioID()
{
    var selected = $('#tblUsuarios').bootstrapTable('getSelections');

    if (selected.length != 0) {
        return selected[0].UsuarioID;
    }
    else
        return null;
}