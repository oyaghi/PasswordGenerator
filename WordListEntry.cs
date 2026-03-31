using CsvHelper.Configuration.Attributes;

namespace PasswordGenerator;

public class WordListEntry
{
    [Index(1)]
    public string Word { get; set; } = null!;
}