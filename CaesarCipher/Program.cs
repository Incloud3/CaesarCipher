using System;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string continueProgram;
            Console.Write("Enter your key value: ");
            int key = Convert.ToInt32(Console.ReadLine());
            do
            {
                try
                {
                    Console.WriteLine("___________________");
                    Console.Write("Type 0 if you want to encrypt your message, type 1 if you want to decrypt your message: ");
                    int encryptionOrDecryption = Convert.ToInt32(Console.ReadLine());


                    if (encryptionOrDecryption == 0)
                    {
                        Console.WriteLine("___________________");
                        Console.Write("Type a string to encrypt with given key: ");
                        String userString = Console.ReadLine();

                        Console.WriteLine("Encrypted Data");
                        Console.WriteLine("___________________");

                        string cipherText = Encription(userString, key);
                        Console.WriteLine(cipherText);
                    }
                    else
                    {
                        Console.WriteLine("___________________");
                        Console.Write("Type a string to decrypt with given key: ");
                        String userString = Console.ReadLine();

                        Console.WriteLine("Decrypted Data:");
                        Console.WriteLine("___________________");

                        string cipherText = Decryption(userString, key);
                        Console.WriteLine(cipherText);
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.Write($"Enter \"Y\" for another operation: ");
                continueProgram = Console.ReadLine();
            } while (continueProgram == "y" || continueProgram == "Y");
        }

        public static char cipher(char ch, int key)
        {
            //Returning any special characters or numbers
            if (!char.IsLetter(ch))
            {
                return ch;
            }

            //Using ternary conditional operator to check if the char is uppercase then reutrn 'A' and 'a' if not
            char d = char.IsUpper(ch) ? 'A' : 'a';
            //Switching received char by given key while wrapping received char with modulo division
            return (char)((((ch + key) - d) % 26) + d);
        }
        public static string Encription(string input, int key)
        {
            //Initializing an empty string which will be updated with every char value
            string output = string.Empty;

            foreach (char ch in input)
                output += cipher(ch, key);

            return output;
        }
        public static string Decryption(string input, int key)
        {
            return Encription(input, 26 - key);
        }
    }
}