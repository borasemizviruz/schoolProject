using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonenVerwaltung.Web.Models
{
    public class AnzeigenModel
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int ID { get; set; }

        public string Ort { get; set; }

        public int PLZ { get; set; }
    }
}