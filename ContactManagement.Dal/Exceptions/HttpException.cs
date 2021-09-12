using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Dal.Exceptions
{
    public class HttpException : Exception
    {
        public HttpStatusCode httpStatusCode;
        public string ErrorMessage;

        public HttpException(HttpStatusCode statusCode, string errorMessage)
        {
            this.httpStatusCode = statusCode;
            this.ErrorMessage = errorMessage;
        }
    }
}
