using System.Collections.Generic;
using SimpleServer.Interfaces;

namespace SimpleServer.MessageCommand
{
    public class OffResponse:ResponseDecorate
    {
        private readonly KeyValuePair<Commands, Switch> _command;

        public OffResponse(IResponse response, KeyValuePair<Commands, Switch> command) : base(response)
        {
            _command = command;
        }

        public override string Response()
        {
            return _response.Response() + _command.Key + ":" + _command.Value + '\n' + '\r';
        }
    }
}
