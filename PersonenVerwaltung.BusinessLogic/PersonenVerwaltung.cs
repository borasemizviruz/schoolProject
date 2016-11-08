using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonenVerwaltung.BusinessLogic
{
    public class PersonenVerwaltung
    {
        public static List<Person> LadeAllePersonen()
        {
            List<Person> liste = null;

            Debug.WriteLine("PersonenVerwaltung - LadeAllePersonen");
            Debug.Indent();

            using (var context = new dbTestITIN19Entities())
            {
                try
                {
                    liste = context.AllePersonen
                        .Include("Ort")
                        .ToList();
                    Debug.WriteLine($"{liste.Count} Personen geladen");
                }
                catch (Exception ex) 
                {
                    Debug.WriteLine("Fehler");
                    Debug.Indent();
                    Debug.WriteLine(ex.Message);
                    Debug.Unindent();
                    Debugger.Break();
                }
            }

            Debug.Unindent();
            return liste;
        }

        public static bool PersonAnlegen(string vorname, string nachname, int idOrt, DateTime geburtsDatum, string geschlecht)
        {
            bool erfolgreich = false;
            Debug.WriteLine("PersonenVerwaltung - PersonAnlegen");
            Debug.Indent();

            using (var context = new dbTestITIN19Entities())
            {
                try
                {
                    Person neuePerson = new Person()
                    {
                        Vorname = vorname,
                        Nachname = nachname,
                        ID_Ort = idOrt,
                        GeburtsDatum = geburtsDatum,
                        Geschlecht = geschlecht,
                        Aktiv = true    // alle personen sind beim Anlegen true
                    };
                    context.AllePersonen.Add(neuePerson);
                    int anzahlZeilenBetroffen = context.SaveChanges();
                    Debug.WriteLine($"{anzahlZeilenBetroffen} Personen gespeichert");
                    erfolgreich = anzahlZeilenBetroffen == 1;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Fehler");
                    Debug.Indent();
                    Debug.WriteLine(ex.Message);
                    Debug.Unindent();
                    Debugger.Break();
                }               
            }

            Debug.Unindent();
            return erfolgreich;
        }
    }
}
