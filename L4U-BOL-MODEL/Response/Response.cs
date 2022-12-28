using L4U_BOL_MODEL.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4U_BOL_MODEL.Response
{
    /// <summary>
    /// Especificação do RESPONSE
    /// </summary>
    public class ResponseFunction
    {
        /// <summary>
        /// Code of the status, provided in the response
        /// </summary>
        public StatusCodes StatusCode { get; set; }

        /// <summary>
        /// Message provided in the response
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Object provided in the response. Can be anything
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Standard constructor of this class
        /// </summary>
        public ResponseFunction() { }

        /// <summary>
        /// Constructor of this class
        /// </summary>
        /// <param name="_code">Status code</param>
        /// <param name="_message">Message</param>
        /// <param name="_data">Object</param>
        public ResponseFunction(StatusCodes _code, string _message, object _data)
        {
            this.StatusCode = _code;
            this.Message = _message;
            this.Data = _data;
        }
    }
}
