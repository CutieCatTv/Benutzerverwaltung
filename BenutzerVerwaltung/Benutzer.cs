using System;

namespace BenutzerVerwaltung
{
    public class Benutzer
    {
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
            bool altesPasswortRichtig = false;
            bool neuesPasswortRichtig = false;
            bool neuesPasswortWdhRichtig = false;
            string passwort;
            string neuesPasswort = "";

            while (!altesPasswortRichtig)
            {
                Console.WriteLine("Altes Passwort:");
                passwort = PasswortUtils.PasswortVerschlüsseltEinlesen();
                if (passwort != Passwort)
                {
                    Console.WriteLine("\nDas eingegebene Passwort ist nicht korrekt");
                }
                else { altesPasswortRichtig = true; }
            }

            while (!neuesPasswortWdhRichtig)
            {
                while (!neuesPasswortRichtig)
                {
                    Console.WriteLine("\nNeues Passwort: ");
                    passwort = PasswortUtils.PasswortVerschlüsseltEinlesen();
                    neuesPasswort = passwort;
                    if (passwort.Length < 6 || passwort.Length > 10)
                    {
                        Console.WriteLine("\nDas Passwort muss zwischen 6 und 10 Zeichen sein.");
                    }
                    else { neuesPasswortRichtig = true; }
                }

                Console.WriteLine("\nNeues Passwort wiederholen: ");
                passwort = PasswortUtils.PasswortVerschlüsseltEinlesen();

                if (neuesPasswort != passwort)
                {
                    Console.WriteLine("\nDie beiden Passwörter stimmen nicht überein.");
                    neuesPasswortRichtig = false;
                }
                else 
                {
                    neuesPasswortRichtig = true;
                    Passwort = passwort;
                }
            }
        }

        public void GeburtsdatumÄndern()
        {
            bool neuesGeburtsdatumRichtig = false;
            string geburtsdatumNeu = "";
            while (!neuesGeburtsdatumRichtig)
            {
                Console.WriteLine("Jetziges Geburtsdatum: " + Geburtsdatum);
                Console.WriteLine("Neues Geburtsdatum: ");
                geburtsdatumNeu = Console.ReadLine();
                neuesGeburtsdatumRichtig = GeburtsdatumUtils.isDateValid(geburtsdatumNeu);          
            }
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

