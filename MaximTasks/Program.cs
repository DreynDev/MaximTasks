using MaximTasks;
using MaximTasks.SortingAlgorithms;
using MaximTasks.Services;

class Program
{
    static void Main()
    {
        Console.Write("Введите строку: ");
        string input = Console.ReadLine();

        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Ваша строка пустая");
            return;
        }

        var invalidChars = Utility.UnexpectedChars(input);

        Console.WriteLine("Выберите алгоритм сортировки");
        Console.WriteLine("1 - Быстрая сортировка (QuickSort)");
        Console.WriteLine("2 - Сортировка деревом (TreeSort)");
        Console.Write("Ваш выбор: ");

        int choice = int.Parse(Console.ReadLine());

        string sortedString = string.Empty;

        string result = Utility.ProcessString(input);

        switch (choice)
        {
            case 1:
                sortedString = QuickSortClass.SortedString(result);
                break;
            case 2:
                sortedString = TreeSortClass.SortedString(result);
                break;
            default:
                Console.WriteLine("Некорректный выбор");
                return;
        }
        var randomNumbersGeneratorService = new RandomNumberGeneratorService();

        var randomNumber = randomNumbersGeneratorService.GetRandomNumber(0, result.Length - 1).Result;
        var cuttedString = Utility.RemoveRandomCharInString(result, randomNumber);

        if (invalidChars.Count > 0)
        {
            var uniqueInvalidChars = invalidChars.Distinct().OrderBy(c => c)
                .Select(c => $"\"{c}\"");
            Console.WriteLine("Ошибка: были введены неподходящие символы: " + string.Join(", ", uniqueInvalidChars));
        }
        else
        {
            Console.WriteLine("Результат: " + result);

            var allChars = result.ToCharArray().ToList();
            var groupedChars = allChars.GroupBy(c => c)
                .Select(c => new { Char = c.Key, Count = c.Count() });

            Console.WriteLine("\nКол-во вхождений символа в результат:");
            foreach (var item in groupedChars)
            {
                Console.WriteLine($"Символ: \"{item.Char}\", Количество: {item.Count}");
            }

            var GetLongestVowelSubstring = Utility.GetLongestVowelSubstring(result);
            Console.WriteLine($"\nСамая длинная подстрока начинающаяся и заканчивающаяся на гласную: {GetLongestVowelSubstring}");
            Console.WriteLine("Отсортированная обработанная строка: " + sortedString);
            Console.WriteLine("«Урезанная» обработанная строка: " + cuttedString);
        }
    }
}
