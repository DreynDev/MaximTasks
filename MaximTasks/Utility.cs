namespace MaximTasks;

public class Utility
{
    public static string ProcessString(string input)
    {
        if (input.Length % 2 == 0)
        {
            int midIndex = input.Length / 2;
            return ReverseString(input.Substring(0, midIndex)) + ReverseString(input.Substring(midIndex));
        }
        return ReverseString(input) + input;
    }
    public static string ReverseString(string str)
    {
        var charArray = str.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
    public static List<char> UnexpectedChars(string str)
    {
        var validChars = new HashSet<char>("abcdefghijklmnopqrstuvwxyz");
        var invalidChars = new List<char>();
        foreach (char c in str)
        {
            if (!validChars.Contains(c))
            {
                invalidChars.Add(c);
            }
        }
        return invalidChars;
    }
}
