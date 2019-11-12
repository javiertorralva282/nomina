using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Nomina.Models
{
    public class NominasController : Controller
    {
        private NominaEntities db = new NominaEntities();

        // GET: Nominas
        public ActionResult Index()
        {
            var nominas = db.Nominas.Include(n => n.Empleado);
            return View(nominas.ToList());
        }

        // GET: Nominas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomina nomina = db.Nominas.Find(id);
            if (nomina == null)
            {
                return HttpNotFound();
            }
            return View(nomina);
        }

        // GET: Nominas/Create
        public ActionResult Create()
        {
            List<Empleado> empleados = db.Empleados.ToList();
            empleados = empleados.Where(p => p.Estatus == "activo").ToList();
            ViewBag.EmpleadoID = new SelectList(empleados, "EmpleadoID", "NombreEmpleado");
            return View();
        }

        // POST: Nominas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NominaID,EmpleadoID,DiasTrabajados,SueldoPorDia,SueldoQuincenal,Fecha")] Nomina nomina)
        {
            if (ModelState.IsValid)
            {
                db.Nominas.Add(nomina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
      
            ViewBag.EmpleadoID = new SelectList(db.Empleados, "EmpleadoID", "NombreEmpleado", nomina.EmpleadoID);
            return View(nomina);
        }

        // GET: Nominas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomina nomina = db.Nominas.Find(id);
            if (nomina == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpleadoID = new SelectList(db.Empleados, "EmpleadoID", "NombreEmpleado", nomina.EmpleadoID);
            return View(nomina);
        }

        // POST: Nominas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NominaID,EmpleadoID,DiasTrabajados,SueldoPorDia,SueldoQuincenal,Fecha")] Nomina nomina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nomina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpleadoID = new SelectList(db.Empleados, "EmpleadoID", "NombreEmpleado", nomina.EmpleadoID);
            return View(nomina);
        }

        // GET: Nominas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomina nomina = db.Nominas.Find(id);
            if (nomina == null)
            {
                return HttpNotFound();
            }
            return View(nomina);
        }

        // POST: Nominas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nomina nomina = db.Nominas.Find(id);
            db.Nominas.Remove(nomina);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BuscarPorFecha(string Fecha)
        {
            ViewBag.Fecha = new SelectList(db.Nominas, "Fecha", "Fecha");
            DateTime fecha = Convert.ToDateTime(Fecha);
            return View(db.Nominas.Where(x => x.Fecha == fecha || Fecha == null).ToList());
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);



        }
    }
}
