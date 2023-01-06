using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4U_BOL_MODEL.Utilities
{

    /// <summary>
    /// Library for System Messages
    /// </summary>
    public static class SystemMessages
    {
        public static readonly string NoContentMessage = "Não existem registos.";
        public static readonly string NotFoundMessage = "Informação não encontrada.";
        public static readonly string BadRequestMessage = "Formato do pedido inválido.";
        public static readonly string ErrorMessage = "Ocorreu um erro.";

        public static readonly string RecordAdded = "Registo adicionado com sucesso.";
        public static readonly string RecordUpdated = "Registo atualizado com sucesso.";
        public static readonly string RecordDeleted = "Registo apagado com sucesso.";
        public static readonly string USEREXISTS = "Sucesso.";
        public static readonly string UserDontExist = "Utilizador não registado.";


        //SQL messages
        public static readonly string CREATED = "CREATED";
        public static readonly string ALREADYEXISTS = "ALREADY EXISTS";

    }
}
