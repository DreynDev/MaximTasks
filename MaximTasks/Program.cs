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

        string result = Utility.ProcessString(input);

        Console.WriteLine("Результат: " + result);
    }
}
