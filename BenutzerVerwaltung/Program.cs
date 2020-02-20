namespace BenutzerVerwaltung
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BenutzerManager benutzerManager = new BenutzerManager();
            benutzerManager.Anmeldung();
            benutzerManager.Aktionen();
        }
    }
}
