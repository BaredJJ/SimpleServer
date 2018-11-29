using System;
using SimpleServer.Interfaces;

namespace SimpleServer.MessageCommand
{
    public class LoggerResponse : ResponseDecorate
    {
        private readonly ILog _logger;
        private readonly Commands[] _names;

        //todo нужно подумаьть как сделать красивей. Вдруг надо будет писать не только имена команд.
        public LoggerResponse(IResponse response, ILog logger, Commands[] names) : base(response)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _names = names ?? throw new ArgumentNullException(nameof(names));
        }

        public override string Response()
        {
            var message = _response.Response();
            foreach (var name in _names)
            {
                _logger.Write(name.ToString());
            }

            return message;
        }
    }
}
