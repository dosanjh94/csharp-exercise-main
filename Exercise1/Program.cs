namespace exercise1;

public static class Program
{
    public static List<Output> OrderCharactersByPopularity(List<string> characterNames)
    {
        var nameCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        foreach (string name in characterNames)
        {
            if (nameCounts.ContainsKey(name))
            {
                nameCounts[name]++;
            }
            else
            {
                nameCounts[name] = 1;
            }
        }

        var sortedNames = nameCounts
            .OrderByDescending(entry => entry.Value)
            .ThenBy(entry => entry.Key)
            .ThenBy(entry => ExtractNumber(entry.Key))
            .Select(entry => new Output(entry.Key, entry.Value))
            .ToList();

        return sortedNames;
    }

    private static int ExtractNumber(string name)
    {
        var numberString = new string(name.SkipWhile(c => !char.IsDigit(c)).TakeWhile(char.IsDigit).ToArray());
        int.TryParse(numberString, out int number);
        return number;
    }
}