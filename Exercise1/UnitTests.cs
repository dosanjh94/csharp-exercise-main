using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace exercise1;

public class UnitTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public UnitTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void ArrayFilteringMappingAndSortingMethod()
    {
        using var r = new StreamReader("./names.json");
        var json = r.ReadToEnd();
        var characterNames = JsonConvert.DeserializeObject<List<string>>(json);

        var expectedResult = new List<Output>
        {
            new("Audrey II", 4),
            new("Emmett Brown", 4),
            new("Alex Murphy", 3),
            new("Ace Ventura", 2),
            new("Jack Slater", 2),
            new("007", 1),
            new("Bob", 1),
            new("Inspector Clouseau", 1),
            new("Stanley Ipkiss", 1)
        };

        var names = Program.OrderCharactersByPopularity(characterNames!);

        Assert.True(names.SequenceEqual(expectedResult));
    }
}