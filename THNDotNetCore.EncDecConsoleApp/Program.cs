using Effortless.Net.Encryption;

byte[] key = Bytes.GenerateKey();
byte[] iv = Bytes.GenerateIV();
string encrypted = Strings.Encrypt("Secret", key, iv);
string decrypted = Strings.Decrypt(encrypted, key, iv);

Console.WriteLine("Key: "+key.ToString());
Console.WriteLine("iv: " + iv.ToString());
Console.WriteLine(encrypted);
Console.WriteLine(decrypted);