$(document).ready(function () {

    $("#NovoUsuario").on('click', function () {

        CarregarPartialView('Novo', 'Usuarios');
    });

    $('#ListaUsuarios').on('click', function () {

        CarregarPartialView('Lista', 'Usuarios', function () {

            $('#tblUsuarios').bootstrapTable({
                idField: 'UsuarioId',
                columns: [{
                    radio: true,
                }, {
                    field: 'UsuarioId',
                    title: 'ID',
                    visible: false
                }, {
                    field: 'Nome',
                    title: 'Nome'
                }, {
                    field: 'Tipo',
                    title: 'Tipo'
                }],
                data: [{
                    UsuarioId: 10,
                    Nome: 'Admin',
                   Tipo: 'Administrador'
                }, {
                    UsuarioId: 32,
                    Nome: 'Cristiane',
                    Tipo: 'Gestor'
                }, {
                    UsuarioId: 38,
                    Nome: 'Ana',
                    Tipo: 'Gestor'
                }, {
                    UsuarioId: 94,
                    Nome: 'João',
                    Tipo: 'Frentista'
                }]
            });
        });
    });

    $('#ImportarDados').on('click', function () {

        CarregarPartialView('ImportarDados', 'Ferramentas');
    });
});