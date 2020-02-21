using System;
using System.Collections.Generic;
using System.Text;

namespace BenutzerVerwaltung
{

    class GeburtsdatumUtils
    {
        private static int[] monate = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        static int tag;
        static int monat;
        static int jahr;
        static public bool isDateValid(string geburtsdatumNeu)
        {
            string[] datum = geburtsdatumNeu.Split(".");

            foreach (string i in datum)
            {
                System.Console.Write("{0} ", i);
            }
            try
            {
                tag = Convert.ToInt32(datum[0]);
                monat = Convert.ToInt32(datum[1]);
                jahr = Convert.ToInt32(datum[2]);
                Console.WriteLine(monate[monat - 1]);
            }
            catch (Exception)
            {
                Console.WriteLine("Das eingebene Datum ist nicht korrekt");
                return false;
            }

            if(DatumRichtig(tag, monat, jahr))
            {
                return true;
            }
            else 
            {
                Console.WriteLine("Das gegebene Datum ist nicht korrekt.");
                return false; 
            }


        }

        static public bool schaltjahr(int jahr)
        {
            if (jahr % 4 == 0)
            {
                return true;
            }
            else { return false; }
        }

        static public bool DatumRichtig(int jahr, int monat, int tag)
        {
            if (monat == 2)
            {
                if (schaltjahr(jahr))
                {
                    if (tag < 1 || tag > 29)
                    {
                        return false;
                    }               
                }
                else
                {
                    if (tag < 1 || tag > 28)
                    {                       
                        return false;
                    }
                }
            }
            else
            {
                if (monat < 1 || monat > 12)
                {
                    return false;
                }
                else
                {
                    if (tag < 1 || tag > monate[monat - 1])
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return true;
        }
    }
}
