List<int> list1 = new();
List<int> list2 = new();

string filePath = "C:\\Users\\georg\\source\\repos\\advent_of_code\\2024\\day_02\\day_02\\day_02\\input.txt"; // yes i spelled my own name wrong when i set my pc up and i cba to fix it 

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
            string[] ids = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (int.TryParse(ids[0], out int num1))
                list1.Add(num1);
            if (int.TryParse(ids[1], out int num2))
                list2.Add(num2);
        }
    }

    int similarityScore = 0;
    foreach (var num in list1)
    {
        int countInList2 = list2.FindAll(x => x == num).Count;
        similarityScore += num * countInList2;
    }

    Console.WriteLine(similarityScore);
}