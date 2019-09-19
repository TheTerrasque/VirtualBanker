namespace VirtualBankLib
{
    public interface IChangeSolver
    {
        void FindReturnFor(ICurrencyHolder holder, decimal amount);
    }
}