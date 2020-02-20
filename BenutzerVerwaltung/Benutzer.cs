using System;

namespace BenutzerVerwaltung
{
    public class Benutzer
    {
        public bool weiterAltesPasswort;

        public string BenutzerName { get; set; }
        public string Passwort { get; set; }
        public string Geburtsdatum { get; set; }
        public string Email { get; set; }
        public string Gruppe { get; set; }
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
            this.BenutzerName = benutzerName;
            this.Passwort = passwort;
            this.Geburtsdatum = geburtsdatum;
            this.Email = email;
            this.Gruppe = gruppe;
            this.isNew = isNew;
        }

        public void PasswortÄndern()
        {
            bool weiterAltesPasswort = false;
            bool weiterNeuesPasswortWdh = false;
            bool weiterNeuesPasswort = false;
            string passwort;
            string neuesPasswort = "";

            while (!weiterAltesPasswort)
            {
                Console.WriteLine("Altes Passwort:");
                passwort = PasswortUtils.PasswortVerschlüsseltEinlesen();
                if (passwort != Passwort)
                {
                    Console.WriteLine("\nDas eingegebene Passwort ist nicht korrekt");
                }
                else { weiterAltesPasswort = true; }
            }

            while (!weiterNeuesPasswortWdh)
            {
                while (!weiterNeuesPasswort)
                {
                    Console.WriteLine("\nNeues Passwort: ");
                    passwort = PasswortUtils.PasswortVerschlüsseltEinlesen();
                    neuesPasswort = passwort;
                    if (passwort.Length < 6 || passwort.Length > 10)
                    {
                        Console.WriteLine("\nDas Passwort muss zwischen 6 und 10 Zeichen sein.");
                    }
                    else { weiterNeuesPasswort = true; }
                }

                Console.WriteLine("\nNeues Passwort wiederholen: ");
                passwort = PasswortUtils.PasswortVerschlüsseltEinlesen();
                Passwort = passwort;

                if (neuesPasswort != passwort)
                {
                    Console.WriteLine("\nDie beiden Passwörter stimmen nicht überein.");
                    weiterNeuesPasswort = false;
                }
                else { weiterNeuesPasswortWdh = true; }
            }
        }

        public void GeburtsdatumÄndern()
        {
            Console.WriteLine("Jetziges Geburtsdatum: " + Geburtsdatum);
            Console.WriteLine("Neues Geburtsdatum: ");
            string geburtsdatumNeu = Console.ReadLine();
            Geburtsdatum = geburtsdatumNeu;
        }

        public void EmailÄndern()
        {
            Console.WriteLine("Jetzige Email: " + Email);
            Console.WriteLine("Neue Email: ");
            string emailNeu = Console.ReadLine();
            Email = emailNeu;
        }
    }
}

