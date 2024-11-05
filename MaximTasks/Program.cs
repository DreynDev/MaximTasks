using MaximTasks;

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
        if (invalidChars.Count > 0)
        {
            var uniqueInvalidChars = invalidChars.Distinct().OrderBy(c => c)
                .Select(c => $"\"{c}\"");
            Console.WriteLine("Ошибка: были введены неподходящие символы: " + string.Join(", ", uniqueInvalidChars));
        }
        else
        {
            string result = Utility.ProcessString(input);
            Console.WriteLine("Результат: " + result);

            var allChars = result.ToCharArray().ToList();
            var groupedChars = allChars.GroupBy(c => c)
                .Select(c => new { Char = c.Key, Count = c.Count() });

            Console.WriteLine("\nКол-во вхождений символа в результат:");
            foreach (var item in groupedChars)
            {
                Console.WriteLine($"Символ: \"{item.Char}\", Количество: {item.Count}");
            }
        }
    }
}
