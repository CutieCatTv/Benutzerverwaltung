using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BenutzerVerwaltung
{
    class Benutzer
    {
        public static Dictionary<string, Benutzer> benutzer = new Dictionary<string, Benutzer>();

        public bool weiterAltesPasswort;
        private bool weiterNeuesPasswortWdh;
        public static bool weiterNeuesPasswort;
        public static string neuesPasswort;

        static string generiertesPasswort;

        public static Benutzer aktuellerBenutzer;

        private string benutzerName;
        private string passwort;
        private string geburtsdatum;
        private string email;
        private string gruppe;

        public string BenutzerName
        {
            get { return benutzerName; }
            set { benutzerName = value; }
        }
        public string Passwort
        {
            get { return passwort; }
            set { passwort = value; }
        }
        public string Geburtsdatum
        {
            get { return geburtsdatum; }
            set { geburtsdatum = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Gruppe
        {
            get { return gruppe; }
            set { gruppe = value; }
        }
        public bool Modified { get; set; }

        private bool isNew;

        public bool IsNew
        {
            get { return isNew; }

            set
            {
                if (isNew != value)
                {
                    Modified = true;
                    isNew = value;
                }
            }
        }

        public Benutzer(string benutzerName, string passwort, string geburtsdatum, string email, string gruppe, bool isNew)
        {
            this.benutzerName = benutzerName;
            this.passwort = passwort;
            this.geburtsdatum = geburtsdatum;
            this.email = email;
            this.gruppe = gruppe;
            this.isNew = isNew;
        }

        static public void BenutzerListeErstellen()
        {
            benutzer.Add("Admin", new Benutzer("Admin", "admin1234", " ", " ", "Admin", false));
            benutzer.Add("Zoe", new Benutzer("Zoe", "zoe1234", "28.04.2001", "zoe@email.com", "User", false));
            benutzer.Add("z", new Benutzer("z", "zz", " ", " ", "Mod", false));
        }

        public void InformationenAbfragen()
        {
            Console.WriteLine("\nAccountinformationen:");
            Console.WriteLine("\nBenutzername: " + benutzer[BenutzerName].BenutzerName);
            Console.WriteLine("Geburtsdatum: " + benutzer[BenutzerName].Geburtsdatum);
            Console.WriteLine("Email: " + benutzer[BenutzerName].Email);
            Console.WriteLine("Gruppe: " + benutzer[BenutzerName].Gruppe);
            Console.WriteLine(benutzer[BenutzerName].Passwort);
        }

        public void InformationenÄndern()
        {
            Console.WriteLine("\nWas möchtest du ändern?");
            Console.WriteLine("1: Benutzername  2: Passwort  3: Geburtsdatum  4: Email");
            
            int ändern = Convert.ToInt32(Console.ReadLine());

            switch(ändern)
            {
                case 1:
                    BenutzerNameÄndern();
                    break;
                case 2:
                    PasswortÄndern();
                    break;
                case 3:
                    GeburtsdatumÄndern();
                    break;
                case 4:
                    EmailÄndern();
                    break;
            }
        }

        public void BenutzerNameÄndern()
        {
            Console.WriteLine("Jetziger Benutzername: " + benutzerName);
            Console.WriteLine("Neuer Benutzername: ");

            string benutzerNameNeu = Console.ReadLine();
            if(benutzerNameNeu == "" && benutzerNameNeu.Length <= 10)
            {
                Console.WriteLine("Der Benutzername darf nicht Nichts sein.");
            }
            string benutzerNameAlt = benutzerName;

            benutzer.Add(benutzerNameNeu, benutzer[benutzerName]);
            benutzer[benutzerNameNeu].benutzerName = benutzerNameNeu;
            benutzer.Remove(benutzerNameAlt);
            Program.benutzerName = benutzerNameNeu;

            Console.WriteLine("Benutzername wurde erfolgreich geändert.");
        }

        public void PasswortÄndern()
        {
            weiterAltesPasswort = false;
            weiterNeuesPasswortWdh = false;
            weiterNeuesPasswort = false;

            while (!weiterAltesPasswort)
            {
                Console.WriteLine("Altes Passwort:");
                Program.PasswortVerschlüsseln();
                if (Program.passwort != passwort)
                {
                    Console.WriteLine("\nDas eingegebene Passwort ist nicht korrekt");
                }
                else { weiterAltesPasswort = true; }
            }

            while(!weiterNeuesPasswortWdh)
            {
                while (!weiterNeuesPasswort)
                {
                    Console.WriteLine("\nNeues Passwort: ");
                    Program.PasswortVerschlüsseln();
                    neuesPasswort = Program.passwort;
                    if (Program.passwort.Length < 6 || Program.passwort.Length > 10)
                    {
                        Console.WriteLine("\nDas Passwort muss zwischen 6 und 10 Zeichen sein.");
                    }
                    else { weiterNeuesPasswort = true; }
                }

                Console.WriteLine("\nNeues Passwort wiederholen: ");
                Program.PasswortVerschlüsseln();
                benutzer[BenutzerName].Passwort = Program.passwort;

                if (Benutzer.neuesPasswort != Program.passwort)
                {
                    Console.WriteLine("\nDie beiden Passwörter stimmen nicht überein.");
                    weiterNeuesPasswort = false;
                }
                else { weiterNeuesPasswortWdh = true; }
            }            
        }

        public void GeburtsdatumÄndern()
        {
            Console.WriteLine("Jetziges Geburtsdatum: " + geburtsdatum);
            Console.WriteLine("Neues Geburtsdatum: ");
            string geburtsdatumNeu = Console.ReadLine();
            benutzer[BenutzerName].Geburtsdatum = geburtsdatumNeu;
        }

        public void EmailÄndern()
        {
            Console.WriteLine("Jetzige Email: " + email);
            Console.WriteLine("Neue Email: ");
            string emailNeu = Console.ReadLine();
            benutzer[BenutzerName].Email = emailNeu;
        }

        static public void BenutzerListe()
        {
            Console.WriteLine("\nBenutzerliste:\n");
            foreach (var ben in benutzer.Keys.ToArray())
            {
                var benName = benutzer[ben].BenutzerName;
                Console.WriteLine("Benutzername: " + benName);
            }
        }

        static public void NeueBenutzerAnlegen()
        {
            Console.WriteLine("Neue Benutzer wird angelegt.");
            Console.WriteLine("Benutzername:");
            string neuerBenutzerName = Console.ReadLine();

            PasswortGenerieren();
            Console.WriteLine("generiertes Passwort:");
            Console.WriteLine(generiertesPasswort);

            benutzer.Add(neuerBenutzerName, new Benutzer(neuerBenutzerName, generiertesPasswort, " ", " ", " ", true));
        }

        static public void PasswortGenerieren()
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            string Content = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            Random random = new Random();
            for (int i = 0; i < 10; i++)
                stringBuilder.Append(Content[random.Next(Content.Length)]);

            generiertesPasswort = stringBuilder.ToString();
        }

        static public void GruppenZuweisen()
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

        static public void GruppenRechteZuweisen()
        {
            int i = 1;
            Console.WriteLine("Alle Rechte:");
            foreach (string key in Gruppen.alleRechte.Keys)
            {
                Console.WriteLine(i + ": " + key);
                i++;
            }
            Console.WriteLine("\nZu welcher Gruppe möchten sie ein Recht hinzufügen?");
            Console.WriteLine("\n1: User   2: Mod    3: Admin");
            Console.WriteLine("Eingabe:");
            int gruppe = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nWelches Recht möchten sie dieser Gruppe zuweisen?");
            Console.WriteLine("Eingabe:");
            int recht = Convert.ToInt32(Console.ReadLine())-1;

            switch(gruppe)
            {
                case 1:
                    Gruppen.userRechte.Add(Gruppen.alleRechte.ElementAt(recht).Key);
                    break;
                case 2:
                    Gruppen.modRechte.Add(Gruppen.alleRechte.ElementAt(recht).Key);
                    break;
                case 3:
                    Gruppen.adminRechte.Add(Gruppen.alleRechte.ElementAt(recht).Key);
                    break;
            }
        }
    }
}

