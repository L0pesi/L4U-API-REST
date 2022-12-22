using L4U_BOL_MODEL.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4U_BOL_MODEL.Utils
{
    public static class StandardResponse
    {
        /// <summary>
        /// This method returns a response object with status code not found
        /// </summary>
        /// <returns></returns>
        public static Response NotFoundReponse() => new Response
        {
            StatusCode = StatusCodes.NOTFOUND,
            Message = CommonMessages.NotFoundMessage,
            Data = null
        };

        /// <summary>
        /// This method returns a response object with status code no content
        /// </summary>
        /// <returns></returns>
        public static Response EmptyResponse() => new Response
        {
            StatusCode = StatusCodes.NOCONTENT,
            Message = CommonMessages.NoContentMessage,
            Data = null
        };

        /// <summary>
        /// This method returns a response object with status code invalid request
        /// </summary>
        /// <returns></returns>
        public static Response InvalidRequestResponse() => new Response
        {
            StatusCode = StatusCodes.BADREQUEST,
            Message = CommonMessages.BadRequestMessage,
            Data = null
        };

        public static Response Error() => new Response
        {
            StatusCode = StatusCodes.INTERNALSERVERERROR,
            Message = CommonMessages.ErrorMessage,
            Data = null
        };
    }
}
