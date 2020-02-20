using System;
using System.Collections.Generic;
using System.Linq;

namespace BenutzerVerwaltung
{
    public class BenutzerManager
    {
        private readonly Dictionary<string, Benutzer> benutzer = new Dictionary<string, Benutzer>();

        private readonly Gruppen gruppen = new Gruppen();

        private Benutzer aktuellerBenutzer;

        public Benutzer GetBenutzer(string benutzerName)
        {
            return benutzer[benutzerName];
        }

        public BenutzerManager()
        {
            benutzer.Add("Admin", new Benutzer("Admin", "admin1234", " ", " ", "Admin", false));
            benutzer.Add("Zoe", new Benutzer("Zoe", "zoe1234", "28.04.2001", "zoe@email.com", "User", false));
            benutzer.Add("z", new Benutzer("z", "zz", " ", " ", "Mod", false));
        }

        public void BenutzerListe()
        {
            Console.WriteLine("\nBenutzerliste:\n");
            foreach (var ben in benutzer.Keys.ToArray())
            {
                var benName = benutzer[ben].BenutzerName;
                Console.WriteLine("Benutzername: " + benName);
            }
        }

        public void InformationenÄndern(string benutzerName)
        {
            Benutzer zubearbeitenderBenutzer = benutzer[benutzerName];
            Console.WriteLine("\nWas möchtest du ändern?");
            Console.WriteLine("1: Benutzername  2: Passwort  3: Geburtsdatum  4: Email");

            int ändern = Convert.ToInt32(Console.ReadLine());

            switch (ändern)
            {
                case 1:
                    BenutzerNameÄndern(benutzerName);
                    break;
                case 2:
                    zubearbeitenderBenutzer.PasswortÄndern();
                    break;
                case 3:
                    zubearbeitenderBenutzer.GeburtsdatumÄndern();
                    break;
                case 4:
                    zubearbeitenderBenutzer.EmailÄndern();
                    break;
            }
        }

        public void BenutzerNameÄndern(string benutzerName)
        {
            Console.WriteLine("Jetziger Benutzername: " + benutzerName);
            Console.WriteLine("Neuer Benutzername: ");

            string benutzerNameNeu = Console.ReadLine();
            if (benutzerNameNeu == "" && benutzerNameNeu.Length <= 10)
            {
                Console.WriteLine("Der Benutzername darf nicht Nichts sein.");
            }
            string benutzerNameAlt = benutzerName;

            benutzer.Add(benutzerNameNeu, benutzer[benutzerName]);
            benutzer[benutzerNameNeu].BenutzerName = benutzerNameNeu;
            benutzer.Remove(benutzerNameAlt);

            Console.WriteLine("Benutzername wurde erfolgreich geändert.");
        }

        public void InformationenAbfragen(string benutzerName)
        {
            Console.WriteLine("\nAccountinformationen:");
            Console.WriteLine("\nBenutzername: " + benutzer[benutzerName].BenutzerName);
            Console.WriteLine("Geburtsdatum: " + benutzer[benutzerName].Geburtsdatum);
            Console.WriteLine("Email: " + benutzer[benutzerName].Email);
            Console.WriteLine("Gruppe: " + benutzer[benutzerName].Gruppe);
            Console.WriteLine(benutzer[benutzerName].Passwort);
        }

        public void NeueBenutzerAnlegen()
        {
            Console.WriteLine("Neue Benutzer wird angelegt.");
            Console.WriteLine("Benutzername:");
            string neuerBenutzerName = Console.ReadLine();

            string generiertesPasswort = PasswortUtils.PasswortGenerieren();
            Console.WriteLine("generiertes Passwort:");
            Console.WriteLine(generiertesPasswort);

            benutzer.Add(neuerBenutzerName, new Benutzer(neuerBenutzerName, generiertesPasswort, " ", " ", " ", true));
        }

        public void GruppenZuweisen()
        {
            Console.WriteLine("Welchem Benutzer möchten sie eine Gruppe zuweisen?");
            Console.WriteLine("Benutzername:");
            string benutzernameGruppe = Console.ReadLine();
            Console.WriteLine("\nAktuelle Gruppe: " + benutzer[benutzernameGruppe].Gruppe);
            Console.WriteLine("\nWelche Gruppe soll dem Benutzer zugwiesen werden?");
            Console.WriteLine("User   Mod   Admin");
            Console.WriteLine("\nEingabe:");
            benutzer[benutzernameGruppe].Gruppe = Console.ReadLine();
        }

        public void Aktionen()
        {
            bool nächsteAktion = true;
            while (nächsteAktion)
            {
                Console.WriteLine("\nWas möchtest du tun?\n");
                gruppen.RechteEinesBenutzers(aktuellerBenutzer);
                Console.WriteLine("\nEingabe:");
                int rechtAusführen = Convert.ToInt32(Console.ReadLine());
                string fremderBenutzer;

                switch (rechtAusführen)
                {
                    case 1:
                        InformationenAbfragen(aktuellerBenutzer.BenutzerName);
                        break;
                    case 2:
                        InformationenÄndern(aktuellerBenutzer.BenutzerName);
                        break;
                    case 3:
                        BenutzerListe();
                        break;
                    case 4:
                        Console.WriteLine("\nVon welchem Account möchtest du die Daten?");
                        Console.WriteLine("\nAccountname:");
                        fremderBenutzer = Console.ReadLine();

                        InformationenAbfragen(fremderBenutzer);
                        break;
                    case 5:
                        Console.WriteLine("Von welchem Account möchtest du die Daten ändern?");
                        Console.WriteLine("\nAccountname:");
                        fremderBenutzer = Console.ReadLine();

                        InformationenÄndern(fremderBenutzer);
                        break;
                    case 6:
                        NeueBenutzerAnlegen();
                        break;
                    case 7:
                        GruppenZuweisen();
                        break;
                    case 8:
                        gruppen.GruppenRechteZuweisen();
                        break;
                }
            }
        }

        public void Anmeldung()
        {
            bool success;
            do
            {
                Console.WriteLine("Bitte logg dich ein.");
                string benutzerName = AnmeldungBenutzerName();
                success = AnmeldungPasswort(benutzerName);
            } while (!success);
            Console.WriteLine("\nDu wurdest erfolgreich angemeldet");
        }

        private string AnmeldungBenutzerName()
        {
            while (true)
            {
                Console.WriteLine("\nBenutzername:");
                string benutzerName = Console.ReadLine();

                if (benutzer.ContainsKey(benutzerName))
                {
                    return benutzerName;
                }
                Console.WriteLine("\nBenutzername ist falsch.");
            }
        }

        private bool AnmeldungPasswort(string benutzerName)
        {
            aktuellerBenutzer = benutzer[benutzerName];

            if (aktuellerBenutzer.IsNew)
            {
                aktuellerBenutzer.PasswortÄndern();
            }
            Console.WriteLine("\nPasswort:");

            string passwort = PasswortUtils.PasswortVerschlüsseltEinlesen();

            if (aktuellerBenutzer.Passwort != passwort)
            {
                Console.WriteLine("\nPasswort ist falsch.\n");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
