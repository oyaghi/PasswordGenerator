namespace RandomThingsGenerator;

public class PasswordGenerator
{
    /*
     PINs (numeric only)
     Passphrases (long, memorable phrases)
     Alphanumeric (letters/numbers/symbols)
     */

    private readonly List<char> _nums = ['1', '2', '3', '4', '5', '6', '7', '8', '9', '0'];
    private readonly List<char> _symbols = ['!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '-', '=', '{', '}', '[', ']', '|', ';', ':', '"', '\'', '<', '>', ',', '.', '?', '/', '`'];
    private readonly List<char> _smallLetters = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'];
    private readonly List<char> _capitalLetters = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'];    private Random _random = new Random();

    public string PinGenerator(int length)
    {
        var password = "";

        for (int i = 0; i < length; i++)
        {
            var rndIndex = _random.Next(0, _nums.Count);
            password += _nums[rndIndex];
        }

        return password;
    }

    public string AlphanumericGenerator(int length)
    {
        var password = "";
        var letters = _smallLetters.Concat(_capitalLetters);
        var alphanumeric = letters.Concat(_symbols).Concat(_nums).ToList();

        for (int i = 0; i < length; i++)
        {
            var rndIndex = _random.Next(0, alphanumeric.Count);
            password += alphanumeric[rndIndex];
        }

        return password;
    }


}