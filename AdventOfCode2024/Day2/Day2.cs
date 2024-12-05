class Day2
{
  public static void Run()
  {
    // Part 1
    int safeCount = 0;
    string[] lines = File.ReadAllLines("Day2/Day2.txt");

    for (int i = 0, n = lines.Length; i < n; i++)
    {
      List<int> report = lines[i].Split(" ").ToList<string>().ConvertAll(str => Convert.ToInt32(str));
      if (IsReportSafe(report))
      {
        safeCount++;
      }
    }

    Console.WriteLine($"Safe count: {safeCount}");

    List<int> nums = new List<int>();
    nums = [1, 2, 3, 4, 55, 6];
    Console.WriteLine($"DangerCount: {Day2.AreAdjacentLevelsAcceptableWithDampner(nums).dangerCount}");

    // TODO: Part 2

  }

  /// <summary>
  /// Determine if a report is safe bt the following conditions:
  /// - The levels are either all increasing or all decreasing.
  ///   AND
  /// - Any two adjacent levels differ by at least one and at most three.
  /// </summary>
  /// <param name="report">Report which contains different levels.</param>
  /// <returns>Boolean value stating if the report is safe or not.</returns>
  private static bool IsReportSafe(List<int> report)
  {
    if (IsReportDescending(report) == false && IsReportAscending(report) == false)
    {
      return false;
    }

    return AreAdjacentLevelsAcceptable(report);
  }

  private static bool IsReportAscending(List<int> report)
  {
    for (int i = 0, n = report.Count - 1; i < n; i++)
    {
      if (report[i] > report[i + 1])
      {
        return false;
      }
    }

    return true;
  }

  private static bool IsReportDescending(List<int> report)
  {
    for (int i = 0, n = report.Count - 1; i < n; i++)
    {
      if (report[i] < report[i + 1])
      {
        return false;
      }
    }

    return true;
  }

  private static bool AreAdjacentLevelsAcceptable(List<int> report)
  {
    for (int i = 0, n = report.Count - 1; i < n; i++)
    {
      var difference = Math.Abs(report[i] - report[i + 1]);
      if (difference < 1 || difference > 3)
      {
        return false;
      }
    }

    return true;
  }

  private static (bool isSafe, int dangerCount) AreAdjacentLevelsAcceptableWithDampner(List<int> report)
  {
    // TODO: Not Completed
    int dangerCount = 0;
    for (int i = 0, n = report.Count - 1; i < n; i++)
    {
      var difference = Math.Abs(report[i] - report[i + 1]);
      if (difference < 1 || difference > 3)
      {
        dangerCount++;
      }
    }

    return (dangerCount <= 1, dangerCount);
  }

}