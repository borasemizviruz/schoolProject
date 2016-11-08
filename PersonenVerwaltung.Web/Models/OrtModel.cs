using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonenVerwaltung.Web.Models
{
    public class OrtModel
    {
        public string OrtsName { get; set; }

        public int PLZ { get; set; }

        public int ID { get; set; }

        public string Anzeige
        {
            get
            {
                //return OrtsName + " (" + PLZ + ")";
                //return string.Format("{0} ({1})", OrtsName, PLZ);
                return $"{OrtsName} ({PLZ})";
            }
        }
    }
}