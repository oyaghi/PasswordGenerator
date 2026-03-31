using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace RandomThingsGenerator;

public class PasswordGenerator
{
    private readonly List<char> _nums = Enumerable.Range('0', 10).Select(c => (char)c).ToList();
    private readonly List<char> _smallLetters = Enumerable.Range('a', 26).Select(c => (char)c).ToList();
    private readonly List<char> _capitalLetters = Enumerable.Range('A', 26).Select(c => (char)c).ToList();
    private readonly List<char> _symbols = ['!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '-', '=', '{', '}', '[', ']', '|', ';', ':', '"', '\'', '<', '>', ',', '.', '?', '/', '`'];

    /// <summary>
    /// Generates a numeric PIN of the specified length.
    /// </summary>
    /// <param name="length">The length of the PIN to generate.</param>
    /// <returns>A string containing the generated numeric PIN.</returns>
    public string GeneratePin(int length)
    {
        var password = new StringBuilder();

        for (int i = 0; i < length; i++)
        {
            var rndIndex = RandomNumberGenerator.GetInt32(0, _nums.Count);
            password.Append(_nums[rndIndex]);
        }

        return password.ToString();
    }

    /// <summary>
    /// Generates an alphanumeric string of the specified length, including letters, numbers, and symbols.
    /// </summary>
    /// <param name="length">The length of the alphanumeric string to generate.</param>
    /// <returns>A string containing the generated alphanumeric sequence.</returns>
    public string GenerateAlphanumeric(int length)
    {
        var password = new StringBuilder();
        var letters = _smallLetters.Concat(_capitalLetters);
        var alphanumeric = letters.Concat(_symbols).Concat(_nums).ToList();

        for (int i = 0; i < length; i++)
        {
            var rndIndex = RandomNumberGenerator.GetInt32(0, alphanumeric.Count);
            password.Append(alphanumeric[rndIndex]);
        }

        return password.ToString();
    }

    public string GeneratePhrase(int length)
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
            var randomIndex = RandomNumberGenerator.GetInt32(0, 7776);

            password.Append(records[randomIndex].Word);
            password.Append("-");
        }

        return password.ToString().TrimEnd('-');
    }
}