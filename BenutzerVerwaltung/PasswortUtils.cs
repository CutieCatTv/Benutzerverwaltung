using System;
using System.Linq;
using System.Text;

namespace BenutzerVerwaltung
{
    public static class PasswortUtils
    {
        private const string Content = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        static public string PasswortGenerieren()
        {
            StringBuilder stringBuilder = new StringBuilder();

            Random random = new Random();
            for (int i = 0; i < 10; i++)
                stringBuilder.Append(Content[random.Next(Content.Length)]);

            return stringBuilder.ToString();
        }

        static public string PasswortVerschlüsseltEinlesen()
        {
            string passwort = "";
            while (true)
            {
                var key = Console.ReadKey(true);
                if (Content.ToArray().Contains((key.KeyChar)))
                {
                    passwort += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Enter) { break; }
            }
            return passwort;
        }
    }
}
