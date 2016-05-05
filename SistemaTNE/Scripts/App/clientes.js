$(document).ready(function () {

    $('#NovoCliente').on('click', function () {

        AtivarPartialView('tabNovoEditarCliente', 'Novo', 'Clientes', function () {

            ConfigurarDadosInvisiveisCliente();

            ConfigurarTabelaClienteContatos();

            $('#ListaRamosAtividade').val(0).trigger('change');

            $('#btnSalvarCliente').on('click', function (e) {
         
                getSelectValue('RamoAtividadeID', 'ListaRamosAtividade');
                getMultSelectValues('Postos', 'ListaPostos');
                getMultSelectValues('Marcas', 'ListaMarcas');
                getMultSelectValues('Servicos', 'ListaServicos');
                getContatos();

                AtivarSpin();
            });


        }, function () {
            var active = $('#tabNovoEditarCliente li.active a:first-child');
            var tab = $(active).attr('href');
            $('#tabNovoEditarCliente ' + tab).addClass('in active');
        });
    });

    $('#ListaClientes').on('click', function () {

        AtivarPartialViewListaClientes();

    });

    $('ConsultaOlap').on('click', function () {

        AtivarPartialView('tabOLAP', 'Consulta', 'OLAP');
    });
});

function AtivarPartialViewListaClientes(onShow) {

    AtivarPartialView('tabListaClientes', 'Lista', 'Clientes', function () {

        $('#tblClientes').bootstrapTable({
            uniqueId: 'ClienteID',
            columns: [{
                radio: true
            }, {
                field: 'ClienteID',
                title: 'ID',
                visible: false
            }, {
                field: 'Nome',
                title: 'Nome'
            }, {
                field: 'DataNascimento',
                title: 'Data de nascimento'
            }, {
                field: 'TipoPessoa',
                title: 'Tipo de pessoa'
            }, {
                field: 'RamoAtividade',
                title: 'Ramo de atividade'
            }, {
                field: 'Estado',
                title: 'Situação atual'
            }, {
                field: 'ModeloVeiculo',
                title: 'Modelo de veiculo'
            }, {
                field: 'PlacaVeiculo',
                title: 'Placa'
            }, {
                field: 'FormaPagamentoUsada',
                title: 'Forma pagamento'
            }, {
                field: 'FrequenciaVisitaPosto',
                title: 'Frequência que vai ao posto'
            }, {
                field: 'Servicos',
                title: 'Serviços utilizados'
            }, {
                field: 'Marcas',
                title: 'Marcas favotiras'
            }, {
                field: 'Postos',
                title: 'Postos em que abastece'
            }, {
                field: 'Residencia',
                title: 'Número/Complemento'
            }, {
                field: 'CEP',
                title: 'CEP'
            }, {
                field: 'Logradouro',
                title: 'Logradouro'
            }, {
                field: 'Bairro',
                title: 'Bairro'
            }, {
                field: 'Cidade',
                title: 'Cidade'
            }, {
                field: 'UF',
                title: 'UF'
            }, {
                field: 'Contatos',
                title: 'Contato'
            }],
            showRefresh: true,
            //sidePagination: 'server',
            pagination: true,
            striped: true,
            method: "post",
            url: "../Clientes/Pesquisar",
            //toolbar: '#toolbarAbaAvaliados-Gerenciar',
            search: true,
            showToggle: true,
            showExport: true,
            pageSize: 10,
            showColumns: true
        });

        AjusteBarraAcoes('tabListaClientes');
    }, onShow);
}

function ConfigurarDadosInvisiveisCliente() {

    setDefaultSelect('RamoAtividadeID', 'ListaRamosAtividade');
    setDefaultMultSelect('Postos', 'ListaPostos');
    setDefaultMultSelect('Marcas', 'ListaMarcas');
    setDefaultMultSelect('Servicos', 'ListaServicos');
}

