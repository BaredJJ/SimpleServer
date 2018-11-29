using System;
using SimpleServer.Interfaces;

namespace SimpleServer.MessageCommand
{
    public class LoggerResponse : ResponseDecorate
    {
        private readonly ILog _logger;

        public LoggerResponse(IResponse response, ILog logger) : base(response)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public override string Response()
        {
            var message = _response.Response();//todo Нужно добавить просмотр имен команд по иерархии
            _logger.Write(message);

            return message;
        }
    }
}
