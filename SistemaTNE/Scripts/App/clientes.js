$(document).ready(function () {

    $('#NovoCliente').on('click', function () {

        CarregarPartialView('NovoEditar', 'Cliente');
    });

    $('#ListaClientes').on('click', function () {

        CarregarPartialView('Lista', 'Cliente', function () {

            $('#tblClientes').bootstrapTable({
                idField: 'ClienteId',
                columns: [{
                    radio: true
                }, {
                    field: 'ClienteId',
                    visible: false
                }, {
                    field: 'Nome',
                    title: 'Nome'
                }, {
                    field: 'DataNascimento',
                    title: 'Data de nascimento'
                }, {
                    field: 'Tipo',
                    title: 'Tipo de pessoa'
                }, {
                    field: 'RamoAtividade',
                    title: 'Ramo de atividade'
                }, {
                    field: 'SituacaoAtual',
                    title: 'Situação atual'
                }, {
                    field: 'Endereco',
                    title: 'Endereço'
                }, {
                    field: 'ModeloVeiculo',
                    title: 'Modelo de veiculo'
                }, {
                    field: 'Placa',
                    title: 'Placa'
                }, {
                    field: 'ServicosUtilizados',
                    title: 'Serviços utilizados'
                }],
                data: [{
                    ClienteId: 1,
                    Nome: 'Jose Maria dos Santos',
                    DataNascimento: '02/04/1985',
                    Tipo: 'Pessoa Fisíca',
                    RamoAtividade: 'Vendas',
                    SituacaoAtual: 'Ativo',
                    Endereco: 'Rua Donquedro Neves, nº 1500, Centro, Governador Valadares - MG',
                    ModeloVeiculo: 'Celta',
                    Placa: 'HHA-1245',
                    ServicosUtilizados: 'Lavagem, Calibragem'
                }, {
                    ClienteId: 1,
                    Nome: 'Jose Maria dos Santos',
                    DataNascimento: '02/04/1985',
                    Tipo: 'Pessoa Fisíca',
                    RamoAtividade: 'Vendas',
                    SituacaoAtual: 'Ativo',
                    Endereco: 'Rua Donquedro Neves, nº 1500, Centro, Governador Valadares - MG',
                    ModeloVeiculo: 'Celta',
                    Placa: 'HHA-1245',
                    ServicosUtilizados: 'Lavagem, Calibragem'
                }, {
                    ClienteId: 1,
                    Nome: 'Jose Maria dos Santos',
                    DataNascimento: '02/04/1985',
                    Tipo: 'Pessoa Fisíca',
                    RamoAtividade: 'Vendas',
                    SituacaoAtual: 'Ativo',
                    Endereco: 'Rua Donquedro Neves, nº 1500, Centro, Governador Valadares - MG',
                    ModeloVeiculo: 'Celta',
                    Placa: 'HHA-1245',
                    ServicosUtilizados: 'Lavagem, Calibragem'
                }, {
                    ClienteId: 1,
                    Nome: 'Jose Maria dos Santos',
                    DataNascimento: '02/04/1985',
                    RamoAtividade: 'Vendas',
                    Tipo: 'Pessoa Fisíca',
                    SituacaoAtual: 'Ativo',
                    Endereco: 'Rua Donquedro Neves, nº 1500, Centro, Governador Valadares - MG',
                    ModeloVeiculo: 'Celta',
                    Placa: 'HHA-1245',
                    ServicosUtilizados: 'Lavagem, Calibragem'
                }]
            });
        });
    });

    $('ConsultaOlap').on('click', function () {

        CarregarPartialView('Consulta', 'OLAP');
    });
});