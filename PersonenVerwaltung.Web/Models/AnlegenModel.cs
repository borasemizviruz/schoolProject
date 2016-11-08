using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonenVerwaltung.Web.Models
{
    public enum Geschlecht
    {
        
        männlich,
        weiblich
    }

    public class AnlegenModel
    {
        [Required]
        [StringLength(255)]
        public string Vorname { get; set; }

        [Required]
        [StringLength(255)]
        public string Nachname { get; set; }

        [DataType(DataType.Date)]
        public DateTime GeburtsDatum { get; set; }

        [Required]
        [EnumDataType(typeof(Geschlecht))]
        public Geschlecht Geschlecht { get; set; }

        /// ich muss ja die Auswahl des Ortes speichern!!
        [Required]
        [Display(Name = "Ort (PLZ)")]
        public int ID_Ort { get; set; }

        /// um etwas auszuwählen, brauche ich eine Liste von möglichen Werten
        public List<OrtModel> Orte { get; set; }
    }


}