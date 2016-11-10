namespace Cosmetics.Contracts
{
    public interface ICommandProvider
    {
        string ProvideSingleCommand(ICommand command);
    }
}
