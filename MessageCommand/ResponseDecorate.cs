using System;
using SimpleServer.Interfaces;

namespace SimpleServer.MessageCommand
{
    public abstract class ResponseDecorate : IResponse
    {
        protected readonly IResponse _response;

        protected ResponseDecorate(IResponse response)
        {
            _response = response ?? throw new ArgumentNullException(nameof(response));
        }

        public virtual string Response() => _response.Response();
    }
}
