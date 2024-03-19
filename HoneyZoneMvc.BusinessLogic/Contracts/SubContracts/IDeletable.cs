namespace HoneyZoneMvc.BusinessLogic.Contracts.SubContracts
{
    public interface IDeletable
    {
        Task DeleteAsync(string Id);
    }
}
