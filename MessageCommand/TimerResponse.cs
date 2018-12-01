using System.Collections.Generic;
using System.Diagnostics;
using SimpleServer.Interfaces;

namespace SimpleServer.MessageCommand
{
    public class TimerResponse:ResponseDecorate
    {
        private static readonly string CurrentCommand = "Current command: \n\r";
        private readonly KeyValuePair<Commands, Switch> _command;

        public TimerResponse(IResponse response, KeyValuePair<Commands, Switch> command) : base(response)
        {
            _command = command;
        }

        public override string Response()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var message = _response.Response();
            message += CurrentCommand;
            message += _command.Key + " State: " + _command.Value + "\n\r";
            stopwatch.Stop();

            return message + stopwatch.ElapsedMilliseconds + '\n' + '\r';
        }
    }
}
