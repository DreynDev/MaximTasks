using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaximTasks.API;


namespace MaximTasks.Services
{
    public class RandomNumberGeneratorService
    {
        private readonly RandomNumberApiClient _randomNumberApiClient;

        public RandomNumberGeneratorService()
        {
            _randomNumberApiClient = new RandomNumberApiClient();
        }
        public async ValueTask<int> GetRandomNumber(int min, int max)
        {
            try
            {
                return await _randomNumberApiClient.GetRandomNumberAsync(min, max);
            }
            catch
            {
                return Utility.GetRandomNumber(min, max);
            }
        }
    }
}
