using RandomThingsGenerator;

var passwordGenerator = new PasswordGenerator();

/*Print("PIN");
Print(passwordGenerator.GeneratePin(10));

Print("AlphaNumeric");
Print(passwordGenerator.GenerateAlphanumeric(10));*/

Print("Phrase");
Print(passwordGenerator.GeneratePhrase(10));


void Print<T>(T value)
{
    Console.WriteLine(value);
}
