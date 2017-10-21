using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mess.Models;

namespace mess.Controllers
{
    public class CreateController : Controller
    {
        //
        // GET: /Create/

        public ActionResult Display()
        {
            List<mess.EntFrame.My_Table> a;
            using (var db = new EntFrame.MyDataEntities3())
            {
                a = db.My_Table.ToList();
            }
            return View(a);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(mess.EntFrame.My_Table s, Class1 sa)
        {
            try
            {
                s.ID = sa.ID;
                s.fname = sa.fname;
                s.lname = sa.lname;
                s.gender = sa.gender;
                using (var a = new mess.EntFrame.MyDataEntities3())
                {
                    a.My_Table.AddObject(s);
                    a.SaveChanges();
                }
                return RedirectToAction("login");
            }
            catch
            {
                return View();
            }
            
        }

        public ActionResult Edit(int id)
        {
            EntFrame.My_Table t;
            using (var a = new EntFrame.MyDataEntities3())
            {
                t = a.My_Table.Where(v => v.ID == id).FirstOrDefault();
            }
            return View(t);
        }
        [HttpPost]
        public ActionResult Edit(EntFrame.My_Table s)
        {
            EntFrame.My_Table q;
            using (var db = new EntFrame.MyDataEntities3())
            {
                q = db.My_Table.Where(v => v.ID == s.ID).FirstOrDefault();
                q.fname = s.fname;
                q.lname = s.lname;
                q.gender = s.gender;

                db.SaveChanges();
            }
            return RedirectToAction("Display");

        }

        public ActionResult Delete(int id)
        {
            EntFrame.My_Table stud;
            using (var a = new EntFrame.MyDataEntities3())
            {
                stud = a.My_Table.Where(v => v.ID == id).FirstOrDefault();
            }
            return View(stud);
        }
        [HttpPost]
        public ActionResult Delete(EntFrame.My_Table s)
        {
            EntFrame.My_Table q;
            using (var db = new EntFrame.MyDataEntities3())
            {
                q = db.My_Table.Where(v => v.ID == s.ID).FirstOrDefault();
                q.fname = s.fname;
                q.lname = s.lname;
                db.My_Table.DeleteObject(q);
                db.SaveChanges();
            }
            return RedirectToAction("Display");

        }
        public ActionResult loaddata()
        {
            using (mess.EntFrame.MyDataEntities3 c = new mess.EntFrame.MyDataEntities3())
            {
                var crazy = c.My_Table.OrderBy(a => a.ID).ToList();
                return Json(new { data = crazy }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(EntFrame.My_Table q)
        {

            if (ModelState.IsValid)
            {

                using (mess.EntFrame.MyDataEntities3 a = new mess.EntFrame.MyDataEntities3())
                {


                    var h = a.My_Table.Where(t => t.Uname.Equals(q.Uname) && t.Pword.Equals(q.Pword)).FirstOrDefault();



                    if (h != null)
                    {
                        Session["ID"] = h.ID.ToString();
                        Session["fname"] = h.fname.ToString();
                        return RedirectToAction("Welcome");
                    }


                }
            }
            return View(q);
        }
        public ActionResult Welcome()
        {
            return View();
        }
        public ActionResult Logout()
        {
            return RedirectToAction("Login");
        }
        public ActionResult HomePage()
        {
            return View();
        }
        public ActionResult adminreg()
        {
            return View();
        }
        [HttpPost]
        public ActionResult adminreg(mess.EntFrame.Admin_Data s, Class2 sa)
        {
            try
            {
                s.IDad = sa.IDad;
                s.Fname = sa.Fname;
                s.Lname = sa.Lname;
                s.Email = sa.Email;
                using (var a = new mess.EntFrame.MyDataEntities4())
                {
                    a.Admin_Data.AddObject(s);
                    a.SaveChanges();
                }
                return RedirectToAction("adminlog");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult adminlog()
        {
            return View();
        }
         [HttpPost]
        public ActionResult adminlog(EntFrame.Admin_Data q)
        {

            if (ModelState.IsValid)
            {

                using (mess.EntFrame.MyDataEntities4 a = new mess.EntFrame.MyDataEntities4())
                {


                    var h = a.Admin_Data.Where(t => t.Uname.Equals(q.Uname) && t.Pword.Equals(q.Pword)).FirstOrDefault();



                    if (h != null)
                    {
                        Session["ID"] = h.IDad.ToString();
                        Session["Fname"] = h.Fname.ToString();
                        return RedirectToAction("AdminPage");
                    }


                }
            }
            return View(q);
        }
        public ActionResult AdminPage()
        {
            return View();
        }
        public ActionResult Admins()
        {
            List<mess.EntFrame.Admin_Data> a;
            using (var db = new EntFrame.MyDataEntities4())
            {
                a = db.Admin_Data.ToList();
            }
            return View(a);
        }
        public ActionResult AddItems()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddItems(mess.EntFrame.Item_Table s)
        {
            try
            {
                using (var a = new mess.EntFrame.MyDataEntities5())
                {
                    a.Item_Table.AddObject(s);
                    a.SaveChanges();
                }
                return RedirectToAction("DisplayItems");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DisplayItems()
        {
            List<mess.EntFrame.Item_Table> a;
            using (var db = new EntFrame.MyDataEntities5())
            {
                a = db.Item_Table.ToList();
            }
            return View(a);
        }
        public ActionResult EditItem(int id)
        {
            EntFrame.Item_Table t;
            using (var a = new EntFrame.MyDataEntities5())
            {
                t = a.Item_Table.Where(v => v.ItemID == id).FirstOrDefault();
            }
            return View(t);
        }
        [HttpPost]
        public ActionResult EditItem(EntFrame.Item_Table s)
        {
            EntFrame.Item_Table q;
            using (var db = new EntFrame.MyDataEntities5())
            {
                q = db.Item_Table.Where(v => v.ItemID == s.ItemID).FirstOrDefault();
                q.ItemID = s.ItemID;

                db.SaveChanges();
            }
            return RedirectToAction("DisplayItems");

        }
        public ActionResult DeleteItem(int id)
        {
            EntFrame.Item_Table stud;
            using (var a = new EntFrame.MyDataEntities5())
            {
                stud = a.Item_Table.Where(v => v.ItemID == id).FirstOrDefault();
            }
            return View(stud);
        }
        [HttpPost]
        public ActionResult DeleteItem(EntFrame.Item_Table s)
        {
            EntFrame.Item_Table q;
            using (var db = new EntFrame.MyDataEntities5())
            {
                q = db.Item_Table.Where(v => v.ItemID == s.ItemID).FirstOrDefault();
                q.ItemID = s.ItemID;
                db.Item_Table.DeleteObject(q);
                db.SaveChanges();
            }
            return RedirectToAction("DisplayItems");

        }
        public ActionResult Room()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Room(mess.EntFrame.Room_table s, date sa)
        {
            try
            {
                s.room = sa.Room;
                using (var a = new mess.EntFrame.MyDataEntities6())
                {
                    s.fname = Session["fname"].ToString();
                    a.Room_table.AddObject(s);
                    a.SaveChanges();
                    
                }
                return RedirectToAction("Welcome");
            }
            catch
            {
                return View();
            }

        }
        public ActionResult Lab(mess.EntFrame.Lab_table s, date sa)
        {
            try
            {
                using (var a = new mess.EntFrame.MyDataEntities8())
                {
                    s.fname = Session["fname"].ToString();
                    a.Lab_table.AddObject(s);
                    a.SaveChanges();

                }
                return RedirectToAction("Welcome");
            }
            catch
            {
                return View();
            }

        }
        public ActionResult Equipment()
        {
            return View();
        }
    }
}