function ConfigurarTabelaClienteContatos(contatos)
{
    $('#btnAddContato').on('click', function (e) {
        e.preventDefault();

        AtivarSpin();

        $.ajax({
            url: '../Clientes/Contato',
            success: function (partialView) {
                window.modelContato
                ModelShow({
                    bodyModel: partialView,
                    title: 'Contato',
                    onOK: function () {
                        AtivarSpin();
                        $('#formContato').submit();
                    },
                    onCancel: function (e) {
                        e.preventDefault();
                    }
                });
            },
            erro: function () {
                AlertaErroInterno();
            },
            complete: function () {
                DesativarSpin();
            }
        });
    });

    $('#btnRemoveContato').on('click', function (e) {
        e.preventDefault();
    });

    $('#tblClienteContatos').bootstrapTable({
        columns: [{
            radio: true
        }, {
            field: 'Nome',
            title: 'Nome'
        }, {
            field: 'Telefone',
            title: 'Telefone'
        }],      
        pagination: true,
        striped: true,
        //toolbar: '#toolbarAbaAvaliados-Gerenciar',
        search: true,
        showToggle: true,
        pageSize: 10,
        showColumns: false
    });

    $('#menu3 .search input').on('keydown', function (e) {
        if (e.keyCode == 13) {
            e.preventDefault();
            return false;
        }
    });

    AjusteBarraAcoes('menu3');
}

function PostContatoSuccess(data)
{
    DesabilitarTodasValidacoes('formContato');

    if (data.Status === "OK")
    {
        $('#btnModalCancel').click();

        var _nome = $("#formContato [name='Nome']").val();
        var _telefone = $("#formContato [name='Telefone']").val();

        $('#tblClienteContatos').bootstrapTable('append', [{ Nome: _nome, Telefone: _telefone }]);
    }
    else if (data.Status === "VALIDACAO")
    {
        data.Mensagem.forEach(function (val) {
            HabilitarValidacao('formContato', val.Campo, val.Erro);
        });
    }
}

function PostContatoError()
{
    AlertaErroInterno();
}

function PostContatoComplete()
{
    DesativarSpin();
}

function getContatos()
{
    var contatos = $('#tblClienteContatos').bootstrapTable('getData', true);
    var json = JSON.stringify(contatos);
    $('#tabNovoEditarCliente [name="Contatos"]').val(json);
}


//inputValues deve conter uma lista de valores separador por virgula.
//Exemplos:   "1,2,6,29"      "Maça,Uva,Abacaxi" 
function setDefaultMultSelect(inputValues, multSelect) {
    var strValues = $('#' + inputValues).val();

    if (strValues != null) {
        var arrayValues = strValues.split(',');

        $('#' + multSelect).val(arrayValues).trigger('change');
    }
}

function setDefaultSelect(inputValue, select) {
    var value = $('#' + inputValue).val();

    if (value != null) {
        $('#' + select).val(value).trigger('change');
    }
}

function getSelectValue(inputSorce, select) {

    var arrayValues = $('#' + select).val();
    
    if ((arrayValues != null) && (arrayValues.length != 0)) {

        var value = $('#' + select).val();

        if (value != null)
            $('#' + inputSorce).val(value);
    }
}

function getMultSelectValues(inputSorce, multSelect) {
    var arrayValues = $('#' + multSelect).val();

    if ((arrayValues != null) && (arrayValues.length != 0)) {

        var strValues = "";
        $.each(arrayValues, function (index, value) {

            if (index != 0)
                strValues += ',';

            strValues += value;
        });
        $('#' + inputSorce).val(strValues);
    }
}

function PostClienteSuccess(data, status, xhr) {

    DesabilitarTodasValidacoes('tabNovoEditarCliente');
    DesativarAlert('listaClientesAlerta');

    if (data.Status === 'OK') {

        LimparCampos('tabNovoEditarCliente');
        $('#tblClienteContatos').bootstrapTable('removeAll');

        AtivarPartialViewListaClientes(function () {
            AtivarAlert('success', data.Mensagem, 'listaClientesAlerta');
        });
  
    } else if (data.Status === 'VALIDACAO') {
        data.Mensagem.forEach(function (val) {
            HabilitarValidacao('tabNovoEditarCliente', val.Campo, val.Erro);
        });
    } else if (data.Status === 'ERRO') {
        AlertaErroInterno(data.Mensagem);
    }
}

function PostClienteError() {
    AlertaErroInterno();
}

function PostClienteComplete() {
    DesativarSpin();
}