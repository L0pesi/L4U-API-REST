using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using L4U_BOL_MODEL.Response;

namespace L4U_BOL_MODEL.Utilities
{
    public static class StandardResponse
    {
        /// <summary>
        /// This method returns a response object with status code not found
        /// </summary>
        /// <returns></returns>
        public static ResponseFunction NotFoundReponse() => new ResponseFunction
        {
            StatusCode = StatusCodes.NOTFOUND,
            Message = SystemMessages.NotFoundMessage,
            Data = null
        };

        /// <summary>
        /// This method returns a response object with status code no content
        /// </summary>
        /// <returns></returns>
        public static ResponseFunction EmptyResponse() => new ResponseFunction
        {
            StatusCode = StatusCodes.NOCONTENT,
            Message = SystemMessages.NoContentMessage,
            Data = null
        };

        /// <summary>
        /// This method returns a response object with status code invalid request
        /// </summary>
        /// <returns></returns>
        public static ResponseFunction InvalidRequestResponse() => new ResponseFunction
        {
            StatusCode = StatusCodes.BADREQUEST,
            Message = SystemMessages.BadRequestMessage,
            Data = null
        };


        /// <summary>
        /// This method returns a response object with status code ERROR
        /// </summary>
        /// <returns></returns>
        public static ResponseFunction Error() => new ResponseFunction
        {
            StatusCode = StatusCodes.INTERNALSERVERERROR,
            Message = SystemMessages.ErrorMessage,
            Data = null
        };
    }
}
