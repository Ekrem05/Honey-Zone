namespace HoneyZoneMvc.BusinessLogic.Contracts.SubContracts
{
    public interface IUpdateAble<T> where T : class
    {
        Task UpdateAsync(T model);
    }
}
