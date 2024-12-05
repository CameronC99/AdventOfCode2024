
class Day1
{
  public static void Run()
  {
    // Part 1
    var list1 = new List<int> { };
    var list2 = new List<int> { };

    string[] lines = File.ReadAllLines("Day1/Day1.txt");

    for (int i = 0; i < lines.Length; i++)
    {
      var splitStr = lines[i].Split("   ");
      list1.Add(Convert.ToInt32(splitStr[0]));
      list2.Add(Convert.ToInt32(splitStr[1]));
    }

    list1.Sort();
    list2.Sort();

    int distance = Day1.DistanceBetween(list1, list2);
    Console.WriteLine($"Distance: {distance}");

    // Part 2
    int similarityScore = Day1.GetSimilarityScore(list1, list2);
    Console.WriteLine($"Similarity Score: {similarityScore}");
  }

  private static int DistanceBetween(List<int> list1, List<int> list2)
  {
    int distance = 0;

    for (int i = 0; i < list1.Count; i++)
    {
      distance += Math.Abs(list1[i] - list2[i]);
    }

    return distance;
  }

  private static int GetSimilarityScore(List<int> list1, List<int> list2)
  {
    int similarityScore = 0;

    list1.ForEach(leftNum =>
      {
        var similarityCount = list2.Count(rightNum => rightNum == leftNum);
        similarityScore += similarityCount * leftNum;
      }
    );

    return similarityScore;
  }
}