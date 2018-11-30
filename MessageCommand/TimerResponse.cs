using System.Diagnostics;
using SimpleServer.Interfaces;

namespace SimpleServer.MessageCommand
{
    public class TimerResponse:ResponseDecorate
    {
        public TimerResponse(IResponse response) : base(response) { }

        public override string Response()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var message = _response.Response();
            stopwatch.Stop();

            return message + stopwatch.ElapsedMilliseconds + '\n' + '\r';
        }
    }
}
