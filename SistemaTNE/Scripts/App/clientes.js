﻿$(document).ready(function () {

    $('#NovoCliente').on('click', function () {

        AtivarPartialView('tabNovoEditarCliente', 'Novo', 'Clientes', function () {

            ConfigurarDadosInvisiveisCliente();

            $('#btnSalvarCliente').on('click', function (e) {
         
                getSelectValue('RamoAtividadeID', 'listRamosAtividade');
                getMultSelectValues('Postos', 'listPostos');
                getMultSelectValues('Marcas', 'listMarcas');
                getMultSelectValues('Servicos', 'listServicos');

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

    setDefaultSelect('RamoAtividadeID', 'listRamosAtividade');
    setDefaultMultSelect('Postos', 'listPostos');
    setDefaultMultSelect('Marcas', 'listMarcas');
    setDefaultMultSelect('Servicos', 'listServicos');
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

        var value = $('#' + select).val()[0];

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

    DesabilitarTodasValidacoes();
    DesativarAlert('listaClientesAlerta');

    if (data.Status === 'OK') {

        AtivarPartialViewListaClientes(function () {
            AtivarAlert('success', data.Mensagem, 'listaClientesAlerta');
        });
  
    } else if (data.Status === 'VALIDACAO') {
        data.Mensagem.forEach(function (val) {
            HabilitarValidacao(val.Campo, val.Erro);
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