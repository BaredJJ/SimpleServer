using SimpleServer.Interfaces;

namespace SimpleServer.MessageCommand
{
    public class ErrorReport:ResponseDecorate
    {
        private const string ErrorMessage = "Invalid command\n\r";

        public ErrorReport(IResponse response) : base(response){}

        public override string Response() => ErrorMessage;
    }
}
