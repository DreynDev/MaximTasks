using MaximTasks.SortingAlgorithms;
using Microsoft.Extensions.Configuration;

namespace MaximTasks.Services
{
    public class StringProcessingService
    {
        private static readonly StringProcessingService _stringProcessingService = new StringProcessingService();
        private StringProcessingService() { }

        public static StringProcessingService Instance => _stringProcessingService;

        public object ProcessString(string input, string sortType)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Ваша строка пустая");
            }

            var invalidChars = Utility.UnexpectedChars(input);

            string sortedString = string.Empty;

            string result = Utility.ProcessString(input);

            switch (sortType)
            {
                case "quick":
                    sortedString = QuickSortClass.SortedString(result);
                    break;
                case "tree":
                    sortedString = TreeSortClass.SortedString(result);
                    break;
                default:
                    throw new ArgumentException("Некорректный выбор");
            }
            var randomNumbersGeneratorService = new RandomNumberGeneratorService();

            var randomNumber = randomNumbersGeneratorService.GetRandomNumber(0, result.Length - 1).Result;
            var cuttedString = Utility.RemoveRandomCharInString(result, randomNumber);

            if (invalidChars.Count > 0)
            {
                var uniqueInvalidChars = invalidChars.Distinct().OrderBy(c => c)
                    .Select(c => $"\"{c}\"");
                throw new ArgumentException("Ошибка: были введены неподходящие символы: " + string.Join(", ", uniqueInvalidChars));
            }


            if (AppSettings.BlackList.Contains(input))
            {
                throw new ArgumentException($"Ошибка: слово '{input}' входит в черный список.");
            }

            else
            {
                var allChars = result.ToCharArray().ToList();
                var groupedChars = allChars.GroupBy(c => c)
                    .Select(c => new { Char = c.Key, Count = c.Count() });

                var GetLongestVowelSubstring = Utility.GetLongestVowelSubstring(result);
                var longestVowelSubstring = Utility.GetLongestVowelSubstring(result);

                var response = new
                {
                    message = "Результат успешно обработан",
                    result,
                    characterCounts = groupedChars.Select(item => new
                    {
                        character = item.Char,
                        count = item.Count
                    }),
                    longestVowelSubstring,
                    sortedString,
                    cuttedString
                };
                return response;
            }
        }
    }
}
