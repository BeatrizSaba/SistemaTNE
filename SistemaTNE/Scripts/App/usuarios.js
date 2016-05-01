$(document).ready(function () {

    $("#NovoUsuario").on('click', function () {

        AtivarPartialView('tabNovoUsuario','Novo', 'Usuarios', function () {

                $('#btnSalvarUsuario').on('click', function () {
                    AtivarSpin();
                });
        });
    });

    $('#ListaUsuarios').on('click', function () {

        AtivarPartialView('divListaUsarios', 'Lista', 'Usuarios', function () {
            CriarTabelaUsuarios();
        });
    });

    $('#ImportarDados').on('click', function () {

        AtivarPartialView('tabImportarDados','ImportarDados', 'Ferramentas');
    });
});


function CriarTabelaUsuarios() {

    $('#tblUsuarios').bootstrapTable({
        idField: 'UsuarioId',
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

     DesabilitarTodasValidacoes();

    if (data.Status === "OK") {

        LimparCampos('tabNovoUsuario');

        AtivarPartialView('divListaUsarios', 'Lista', 'Usuarios', function () {
            CriarTabelaUsuarios();
        }, function () {
            AtivarAlert('success', 'Usuário cadastrado.', 'listaUsuariosAlerta');
        });
       
    }
    else if (data.Status === "VALIDACAO") {
        data.Mensagem.forEach(function (val) {
            HabilitarValidacao(val.Campo, val.Erro);
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