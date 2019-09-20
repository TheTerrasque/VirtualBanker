namespace VirtualBankLib.Models
{
    public interface ICurrencyNotation
    {
        int Used { get; }
        string Name { get; }
        decimal Value { get; }
        int Available { get; }

        void Take(int number=1);
        void Reset();
    }
}