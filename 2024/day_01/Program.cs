List<int> list1 = new();
List<int> list2 = new();

string filePath = "C:\\Users\\georg\\source\\repos\\advent_of_code_2024\\advent_of_code_2024\\input.txt"; // yes i spelled my own name wrong when i set my pc up and i cba to fix it 

if(!File.Exists(filePath))
{
    Console.WriteLine("filepath borked");
}

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
    list1.Sort();
    list2.Sort();

    int difference = 0;
    
    for (int i = 0; i < list1.Count; i++)
    {
        if (list1[i] > list2[i])
        {
            difference += list1[i] - list2[i];
        }
        else
        {
            difference += list2[i] - list1[i];
        }
    }
    Console.WriteLine(difference);
