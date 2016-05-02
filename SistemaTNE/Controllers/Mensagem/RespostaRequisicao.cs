
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SistemaTNE.Controllers.Mensagem
{
    public class RespostaRequisicao
    {
        public const string STATUS_OK = "OK";
        public const string STATUS_VALIDACAO = "VALIDACAO";
        public const string STATUS_ERRO = "ERRO";


        public string Status { get; set; }

        public object Mensagem { get; set; }


        public RespostaRequisicao()
        {
        }


        public static RespostaRequisicao FromModelState(ModelStateDictionary modelState)
        {
            var resp = new RespostaRequisicao()
            {
                Status = STATUS_VALIDACAO,
                Mensagem = new List<ValidacaoCampo>()
            };

            foreach (var key in modelState.Keys)
            {
                if  (modelState[key].Errors.Count > 0)
                {
                    foreach (var erro in modelState[key].Errors)
                    {
                        (resp.Mensagem as List<ValidacaoCampo>).Add(new ValidacaoCampo()
                        {
                            Campo = key,
                            Erro = erro.ErrorMessage
                        });
                    }
                }
            }

            return resp;
        }

        public static RespostaRequisicao SimpleText(string mensagem)
        {
            return new RespostaRequisicao()
            {
                Status = STATUS_OK,
                Mensagem = mensagem         
            };
        }

        public static RespostaRequisicao SimpleOK()
        { 
            return new RespostaRequisicao()
            {
                Status = STATUS_OK,
                Mensagem = null
            };
        }

        public static RespostaRequisicao SimpleError(string erro)
        {
            return new RespostaRequisicao()
            {
                Status = STATUS_ERRO,
                Mensagem = erro
            };
        }

        public static RespostaRequisicao DefaultInternalError()
        {
            return new RespostaRequisicao()
            {
                Status = STATUS_ERRO,
                Mensagem = "Desculpe-nos. Ocorreu um problema inesperado. Favor entrar em contato com o suporte."
            };
        }
    }

    public class ValidacaoCampo
    {
        public string Campo { get; set; }

        public string Erro { get; set; }
    }
}