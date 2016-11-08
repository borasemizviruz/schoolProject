using PersonenVerwaltung.BusinessLogic;
using PersonenVerwaltung.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonenVerwaltung.Web.Controllers
{
    public class PersonController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            Debug.WriteLine("GET - Person - Index");
            Debug.Indent();

            /// Liste aus der Datenbank, mit MODEL aus der DB
            List<Person> bl_liste = BusinessLogic.PersonenVerwaltung.LadeAllePersonen();

            /// übertrage (mappe!!!) die liste mit dem Model aus der DB
            /// zu einer Liste mit Model für die View!
            List<AnzeigenModel> ui_liste = new List<AnzeigenModel>();

            foreach (var person in bl_liste)
            {
                ui_liste.Add(new AnzeigenModel()
                {
                    Vorname = person.Vorname,
                    Nachname = person.Nachname,
                    ID = person.ID,
                    Ort = person.Ort.Name,
                    PLZ = person.Ort.PLZ
                });
            }

            Debug.Unindent();
            return View(ui_liste);
        }

        [HttpGet]
        public ActionResult Anlegen()
        {
            Debug.WriteLine("GET - Person - Anlegen");
            Debug.Indent();

            AnlegenModel model = new AnlegenModel();
            List<Ort> bl_orte = OrtVerwaltung.LadeAlleOrte();

            model.Orte = new List<OrtModel>();

            foreach (var orte in bl_orte)
            {
                model.Orte.Add(new OrtModel()
                {
                    ID = orte.ID,
                    OrtsName = orte.Name,
                    PLZ = orte.PLZ
                });
            }

            Debug.Unindent();
            return View(model);
        }

        [HttpPost]
        public ActionResult Anlegen(AnlegenModel model)
        {
            Debug.WriteLine("POST - Person - Anlegen");
            Debug.Indent();

            if (ModelState.IsValid)
            {
                /// speichere in der DB
                if (BusinessLogic.PersonenVerwaltung.PersonAnlegen(
                        model.Vorname,
                        model.Nachname,
                        model.ID_Ort,
                        model.GeburtsDatum,
                        model.Geschlecht == Geschlecht.männlich ? "m" : "w"
                    ))
                {
                    Debug.WriteLine("Anlegen erfolgreich");
                    return RedirectToAction("Index");
                }
                else
                {
                    Debug.WriteLine("Anlegen NICHT erfolgreich!");
                }
            }
            else
            {
                Debug.WriteLine("ModelState NICHT valid!");
            }

            Debug.Unindent();

            model.Orte = new List<OrtModel>();

            List<Ort> bl_orte = OrtVerwaltung.LadeAlleOrte();
            foreach (var orte in bl_orte)
            {
                model.Orte.Add(new OrtModel()
                {
                    ID = orte.ID,
                    OrtsName = orte.Name,
                    PLZ = orte.PLZ
                });
            }

            return View(model);
        }
    }
}