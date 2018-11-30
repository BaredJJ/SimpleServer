using System;
using SimpleServer.Interfaces;

namespace SimpleServer.MessageCommand
{
    public class DateResponse:ResponseDecorate
    {
        public DateResponse(IResponse response) : base(response) { }

        public override string Response()
        {
            return _response.Response() + DateTime.Now + '\n'+'\r';
        }
    }
}
