﻿using MultishopOnion.Application.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopOnion.Application.Exceptions
{
    public class AlreadyExsitsException : BaseException
    {
        public AlreadyExsitsException(string mess, int code = 400) : base(mess)
        {
            StatusCode = code;
        }

        public override int StatusCode { get; }
    }
}
