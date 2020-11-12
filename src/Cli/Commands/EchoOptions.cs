namespace HelloWorld.Cli.Commands
{
    public class EchoOptions
    {
        public string Message { get; }
        public int Times { get; }

        public EchoOptions(string message = "nothing", int times = 5)
        {
            Message = message;
            Times = times;
        }
    }
}