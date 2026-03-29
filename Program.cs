using RandomThingsGenerator;

var passwordGenerator = new PasswordGenerator();

Print("PIN");
Print(passwordGenerator.PinGenerator(10));

Print("AlphaNumeric");
Print(passwordGenerator.AlphanumericGenerator(10));


void Print<T>(T value)
{
    Console.WriteLine(value);
}
