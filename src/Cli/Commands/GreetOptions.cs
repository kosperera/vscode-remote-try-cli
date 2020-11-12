namespace HelloWorld.Cli.Commands
{
    public class GreetOptions
    {
        public string Name { get; }

        public GreetOptions(string name)
        {
            Name = name;
        }
    }
}