using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BenutzerVerwaltung
{
    class Gruppen
    {
        private static bool nächsteAktion = true;

        public static List<string> userRechte = new List<string>();
        public static List<string> modRechte = new List<string>();
        public static List<string> adminRechte = new List<string>();

        public static Dictionary<string, string> alleRechte = new Dictionary<string, string>();


        static public void ListenErstellen()
        {
            userRechte.Add("InfosAbfragen");
            userRechte.Add("InfosÄndern");
            userRechte.Add("BenutzerListe");

            modRechte.Add("InfosAbfragen");
            modRechte.Add("InfosÄndern");
            modRechte.Add("InfosAndererAccountsAbfragen");
            modRechte.Add("InfosAndererAccountsÄndern");
            modRechte.Add("BenutzerListe");
          
            adminRechte.Add("InfosAbfragen");
            adminRechte.Add("InfosÄndern");
            adminRechte.Add("BenutzerListe");
            adminRechte.Add("InfosAndererAccountsAbfragen");
            adminRechte.Add("InfosAndererAccountsÄndern");
            adminRechte.Add("NeueBenutzerAnlegen");
            adminRechte.Add("BenutzernGruppenZuweisen");
            adminRechte.Add("GruppenRechteZuweisen");

            alleRechte.Add("InfosAbfragen", "1 : Information zum Account abfragen");
            alleRechte.Add("InfosÄndern", "2: Informationen des Accounts ändern");
            alleRechte.Add("BenutzerListe", "3: Liste aller Benutzer abfragen");
            alleRechte.Add("InfosAndererAccountsAbfragen", "4: Information eines anderen Account abfragen");
            alleRechte.Add("InfosAndererAccountsÄndern", "5: Information eines anderen Accounts ändern");
            alleRechte.Add("NeueBenutzerAnlegen", "6: Neue Benutzer anlegen");
            alleRechte.Add("BenutzernGruppenZuweisen", "7: Benutzern Gruppen zuweisen");
            alleRechte.Add("GruppenRechteZuweisen", "8: Gruppen neue Rechte zuweisen");
            
            
        }

        static public void RechteDesAktuellenBenutzers()
        {

            switch (Benutzer.benutzer[Program.benutzerName].Gruppe)
            {
                case "User":
                    foreach (string i in Gruppen.userRechte)
                    {
                        if (Gruppen.alleRechte.ContainsKey(i) == true)
                        {
                            Console.WriteLine(Gruppen.alleRechte[i]);
                        }
                    }
                    break;
                case "Mod":
                    foreach (string i in Gruppen.modRechte)
                    {
                        if (Gruppen.alleRechte.ContainsKey(i) == true)
                        {
                            Console.WriteLine(Gruppen.alleRechte[i]);
                        }
                    }
                    break;
                case "Admin":
                    foreach (string i in Gruppen.adminRechte)
                    {
                        if (Gruppen.alleRechte.ContainsKey(i) == true)
                        {
                            Console.WriteLine(Gruppen.alleRechte[i]);
                        }
                    }
                    break;
            }
        }

        static public void Aktionen()
        {
            while (nächsteAktion)
            {
                Console.WriteLine("\nWas möchtest du tun?\n");
                RechteDesAktuellenBenutzers();
                Console.WriteLine("\nEingabe:");
                int rechtAusführen = Convert.ToInt32(Console.ReadLine());

                switch (rechtAusführen)
                {
                    case 1:
                        Benutzer.benutzer[Benutzer.aktuellerBenutzer.BenutzerName].InformationenAbfragen();
                        break;
                    case 2:
                        Benutzer.benutzer[Benutzer.aktuellerBenutzer.BenutzerName].InformationenÄndern();
                        break;
                    case 3:
                        Benutzer.BenutzerListe();
                        break;
                    case 4:
                        Console.WriteLine("\nVon welchem Account möchtest du die Daten?");
                        Console.WriteLine("\nAccountname:");
                        string fremdenBenutzerEinsehen = Console.ReadLine();

                        Benutzer.benutzer[fremdenBenutzerEinsehen].InformationenAbfragen();
                        break;
                    case 5:
                        Console.WriteLine("Von welchem Account möchtest du die Daten ändern?");
                        Console.WriteLine("\nAccountname:");
                        string fremdenBenutzerÄndern = Console.ReadLine();

                        Benutzer.benutzer[fremdenBenutzerÄndern].InformationenÄndern();
                        break;
                    case 6:
                        Benutzer.NeueBenutzerAnlegen();
                        break;
                    case 7:
                        Benutzer.GruppenZuweisen();
                        break;
                    case 8:
                        Benutzer.GruppenRechteZuweisen();
                        break;
                }
            }
        }  
    }
}