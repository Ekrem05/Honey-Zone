namespace HoneyZoneMvc.BusinessLogic.Contracts.ExtensionContracts
{
    public interface ICategoryStatistic
    {
        string[] Categories { get; set; }
        Dictionary<string, int> ProductsSoldInCategory { get; set; }
    }
}