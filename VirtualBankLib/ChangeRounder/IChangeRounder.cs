namespace VirtualBankLib.ChangeRounder
{
    public interface IChangeRounder
    {
        bool ShouldRoundUp(decimal amount, decimal closestNomination);
    }
}