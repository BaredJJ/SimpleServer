namespace SimpleServer.MessageCommand
{
    public class AcceptCommandDto
    {
        public AcceptCommandDto(Commands command, Switch state)
        {
            Command = command;
            State = state;
        }

        public Commands Command { get; }
        public Switch State { get; }
    }
}
