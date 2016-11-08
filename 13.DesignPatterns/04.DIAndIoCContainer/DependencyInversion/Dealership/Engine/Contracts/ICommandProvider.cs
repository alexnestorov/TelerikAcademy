namespace Dealership.Engine
{
    public interface ICommandProvider
    {
        string ProvideSingleCommand(ICommand command, IDealershipEngine engine);

        void ProvideNextCommand(ICommandProvider nextCommandProvider);
    }
}
