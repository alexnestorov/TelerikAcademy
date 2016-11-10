namespace Cosmetics.Contracts
{
    public interface ICategory
    {
        string Name { get; }

        void AddCosmetics(IProduct cosmetics);

        void RemoveCosmetics(IProduct cosmetics, IInputOutputProvider provider);

        string Print();
    }
}
