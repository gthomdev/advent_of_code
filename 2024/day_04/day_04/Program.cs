string filePath = "C:\\Users\\georg\\source\\repos\\advent_of_code\\2024\\day_04\\day_04\\input.txt"; //never doing it smarter than this
string[] griddy; //copypasta the file read bit for every day become ungovernable

try
{
    griddy = File.ReadAllLines(filePath);
}
catch (Exception)
{
    Console.WriteLine("didn't work m8");
    return;
}

string xmas = "XMAS";
int count = CountXmases(griddy, xmas);
Console.WriteLine(count.ToString());
    
static int CountXmases(string[] grid, string word)
{
    int rows = grid.Length;
    int cols = grid[0].Length;
    int count = 0;

    int[] dx = { 0, 1, 1, 1, 0, -1, -1, -1 }; 
    int[] dy = { 1, 0, 1, -1, -1, 0, 1, -1 };

    // get nesty with it
    for (int row = 0; row < rows; row++)
    {
        // this little manoeuvre
        for (int col = 0; col < cols; col++)
        { 
            // is gonna cost us
            for (int dir = 0; dir < 8; dir++)
            {
                // 51 years
                bool isMatch = true;
                int x = row, y = col;

                for (int charIndex = 0; charIndex < word.Length; charIndex++)
                {
                    if (x < 0 || x >= rows || y < 0 || y >= cols || grid[x][y] != word[charIndex]) // im 5 levels deep come at me uncle bob 👊👊
                    {
                        isMatch = false;
                        break;
                    }
                    x += dx[dir];
                    y += dy[dir];
                }
                if (isMatch)
                {
                    count++;
                }
            }
        }
    }
    return count;
}
