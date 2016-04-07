using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class PasController : Controller
    {
        private BankContext db = new BankContext();

        // GET: Pas
        public ActionResult Index()
        {
            return View(db.Pas.ToList());
        }

        // GET: Pas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pas pas = db.Pas.Find(id);
            if (pas == null)
            {
                return HttpNotFound();
            }
            return View(pas);
        }

        // GET: Pas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PasID,RekeningID,KlantID,Actief,Pincode")] Pas pas)
        {
            if (ModelState.IsValid)
            {
                db.Pas.Add(pas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pas);
        }

        // GET: Pas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pas pas = db.Pas.Find(id);
            if (pas == null)
            {
                return HttpNotFound();
            }
            return View(pas);
        }

        // POST: Pas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PasID,RekeningID,KlantID,Actief,Pincode")] Pas pas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pas);
        }

        // GET: Pas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pas pas = db.Pas.Find(id);
            if (pas == null)
            {
                return HttpNotFound();
            }
            return View(pas);
        }

        // POST: Pas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pas pas = db.Pas.Find(id);
            db.Pas.Remove(pas);
            db.SaveChanges();
            return RedirectToAction("Index");
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
