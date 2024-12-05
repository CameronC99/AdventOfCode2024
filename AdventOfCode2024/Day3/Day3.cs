using System.Text.RegularExpressions;

// https://adventofcode.com/2024/day/3
class Day3
{
  const string pattern = @"mul\([0-9]+,[0-9]+\)";
  const string commandPattern = @"(mul\([0-9]+,[0-9]+\))|(do\(\))|(don\'t\(\))";
  public static void Run()
  {
    // Part 1
    string input = File.ReadAllText("Day3/Day3.txt");

    var (operand1, operand2) = Day3.GetIntListFromString(input);

    int sumofProducts = Day3.GetSumOfProducts(operand1, operand2);
    Console.WriteLine($"Sum of Products: {sumofProducts}");

    // Part 2
    // Injest all the commands that match mul pattern or do() or don't()
    // As we go through list of commands, disable inserting into int list of dont, enable if do
    var (operandCommand1, operandCommand2) = Day3.GetIntListFromStringWithCommands(input);

    int sumOfProductsWithCommands = Day3.GetSumOfProducts(operandCommand1, operandCommand2);
    Console.WriteLine($"Sum of Products Using Commands: {sumOfProductsWithCommands}");
  }

  private static int GetSumOfProducts(List<int> operand1, List<int> operand2)
  {
    var product = operand1.Zip(operand2, (first, second) => first * second);
    return product.Sum();
  }

  // MARK: Part 1 Functions
  private static (List<int> list1, List<int> list2) GetIntListFromString(string input)
  {
    var matchList = Day3.GetMulStringsFromString(input);
    List<int> list1 = new List<int>();
    List<int> list2 = new List<int>();

    foreach (var match in matchList)
    {
      list1.Add(Convert.ToInt32(match.Split(['(', ',', ')'])[1])); // Takes left number
      list2.Add(Convert.ToInt32(match.Split(['(', ',', ')'])[2])); // Takes right number
    }

    return (list1, list2);
  }

  private static List<string> GetMulStringsFromString(string input)
  {
    var matches = Regex.Matches(input, pattern); // Get matches from the string using the pattern for mul(xx,xx)
    var matchList = matches.Cast<Match>().Select(match => match.Value).ToList(); // Convert into a List<string>?
    return matchList;
  }

  // MARK: Part 2 Functions

  private static (List<int> list1, List<int> list2) GetIntListFromStringWithCommands(string input)
  {
    var commands = Day3.GetCommandsFromString(input);
    List<int> list1 = new List<int>();
    List<int> list2 = new List<int>();
    bool included = true;

    foreach (var command in commands)
    {
      if (command == "do()")
      {
        included = true;
      }
      else if (command == "don't()")
      {
        included = false;
      }
      else
      {
        if (included)
        {
          list1.Add(Convert.ToInt32(command.Split(['(', ',', ')'])[1])); // Takes left number
          list2.Add(Convert.ToInt32(command.Split(['(', ',', ')'])[2])); // Takes right number
        }
      }
    }

    return (list1, list2);
  }

  private static List<string> GetCommandsFromString(string input)
  {
    var matches = Regex.Matches(input, commandPattern); // Get matches from the string using the pattern for mul(xx,xx)
    var matchList = matches.Cast<Match>().Select(match => match.Value).ToList(); // Convert into a List<string>?
    return matchList;
  }
}