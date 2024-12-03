using System.Text.RegularExpressions;

string filePath = "C:\\Users\\georg\\source\\repos\\advent_of_code\\2024\\day_03\\input.txt"; //never doing it smarter than this
string memory;

try
{
	memory = File.ReadAllText(filePath);
}
catch (Exception)
{
    Console.WriteLine("didn't work m8");
    return;
}

// captures anything that starts mul, contains (, contains 2 nums separated by a ',', where each num is 1-3 digits, closed with a )
string pattern = @"mul\(\d{1,3},\d{1,3}\)";

var matches = Regex.Matches(memory, pattern);

int total = 0;

foreach (Match match in matches)
{
    string[] numbers = Regex.Matches(match.Value, @"\d+")
        .Select(x => x.Value).ToArray();

    int x = int.Parse(numbers[0]);
    int y = int.Parse(numbers[1]);
    total += x * y;
}

Console.WriteLine(total);