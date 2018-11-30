using System;
using System.Diagnostics;
using SimpleServer.Interfaces;

namespace SimpleServer.MessageCommand
{
    public class TimerResponse:ResponseDecorate
    {
        private static readonly string CurrentCommands = "Current commands: \n\r";
        private readonly Commands[] _names;

        public TimerResponse(IResponse response, Commands[] names) : base(response)
        {
            _names = names ?? throw new ArgumentNullException(nameof(names));
        }

        public override string Response()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var message = _response.Response();
            message += CurrentCommands;
            foreach (var name in _names)
            {
                message += name.ToString() + '\n' + '\r';
            }
            stopwatch.Stop();

            return message + stopwatch.ElapsedMilliseconds + '\n' + '\r';
        }
    }
}
