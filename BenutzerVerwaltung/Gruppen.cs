using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BenutzerVerwaltung
{
    public class Gruppen
    {
        public List<string> userRechte = new List<string>();
        public List<string> modRechte = new List<string>();
        public List<string> adminRechte = new List<string>();

        public Dictionary<string, string> alleRechte = new Dictionary<string, string>();

        public Gruppen()
        {
            userRechte.Add("InfosAbfragen");
            userRechte.Add("InfosÄndern");
            userRechte.Add("BenutzerListe");

            modRechte.Add("InfosAbfragen");
            modRechte.Add("InfosÄndern");
            modRechte.Add("BenutzerListe");
            modRechte.Add("InfosAndererAccountsAbfragen");
            modRechte.Add("InfosAndererAccountsÄndern");

            adminRechte.Add("InfosAbfragen");
            adminRechte.Add("InfosÄndern");
            adminRechte.Add("BenutzerListe");
            adminRechte.Add("InfosAndererAccountsAbfragen");
            adminRechte.Add("InfosAndererAccountsÄndern");
            adminRechte.Add("NeueBenutzerAnlegen");
            adminRechte.Add("BenutzernGruppenZuweisen");
            adminRechte.Add("GruppenRechteZuweisen");

            alleRechte.Add("InfosAbfragen", "1: Information zum Account abfragen");
            alleRechte.Add("InfosÄndern", "2: Informationen des Accounts ändern");
            alleRechte.Add("BenutzerListe", "3: Liste aller Benutzer abfragen");
            alleRechte.Add("InfosAndererAccountsAbfragen", "4: Information eines anderen Account abfragen");
            alleRechte.Add("InfosAndererAccountsÄndern", "5: Information eines anderen Accounts ändern");
            alleRechte.Add("NeueBenutzerAnlegen", "6: Neue Benutzer anlegen");
            alleRechte.Add("BenutzernGruppenZuweisen", "7: Benutzern Gruppen zuweisen");
            alleRechte.Add("GruppenRechteZuweisen", "8: Gruppen neue Rechte zuweisen");
        }

        public void GruppenRechteZuweisen()
        {
            int i = 1;
            Console.WriteLine("Alle Rechte:");
            foreach (string key in alleRechte.Keys)
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
            int recht = Convert.ToInt32(Console.ReadLine()) - 1;

            switch (gruppe)
            {
                case 1:
                    userRechte.Add(alleRechte.ElementAt(recht).Key);
                    break;
                case 2:
                    modRechte.Add(alleRechte.ElementAt(recht).Key);
                    break;
                case 3:
                    adminRechte.Add(alleRechte.ElementAt(recht).Key);
                    break;
            }
        }

        public void RechteEinesBenutzers(Benutzer benutzer)
        {
            switch (benutzer.Gruppe)
            {
                case "User":
                    foreach (string i in userRechte)
                    {
                        if (alleRechte.ContainsKey(i))
                        {
                            Console.WriteLine(alleRechte[i]);
                        }
                    }
                    break;
                case "Mod":
                    foreach (string i in modRechte)
                    {
                        if (alleRechte.ContainsKey(i))
                        {
                            Console.WriteLine(alleRechte[i]);
                        }
                    }
                    break;
                case "Admin":
                    foreach (string i in adminRechte)
                    {
                        if (alleRechte.ContainsKey(i))
                        {
                            Console.WriteLine(alleRechte[i]);
                        }
                    }
                    break;
            }
        }
    }
}