using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonenVerwaltung.BusinessLogic
{
    public class OrtVerwaltung
    {
        public static List<Ort> LadeAlleOrte()
        {
            List<Ort> orte = null;
            Debug.WriteLine("OrtVerwaltung - LadeAlleOrte");
            Debug.Indent();

            using (var context = new dbTestITIN19Entities())
            {
                orte = context.AlleOrte.ToList();
                Debug.WriteLine($"{orte.Count} Orte geladen");
            }

            Debug.Unindent();
            return orte;
        }
    }
}
