using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace RandomThingsGenerator;

public static class PasswordGenerator
{
    private static readonly List<char> Nums = Enumerable.Range('0', 10).Select(c => (char)c).ToList();
    private static readonly List<char> AllChars =
    [
        .. Nums
            .Concat(Enumerable.Range('A', 26).Select(c => (char)c))
            .Concat(Enumerable.Range('a', 26).Select(c => (char)c))
            .Concat(['!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '-', '=', '{', '}', '[', ']', '|', ';', ':', '"', '\'', '<', '>', ',', '.', '?', '/', '`'])
    ];

    /// <summary>
    /// Generates a numeric PIN of the specified length.
    /// </summary>
    /// <param name="length">The length of the PIN to generate.</param>
    /// <returns>A string containing the generated numeric PIN.</returns>
    public static string GeneratePin(int length)
    {
        var password = new StringBuilder();

        for (int i = 0; i < length; i++)
        {
            var rndIndex = RandomNumberGenerator.GetInt32(0, Nums.Count);
            password.Append(Nums[rndIndex]);
        }

        return password.ToString();
    }

    /// <summary>
    /// Generates an alphanumeric string of the specified length, including letters, numbers, and symbols.
    /// </summary>
    /// <param name="length">The length of the alphanumeric string to generate.</param>
    /// <returns>A string containing the generated alphanumeric sequence.</returns>
    public static string GenerateAlphanumeric(int length)
    {
        var password = new StringBuilder();

        for (int i = 0; i < length; i++)
        {
            var rndIndex = RandomNumberGenerator.GetInt32(0, AllChars.Count);
            password.Append(AllChars[rndIndex]);
        }

        return password.ToString();
    }

    /// <summary>
    /// Generates a phrase consisting of random words separated by a specified character.
    /// </summary>
    /// <param name="length">The number of words to include in the generated phrase.</param>
    /// <param name="separator">The character used to separate the words in the phrase. Defaults to a space character.</param>
    /// <returns>A string representing the generated phrase with the specified number of words and separator.</returns>
    public static string GeneratePhrase(int length, char separator = ' ')
    {
        var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = "\t",
        };

        using var streamReader = new StreamReader("eff_large_wordlist.csv");
        using var csv = new CsvReader(streamReader, csvConfig);

        var records = csv.GetRecords<WordListEntry>().ToList();
        var password = new StringBuilder();

        for (int i = 0; i < length; i++)
        {
            var randomIndex = RandomNumberGenerator.GetInt32(0, records.Count);

            password.Append(records[randomIndex].Word);
            password.Append(separator);
        }

        return password.ToString().TrimEnd(separator);
    }
}