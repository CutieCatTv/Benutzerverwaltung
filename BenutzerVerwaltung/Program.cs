using System;
using System.Collections.Generic;
using System.Linq;


namespace BenutzerVerwaltung
{
    class Program
    {
        public static string benutzerName;
        static bool passwortKorrekt = false;
        static bool benutzerNameKorrekt = false;
        public static string passwort;

        static void Main(string[] args)
        {
            Gruppen.ListenErstellen();
            Benutzer.BenutzerListeErstellen();
            Anmeldung();
            Gruppen.Aktionen();
        }

        static public void Anmeldung()
        {
            while (!passwortKorrekt)
            {
                Console.WriteLine("Bitte logg dich ein.");
                AnmeldungBenutzerName();
                AnmeldungPasswort();
            }
            Console.WriteLine("\nDu wurdest erfolgreich angemeldet");
        }

        static public void AnmeldungBenutzerName()
        {
            while (!benutzerNameKorrekt)
            {
                Console.WriteLine("\nBenutzername:");
                benutzerName = Console.ReadLine();

                if (Benutzer.benutzer.ContainsKey(benutzerName) == false)
                {
                    Console.WriteLine("\nBenutzername ist falsch.");

                }
                else { benutzerNameKorrekt = true; }
            }
        }

         static public void AnmeldungPasswort()
         {
            Benutzer.aktuellerBenutzer = Benutzer.benutzer[benutzerName];

            if (Benutzer.aktuellerBenutzer.IsNew == true)
            {
                Benutzer.aktuellerBenutzer.PasswortÄndern();
            }
            Console.WriteLine("\nPasswort:");

            PasswortVerschlüsseln();

            if (Benutzer.aktuellerBenutzer.Passwort != passwort)
            {
                Console.WriteLine("\nPasswort ist falsch.\n");
                benutzerNameKorrekt = false;
            }
            else { passwortKorrekt = true; }   
        }

        static public void PasswortVerschlüsseln()
      {
            string Content = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";          

            passwort = "";
            while (true)
            {
                var key = System.Console.ReadKey(true);
                if (Content.ToArray().Contains((key.KeyChar)))
                {
                    passwort += key.KeyChar;
                    Console.Write("*");
                }   
                else if(key.Key == ConsoleKey.Enter) { break; }
               
            }
        }
    }
}
