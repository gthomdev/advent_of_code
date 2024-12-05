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
int count = CountXmasPatterns(griddy);
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

static bool IsXmas(string[] grid, int startingRow, int startingColumn)
//---------------------
//
//   M S    M M    S S 
//    A      A      A
//   M S    S S    M M 
//
//---------------------

{
    char topLeft = grid[startingRow][startingColumn];                 
    char topRight = grid[startingRow][startingColumn + 2];                            
    char center = grid[startingRow + 1][startingColumn + 1];
    char bottomLeft = grid[startingRow + 2][startingColumn];
    char bottomRight = grid[startingRow + 2][startingColumn + 2];

    bool masmas = (topLeft == 'M' && center == 'A' && bottomRight == 'S' &&     // TL/BR MAS
                   topRight == 'M' && center == 'A' && bottomLeft == 'S');      // TR/BL MAS
    bool massam = (topLeft == 'M' && center == 'A' && bottomRight == 'S' &&     // TL/BR MAS
                       topRight == 'S' && center == 'A' && bottomLeft == 'M');  // TR/BL SAM
    bool sammas = (topLeft == 'S' && center == 'A' && bottomRight == 'M' &&     // TL/BR SAM
                       topRight == 'M' && center == 'A' && bottomLeft == 'S');  // TR/BL SAM
    bool samsam = (topLeft == 'S' && center == 'A' && bottomRight == 'M' &&     // TL/BR SAM
                       topRight == 'S' && center == 'A' && bottomLeft == 'M');  // TR/BL SAM
    
    return (masmas || massam || sammas || samsam); //embrace the grossness
}

static int CountXmasPatterns(string[] grid)
{
    int rows = grid.Length;
    int cols = grid[0].Length;
    int count = 0;

    // Iterate over every possible 3x3 region in the grid
    for (int row = 0; row <= rows - 3; row++)
    {
        for (int col = 0; col <= cols - 3; col++)
        {
            // Check for the X-MAS pattern in this 3x3 region
            if (IsXmas(grid, row, col))
            {
                count++;
            }
        }
    }
    return count;
}