using System;
using System.Collections.Generic;
using System.Linq;
using SimpleServer.Interfaces;

namespace SimpleServer.MessageCommand
{
    public class CommandFactory : ICommandFactory
    {
        private readonly ILoggerFactory _loggerFactory;

        public CommandFactory(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
        }

        //todo с этим надо что то делать
        public IResponse GetResponseObject(Dictionary<Commands, Switch> states, int id)
        {
            var keys = states.Select(pair => pair).
                              Where(pair => pair.Value == Switch.on).
                              Select(pair => pair.Key).
                              ToArray();

            if (states[Commands.time] == Switch.off &&
                states[Commands.report] == Switch.off &&
                states[Commands.log] == Switch.off &&
                states[Commands.Error] == Switch.off)
            {
                states[Commands.time] = Switch.off;
                return new EmptyResponse();
            }

            if (states[Commands.time] == Switch.on &&
                states[Commands.report] == Switch.off &&
                states[Commands.log] == Switch.off &&
                states[Commands.Error] == Switch.off)
            {
                states[Commands.time] = Switch.off;
                return new DateResponse(new EmptyResponse());
            }

            if (states[Commands.time] == Switch.off && 
               states[Commands.report] == Switch.on && 
               states[Commands.log] == Switch.off && 
               states[Commands.Error] == Switch.off) 
                return new TimerResponse(new EmptyResponse(), keys);
            if (states[Commands.time] == Switch.off && 
               states[Commands.report] == Switch.off && 
               states[Commands.log] == Switch.on && 
               states[Commands.Error] == Switch.off) 
                return new LoggerResponse(new EmptyResponse(), _loggerFactory.GetLog(id), keys);
            if (states[Commands.time] == Switch.on &&
                states[Commands.report] == Switch.on &&
                states[Commands.log] == Switch.off &&
                states[Commands.Error] == Switch.off)
            {
                states[Commands.time] = Switch.off;
                return new TimerResponse(new DateResponse(new EmptyResponse()), keys);
            }

            if (states[Commands.time] == Switch.on &&
                states[Commands.report] == Switch.off &&
                states[Commands.log] == Switch.on &&
                states[Commands.Error] == Switch.off)
            {
                states[Commands.time] = Switch.off;
                return new LoggerResponse(new DateResponse(new EmptyResponse()), _loggerFactory.GetLog(id), keys);
            }

            if (states[Commands.time] == Switch.off &&
                states[Commands.report] == Switch.on &&
                states[Commands.log] == Switch.on &&
                states[Commands.Error] == Switch.off)
                return new TimerResponse(new LoggerResponse(new EmptyResponse(), _loggerFactory.GetLog(id), keys), keys);

            if (states[Commands.time] == Switch.on &&
                states[Commands.report] == Switch.on &&
                states[Commands.log] == Switch.on &&
                states[Commands.Error] == Switch.off)
            {
                states[Commands.time] = Switch.off;
                return new TimerResponse(new LoggerResponse(new DateResponse(new EmptyResponse()),
                    _loggerFactory.GetLog(id), keys), keys);
            }

            states[Commands.Error] = Switch.off;
            return new ErrorReport(new EmptyResponse());
        }
    }
}
