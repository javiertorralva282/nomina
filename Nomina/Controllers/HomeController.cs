using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nomina.Models;

namespace Nomina.Controllers
{
    public class HomeController : Controller
    {
        private NominaEntities db = new NominaEntities();

        // GET: Home
        public ActionResult Index(string search)
        {

            return View(db.Nominas.Where(x => x.Empleado.NombreEmpleado.StartsWith(search) || search == null).ToList());
        }
    }
}
