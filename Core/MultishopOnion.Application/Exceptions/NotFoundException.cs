﻿
using MultishopOnion.Application.Exceptions.Base;

namespace MultishopOnion.Application.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(int code=404, string mess = "Not Found!") :base(mess)
        {
            
        }

        public override int StatusCode { get; }

    }
}
