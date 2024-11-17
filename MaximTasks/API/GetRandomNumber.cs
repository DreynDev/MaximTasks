using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace MaximTasks.API
{
    public class RandomNumberApiClient
    {
        private readonly HttpClient _client;

        public RandomNumberApiClient()
        {
            _client = new HttpClient();
        }


        public async Task<int> GetRandomNumberAsync(int min, int max)
        {
            string url = $"{AppSettings.RandomAPI}?min={min}&max={max}&count=1";

            try
            {
                HttpResponseMessage response = await _client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    int[] numbers = JsonSerializer.Deserialize<int[]>(responseContent);

                    return numbers.Length > 0 ? numbers[0] : throw new Exception("Ответ не содержит чисел.");
                }
                else
                {
                    throw new Exception($"Ошибка при запросе: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
