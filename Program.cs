using RandomThingsGenerator;

Print("PIN");
Print(PasswordGenerator.GeneratePin(10));

Print("AlphaNumeric");
Print(PasswordGenerator.GenerateAlphanumeric(10));

Print("Phrase");
Print(PasswordGenerator.GeneratePhrase(10, '+'));


void Print<T>(T value)
{
    Console.WriteLine(value);
}
