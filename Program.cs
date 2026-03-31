Print("PIN");
Print(PasswordGenerator.PasswordGenerator.GeneratePin(10));

Print("AlphaNumeric");
Print(PasswordGenerator.PasswordGenerator.GenerateAlphanumeric(10));

Print("Phrase");
Print(PasswordGenerator.PasswordGenerator.GeneratePhrase(10, '+'));


void Print<T>(T value)
{
    Console.WriteLine(value);
}
