using CsvHelper.Configuration.Attributes;

namespace RandomThingsGenerator;

public class WordListEntry
{
    [Index(1)]
    public string Word { get; set; } = null!;
}