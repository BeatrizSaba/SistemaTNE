$(document).ready(function () {

    $("#NovoUsuario").on('click', function () {

        CarregarPartialView('Novo', 'Usuarios', function () {

            $('#btnSalvarUsuario').on('click', function () {
                AtivarSpin();
            });
        });
    });

    $('#ListaUsuarios').on('click', function () {

        CarregarPartialView('Lista', 'Usuarios', function () {

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
        });
    });

    $('#ImportarDados').on('click', function () {

        CarregarPartialView('ImportarDados', 'Ferramentas');
    });
});


function PostUsuarioOnSuccess(data, status, xhr) {

     DesabilitarTodasValidacoes();

    if (data.Status === "OK") {
        //retornarAbaAvaliados();
        // AtivarAlert('success', data.Mensagem, 'alertAbaAvaliados-Gerenciar');
        AlertaSucesso("Usuário cadastrado");
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