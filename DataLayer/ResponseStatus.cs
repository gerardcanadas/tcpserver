using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ResponseStatus
    {
        public byte Status { get; private set; }

        public ResponseStatus(byte status)
        {
            Status = status;
        }

        public class ServerResponseStatus : ResponseStatus
        {
            public static ServerResponseStatus Success = new ServerResponseStatus(0x00);
            public static ServerResponseStatus BadRequest = new ServerResponseStatus(0x01);
            public ServerResponseStatus(byte status) : base(status) { }
        }
    }
}
