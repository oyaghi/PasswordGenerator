# 🔐 Password Generator

A cryptographically secure password and passphrase generator written in C#. Uses `RandomNumberGenerator` for all randomness, ensuring generated passwords are unpredictable and safe for real-world use.

## Features

- **PIN Generator** — numeric PINs of any length
- **Alphanumeric Generator** — passwords using uppercase, lowercase, numbers, and symbols
- **Passphrase Generator** — human-readable passphrases from the [EFF large wordlist](https://www.eff.org/deeplinks/2016/07/new-wordlists-random-passphrases), separated by a customizable character

## Usage

Since `PasswordGenerator` is a static class, no instantiation is needed:

```csharp
// Generate a 6-digit PIN
string pin = PasswordGenerator.GeneratePin(6);
// e.g. "482910"

// Generate a 16-character alphanumeric password
string password = PasswordGenerator.GenerateAlphanumeric(16);
// e.g. "k#9Lz!Qm2@Xv$rN1"

// Generate a 5-word passphrase (default separator: '-')
string passphrase = PasswordGenerator.GeneratePhrase(5, "eff_large_wordlist.csv");
// e.g. "correct-horse-battery-staple-river"

// Generate a passphrase with a custom separator
string passphrase = PasswordGenerator.GeneratePhrase(5, "eff_large_wordlist.csv", separator: '.');
// e.g. "correct.horse.battery.staple.river"
```

## Requirements

- [.NET 8+](https://dotnet.microsoft.com/download)
- [CsvHelper](https://joshclose.github.io/CsvHelper/) NuGet package

## Installation

```bash
git clone https://github.com/oyaghi/PasswordGenerator.git
cd PasswordGenerator
dotnet restore
dotnet run
```

## Why Cryptographically Secure?

This project uses `System.Security.Cryptography.RandomNumberGenerator` instead of `System.Random`. Unlike `System.Random`, which is seeded by time and can be predicted, `RandomNumberGenerator` draws entropy from the operating system itself — making the output genuinely unpredictable even if an attacker knows when the password was generated.

## License

MIT
