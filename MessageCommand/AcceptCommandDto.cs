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

        public override bool Equals(object obj)
        {
            if (!(obj is AcceptCommandDto commandDto)) return false;

            return Command == commandDto.Command && State == commandDto.State;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
