using System.Text.RegularExpressions;

class Day4
{
  const string pattern = @"(?=XMAS)|(?=SAMX)";
  public static void Run()
  {
    string[] input = File.ReadAllLines("Day4/Day4Small.txt");

    List<string> horizontalLines = input.ToList();
    int horizontalCount = Day4.GetMatchCount(horizontalLines);

    List<string> verticalLines = GetVerticalLinesFromHorizontal(horizontalLines);
    int verticalCount = Day4.GetMatchCount(verticalLines);

    // TODO: Diagnal






    Console.WriteLine($"Horizontal count: {horizontalCount}");
    Console.WriteLine($"Horizontal count: {verticalCount}");
    Console.WriteLine($"Total count: {horizontalCount + verticalCount}");

  }

  private static int GetMatchCount(List<string> input)
  {
    int count = 0;
    foreach (string line in input)
    {
      count += Day4.MatchCount(line);
    }
    return count;
  }

  private static List<string> GetVerticalLinesFromHorizontal(List<string> horizontalLines)
  {
    List<string> verticalLines = Enumerable.Repeat("", horizontalLines.Count).ToList();

    foreach (string line in horizontalLines)
    {
      for (int i = 0, n = line.Length; i < n; i++)
      {
        verticalLines[i] += line[i];
      }
    }

    return verticalLines;
  }

  private static int MatchCount(string input)
  {
    var matches = Regex.Matches(input, pattern);
    int count = matches.Count();
    return count;
  }






}