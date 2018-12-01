using System;
using System.Collections.Generic;
using SimpleServer.Interfaces;

namespace SimpleServer.MessageCommand
{
    public class LoggerResponse : ResponseDecorate
    {
        private readonly ILog _logger;
        private readonly KeyValuePair<Commands, Switch> _command;
        private const string On = "Log on\n\r";

        //todo нужно подумаьть как сделать красивей. Вдруг надо будет писать не только имена команд.
        public LoggerResponse(IResponse response, ILog logger, KeyValuePair<Commands, Switch> command) : base(response)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _command = command;
        }

        public override string Response()
        {
            var message = _response.Response();
            _logger.Write("Command: " +_command.Key + " Sate: " + _command.Value);

            return message + On;
        }
    }
}
