using EventHistory.Interfaces;

namespace EventHistory.Services
{
    public class TestService : ITestService
    {
        public async Task<string> Test(string request)
        {
            return "asdf";
        }
    }
}
