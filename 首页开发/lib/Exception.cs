﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 首页开发
{
    public class WxPayException : Exception
    {
        public WxPayException(string msg)
            : base(msg)
        {

        }
    }
}