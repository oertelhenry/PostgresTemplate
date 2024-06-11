namespace EventHistory.Interfaces
{
    public interface ITestService
    {
        Task<string> Test(string request);
    }
}
