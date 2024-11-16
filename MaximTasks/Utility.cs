

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
    public static string GetLongestVowelSubstring(string str)
    {
        var vowelChars = "aeiouy";
        var reversedText = ReverseString(str);
        for (var i = 0; i < str.Length; i++)
        {
            if (vowelChars.Contains(str[i]))
            {
                for (var j = 0; j < reversedText.Length - i; j++)
                {
                    if (vowelChars.Contains(reversedText[j]))
                    {
                        int endIndex = str.Length - j - 1;
                        return str.Substring(i, endIndex - i + 1);
                    }
                }
            }
        }
        return string.Empty;
    }
    public static int GetRandomNumber(int min, int max)
    {
        return Random.Shared.Next(min, max);
    }
    public static string RemoveRandomCharInString(string text, int index)
    {
        return text.Remove(index, 1);
    }
}
