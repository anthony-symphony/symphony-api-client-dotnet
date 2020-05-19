using System;
using System.Collections.Generic;
using System.Text;

namespace apiClientDotNet.Models
{
    public class ClientError
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public Object Details { get; set; }

    }
}
