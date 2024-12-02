List<List<int>> reports = new();

string filePath = "C:\\Users\\georg\\source\\repos\\advent_of_code\\2024\\day_02\\day_02\\day_02\\input.txt"; // im not fixing it and no im not using relative paths this is staying here

if (!File.Exists(filePath))
{
    Console.WriteLine("filepath borked");
}
if (File.Exists(filePath))
{
    using (StreamReader sr = new StreamReader(filePath))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            List<int> report = new();
            string[] values = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var value in values)
            {
                if (int.TryParse(value, out int num))
                {
                    report.Add(num);
                }
            }
            reports.Add(report);
            Console.WriteLine("Report" + report.ToString());
        }
    }
}

int safeReports = 0;

foreach (List<int> report in reports)
{
    if (IsSafeReport(report) || CanBecomeSafeWithRemoval(report))
    {
        safeReports++;
    }
}

Console.WriteLine(safeReports);


static bool IsSafeReport(List<int> report)
{
    bool isDecreasing = true;
    bool isIncreasing = true;

    for (int i = 0; i < report.Count - 1; i++)
    {
        int difference = Math.Abs(report[i + 1] - report[i]);

        if (difference < 1 || difference > 3)
        {
            return false;
        }
        
        if (report[i + 1] > report[i])
        {
            isDecreasing = false;
        }

        if (report[i + 1] < report[i])
        {
            isIncreasing = false;
        }
    }
    return isDecreasing || isIncreasing;
}

static bool CanBecomeSafeWithRemoval(List<int> report)
{
    for (int i = 0; i < report.Count; i++)
    {
        List<int> modifiedReport = new List<int>(report);
        modifiedReport.RemoveAt(i);

        if (IsSafeReport(modifiedReport))
        {
            return true;
        }
    }
    return false;
}