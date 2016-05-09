(function ($) {

    //----- TAB control ------------------------

    var tabAtiva = null;

    $.setTabAtiva = function(tab) {
        tabAtiva = tab;
    }

    $.getTabAtiva = function() {
        return tabAtiva;
    }

    $.tab = function (selector) {
       
        return $(selector, '#' + tabAtiva);
    }

    //---- Contador -----------------------------
    var contatado = 0;

    $.getContatorValor = function() {
        return contatado++;
    }
    
}(jQuery));

$(document).ready(function () {

    $('#NovoCliente').on('click', function () {

        AtivarPartialView('tabNovoEditarCliente', 'Novo', 'Clientes', function () {

            $.setTabAtiva('tabNovoEditarCliente');

            ConfigurarDadosInvisiveisCliente('tabNovoEditarCliente');

            ConfigurarTabelaClienteContatos('tabNovoEditarCliente');

            ConfigurarMascarasCliente('tabNovoEditarCliente');

            $('#menu3 .search input', '#tabNovoEditarCliente').on('keydown', function (e) {
                if (e.keyCode == 13) {
                    e.preventDefault();
                    return false;
                }
            });

            AjusteBarraAcoes('menu3', '#tabNovoEditarCliente');

            //set ramo default
            $('#ListaRamosAtividade').val(0).trigger('change');

            $('#btnSalvarCliente', '#tabNovoEditarCliente').on('click', function (e) {

                getSelectValue('RamoAtividadeID', 'ListaRamosAtividade', 'tabNovoEditarCliente');
                getMultSelectValues('Postos', 'ListaPostos', 'tabNovoEditarCliente');
                getMultSelectValues('Marcas', 'ListaMarcas', 'tabNovoEditarCliente');
                getMultSelectValues('Servicos', 'ListaServicos', 'tabNovoEditarCliente');
                getContatos('tabNovoEditarCliente');

                AtivarSpin();
            });

            //Não permitir form submit ao preensionar ENTER nos campos
            $('input', '#tabNovoEditarCliente').on('keydown', function (e) {
                if (e.keyCode == 13) {
                    e.preventDefault();
                    return false;
                }
            });

            $('#btnConsultarCEP', '#tabNovoEditarCliente').on('click', function (e) {
           
                var $cep = $('input[name="CEP"]');
                var unmaskedCep = $cep.inputmask('unmaskedvalue');

                if ((unmaskedCep != null) && (unmaskedCep.length == 8)) {

                    DesabilitarValidacao('tabNovoEditarCliente', 'CEP');
                    $('#cepload').css('display', 'table-cell');

                    APICEP.Consultar({
                        cep: unmaskedCep,
                        success: function (dados, encontrou) {
                            if (encontrou) {
                                PreencherEndereco(dados, 'tabNovoEditarCliente');
                            } else {                              
                                HabilitarValidacao('tabNovoEditarCliente', 'CEP', 'O CEP não foi encontrado.');
                                PreencherEndereco(null, 'tabNovoEditarCliente');
                            }
                        },
                        error: function () {
                            AlertaErroInterno("Não foi possível consultar o CEP.");
                        },
                        complete: function () {
                            $('#cepload').css('display', 'none');
                        }
                    });
                } else {
                    DesabilitarValidacao('tabNovoEditarCliente', 'CEP');
                    PreencherEndereco(null, 'tabNovoEditarCliente');
                }

            });

            
            $('input[name="CEP"]', '#tabNovoEditarCliente').change(function (e) {

                    DesabilitarValidacao('tabNovoEditarCliente', 'CEP');
                    PreencherEndereco(null, 'tabNovoEditarCliente');
                                       
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

function PreencherEndereco(dados, raiz) {
    if ((dados != null) && (dados != undefined)) {
        $('input[name="Logradouro"]', '#' + raiz).val(dados.logradouro);
        $('input[name="Bairro"]', '#' + raiz).val(dados.bairro);
        $('input[name="Cidade"]', '#' + raiz).val(dados.localidade);
        $('input[name="UF"]', '#' + raiz).val(dados.uf);
    } else {
        $('input[name="Logradouro"]', '#' + raiz).val('');
        $('input[name="Bairro"]', '#' + raiz).val('');
        $('input[name="Cidade"]', '#' + raiz).val('');
        $('input[name="UF"]', '#' + raiz).val('');
    }
}

function AtivarPartialViewListaClientes(onShow) {

    AtivarPartialView('tabListaClientes', 'Lista', 'Clientes', function () {

        $('#btnEditarCliente').on('click', function () {
            var selected = $("#tblClientes").bootstrapTable('getSelections');

            if ((selected === null) || (selected.length === 0))
                AtivarAlert('warning', 'Selecione um cliente', 'listaClientesAlerta');
            else
            {
                var id = selected[0].ClienteID;

                $('#tabEditarCliente').remove();
                AtivarPartialView('tabEditarCliente', 'Editar/' + id, 'Clientes', function () {

                    $.setTabAtiva('tabEditarCliente');
             
                    ConfigurarDadosInvisiveisCliente('tabEditarCliente');

                    ConfigurarTabelaClienteContatos('tabEditarCliente',  JSON.parse($('input[name="Contatos"]', '#tabEditarCliente').val()));

                    ConfigurarMascarasCliente('tabEditarCliente');

                    $('#menu30 .search input', '#tabEditarCliente').on('keydown', function (e) {
                        if (e.keyCode == 13) {
                            e.preventDefault();
                            return false;
                        }
                    });

                    AjusteBarraAcoes('menu30', '#tabEditarCliente');

                    $('#btnSalvarCliente', '#tabEditarCliente').on('click', function (e) {

                        getSelectValue('RamoAtividadeID', 'ListaRamosAtividade', 'tabEditarCliente');
                        getMultSelectValues('Postos', 'ListaPostos', 'tabEditarCliente');
                        getMultSelectValues('Marcas', 'ListaMarcas', 'tabEditarCliente');
                        getMultSelectValues('Servicos', 'ListaServicos', 'tabEditarCliente');
                        getContatos('tabEditarCliente');

                        AtivarSpin();
                    });

                    //Não permitir form submit ao preensionar ENTER nos campos
                    $('input', '#tabEditarCliente').on('keydown', function (e) {
                        if (e.keyCode == 13) {
                            e.preventDefault();
                            return false;
                        }
                    });

                    $('#btnConsultarCEP', '#tabEditarCliente').on('click', function (e) {

                        var $cep = $('input[name="CEP"]');
                        var unmaskedCep = $cep.inputmask('unmaskedvalue');

                        if ((unmaskedCep != null) && (unmaskedCep.length == 8)) {

                            DesabilitarValidacao('tabEditarCliente', 'CEP');
                            $('#cepload').css('display', 'table-cell');

                            APICEP.Consultar({
                                cep: unmaskedCep,
                                success: function (dados, encontrou) {
                                    if (encontrou) {
                                        PreencherEndereco(dados, 'tabEditarCliente');
                                    } else {
                                        HabilitarValidacao('tabEditarCliente', 'CEP', 'O CEP não foi encontrado.');
                                        PreencherEndereco(null, 'tabEditarCliente');
                                    }
                                },
                                error: function () {
                                    AlertaErroInterno("Não foi possível consultar o CEP.");
                                },
                                complete: function () {
                                    $('#cepload').css('display', 'none');
                                }
                            });
                        } else {
                            DesabilitarValidacao('tabEditarCliente', 'CEP');
                            PreencherEndereco(null, 'tabEditarCliente');
                        }

                    });


                    $('input[name="CEP"]', '#tabEditarCliente').change( function (e) {

                            DesabilitarValidacao('tabditarCliente', 'CEP');
                            PreencherEndereco(null, 'tabEditarCliente');
                    });

                }, function () {
                    var active = $('#tabEditarCliente li.active a:first-child');
                    var tab = $(active).attr('href');
                    $('#tabEditarCliente ' + tab).addClass('in active');
                });
            }
        });

        $('#btnMudarEstadoCliente').on('click', function () {

            var selected = $("#tblClientes").bootstrapTable('getSelections');

            if ((selected === null) || (selected.length === 0))
                AtivarAlert('warning', 'Selecione um cliente', 'listaClientesAlerta');
            else {
                var id = selected[0].ClienteID;

                AtivarSpin();

                $.ajax({
                    url: '../Clientes/MudancaEstado/' + id,
                    success: function (partialView) {

                        if (VaParaAutenticacaoSeSignOut(partialView))
                            return false;

                        ModelShow({
                            bodyModel: partialView,
                            title: 'Mudança de estado',
                            onOK: function (e) {
                                AtivarSpin();
                                $('#formMudancaEstado').submit();
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
                title: 'Placa',
                formatter: function (value) {
                    if (value != null)
                        return Inputmask.format(value, { alias: 'AAA-9999' });
                }
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
                title: 'CEP',
                formatter: function (value) {
                    if (value != null)
                        return Inputmask.format(value, { alias: '99.999-999' });
                }
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

function ConfigurarDadosEditCliente() {
    
    setDefaultSelect($('input[name="RamoAtividadeID"]', '#tabEditarCliente').val(), $('#RamosAtividades', '#tabEditarCliente'));

    var strServicos = $('input[name="Servicos"]', '#tabEditarCliente').val();
    setDefaultMultSelect($('input[name="Servicos"]', '#tabEditarCliente'));
}

function ConfigurarMascarasCliente(raiz) {
    $('input[name="DataNascimento"]', '#' + raiz).inputmask('d/m/y', { placeholder: 'dd/mm/aaaa' });
    $('input[name="CEP"]', '#' + raiz).inputmask('99.999-999', { removeMaskOnSubmit: true });
    $('input[name="PlacaVeiculo"]', '#' + raiz).inputmask('AAA-9999', { removeMaskOnSubmit: true });
}

function ConfigurarDadosInvisiveisCliente(raiz) {

    setDefaultSelect('RamoAtividadeID', 'ListaRamosAtividade', raiz);
    setDefaultMultSelect('Postos', 'ListaPostos', raiz);
    setDefaultMultSelect('Marcas', 'ListaMarcas', raiz);
    setDefaultMultSelect('Servicos', 'ListaServicos', raiz);
}

function ConfigurarTabelaClienteContatos(raiz, contatos) {
    $.tab('#btnAddContato').on('click', function (e) {
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
                    },
                    onShow: function () {
                        $('input[name="Telefone"]', '#ContainerContatoClientes')
                            .inputmask('(99) 9999[9]-9999', { removeMaskOnSubmit: true });
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

    $.tab('#btnRemoveContato').on('click', function (e) {
        e.preventDefault();

        var selected = $.tab('#tblClienteContatos').bootstrapTable('getSelections');

        if ((selected == null) || (selected.length == 0))
            AlertaAtencao('Selecione um contato');
        else
        {
            $.tab('#tblClienteContatos').bootstrapTable('remove', { field: 'ContatoID', values: [selected[0].ContatoID] });
        }
    });

    $.tab('#tblClienteContatos').bootstrapTable({
        columns: [{
            radio: true
        }, {
            field: 'ContatoID',
            visible: false
        }, {
            field: 'Nome',
            title: 'Nome'
        }, {
            field: 'Telefone',
            title: 'Telefone',
            formatter: function (value) {
                if (value != null)
                    return Inputmask.format(value, '(99) 9999[9]-9999');
            }
        }],
        data: contatos,
        pagination: true,
        striped: true,
        //toolbar: '#toolbarAbaAvaliados-Gerenciar',
        search: true,
        showToggle: true,
        pageSize: 10,
        showColumns: false
    });
}

function PostContatoSuccess(data) {
    DesabilitarTodasValidacoes('formContato');

    if (data.Status === "OK") {
        $('#btnModalCancel').click();

        var _nome = $("#formContato [name='Nome']").val();
        var _telefone = $("#formContato [name='Telefone']").val();

        $.tab('#tblClienteContatos').bootstrapTable('append', [{ ContatoID: $.getContatorValor(), Nome: _nome, Telefone: _telefone }]);
    }
    else if (data.Status === "VALIDACAO") {
        data.Mensagem.forEach(function (val) {
            HabilitarValidacao('formContato', val.Campo, val.Erro);
        });
    }
}

function PostContatoError() {
    AlertaErroInterno();
}

function PostContatoComplete() {
    DesativarSpin();
}

function getContatos(raiz) {
    var contatos = $('#tblClienteContatos', '#' + raiz).bootstrapTable('getData', true);
    $.each(contatos, function (index, value) {
        value.ClienteID = 0;
        value.Telefone = Inputmask.unmask(value.Telefone, '(99) 9999[9]-9999');
    });
    var json = JSON.stringify(contatos);
    $('#' + raiz + ' [name="Contatos"]').val(json);
}


//inputValues deve conter uma lista de valores separador por virgula.
//Exemplos:   "1,2,6,29"      "Maça,Uva,Abacaxi" 
function setDefaultMultSelect(inputValues, multSelect, raiz) {
    var strValues = $('#' + inputValues, '#' + raiz).val();

    if (strValues != null) {
        var arrayValues = strValues.split(',');

        $('#' + multSelect, '#' + raiz).val(arrayValues).trigger('change');
    }
}

function setDefaultSelect(inputValue, select, raiz) {
    var value = $('#' + inputValue, '#' + raiz).val();

    if (value != null) {
        $('#' + select, '#' + raiz).val(value).trigger('change');
    }
}

function getSelectValue(inputSorce, select, raiz) {

    var arrayValues = $('#' + select, '#' + raiz).val();

    if ((arrayValues != null) && (arrayValues.length != 0)) {

        var value = $('#' + select, '#' + raiz).val();

        if (value != null)
            $('#' + inputSorce, '#' + raiz).val(value);
    }
    else
        $('#' + inputSorce, '#' + raiz).val(null);
}

function getMultSelectValues(inputSorce, multSelect, raiz) {
    var arrayValues = $('#' + multSelect, '#' + raiz).val();

    if ((arrayValues != null) && (arrayValues.length != 0)) {

        var strValues = "";
        $.each(arrayValues, function (index, value) {

            if (index != 0)
                strValues += ',';

            strValues += value;
        });
        $('#' + inputSorce, '#' + raiz).val(strValues);
    }
    else
        $('#' + inputSorce, '#' + raiz).val(null);
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


function PostClienteEditSuccess(data, status, xhr) {

    DesabilitarTodasValidacoes('tabEditarCliente');
    DesativarAlert('listaClientesAlerta');

    if (data.Status === 'OK') {

        AtivarPartialViewListaClientes(function () {
            AtivarAlert('success', data.Mensagem, 'listaClientesAlerta');
            $(document).remove($('#tabEditarCliente'));
        });

    } else if (data.Status === 'VALIDACAO') {
        data.Mensagem.forEach(function (val) {
            HabilitarValidacao('tabEditarCliente', val.Campo, val.Erro);
        });
    } else if (data.Status === 'ERRO') {
        AlertaErroInterno(data.Mensagem);
    }
}

function PostClienteEditError() {
    AlertaErroInterno();
}

function PostClienteEditComplete() {
    DesativarSpin();
}


function PostMudancaEstadoSuccess(data) {

    DesabilitarTodasValidacoes('containerClienteMudancaEstado');

    if (data.Status === 'OK') {

        $('#btnModalCancel').click();
        AtivarAlert('success', data.Mensagem, 'listaClientesAlerta');

    } else if (data.Status === 'VALIDACAO') {

        data.Mensagem.forEach(function (val) {
            HabilitarValidacao('containerClienteMudancaEstado', val.Campo, val.Erro);
        });

    } else if (data.Status === 'ERRO') {
        AlertaErroInterno(data.Mensagem);
    }
}

function PostMudancaEstadoError() {
    AlertaErroInterno();
}

function PostMudancaEstadoComplete() {
    DesativarSpin();
}
