using MultishopOnion.Application.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopOnion.Application.Exceptions
{
    public class BadRequestException:BaseException
    {
        public BadRequestException(int code = 400, string mess = "Bad request!") : base(mess)
        {
            StatusCode = code;
        }

        public override int StatusCode { get; }
    }
}
