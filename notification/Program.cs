using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string input1 = "[BE][FE][Urgent] there is error";
        string input2 = "[BE][QA][HAHA][Urgent] there is error";

        Console.WriteLine("Case 1:");
        Console.WriteLine(ParseNotificationChannels(input1));

        Console.WriteLine("\nCase 2:");
        Console.WriteLine(ParseNotificationChannels(input2));
    }

    static string ParseNotificationChannels(string input)
    {
        var channels = new List<string>();
        string pattern = @"\[(.*?)\]";
        MatchCollection matches = Regex.Matches(input, pattern);

        foreach (Match match in matches)
        {
            string tag = match.Groups[1].Value;
            if (IsValidChannel(tag))
            {
                channels.Add(tag);
            }
        }

        return "Receive channels: " + string.Join(", ", channels);
    }

    static bool IsValidChannel(string tag)
    {
        string[] validChannels = { "BE", "FE", "QA", "Urgent" };
        return validChannels.Contains(tag);
    }
}

