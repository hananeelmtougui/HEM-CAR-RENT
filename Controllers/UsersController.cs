using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Lcvoiture.Models;

namespace Lcvoiture.Controllers
{
    public class UsersController : Controller
    {
        private LocationDB db = new LocationDB();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

       

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "image_CIN,image_Permis")] User uc)
        {
            /*if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);*/
            uc.img_CINTemp.SaveAs(@"C:\Users\HELLO\source\repos\Lcvoiture\Lcvoiture\images\" + uc.img_CINTemp.FileName);
            uc.img_PrmTemp.SaveAs(@"C:\Users\HELLO\source\repos\Lcvoiture\Lcvoiture\images\" + uc.img_PrmTemp.FileName);
            uc.image_CIN =  uc.img_CINTemp.FileName;
            uc.image_Permis = uc.img_PrmTemp.FileName;
            db.Users.Add(uc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userID,nom_Complet,date_Naissance,tele,email,password,image_CIN,image_Permis,IsAdmin")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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

        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(string nom_Complet,string password,string returnUrl)
        {
            User user = db.Users.FirstOrDefault(t => t.nom_Complet == nom_Complet && t.password == password);
            if(user != null)
            {
                SaveAuthSession(nom_Complet, user);
                if (returnUrl == "" || returnUrl == null)
                {
                    return Redirect("/Users/Index");
                }
                return Redirect(returnUrl);
            }
            return View();
        }

        private void SaveAuthSession(string nom_Complet, User user)
        {
            FormsAuthentication.SetAuthCookie(user.userID.ToString(), false);
            
            
        }
        public ActionResult logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return Redirect("/Home/Index");
        }
    }
}
