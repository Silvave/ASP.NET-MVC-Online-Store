using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Shop.Data;
using Shop.Models;
using Shop.Web.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Shop.Web.Controllers
{
    //[Authorize(Roles ="Administrator")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
           
            if (User.IsInRole("Administrator"))
            {
                using (var context = new ShopContext())
                {
                    var model = new AdminIndexViewModel
                    {
                        AdminName = User.Identity.Name,
                        Users = context.Users.ToList(),
                        Products = context.Products.ToList()

                    };
                    return View(model);
                } 
            }
            else
            {
                return new HttpNotFoundResult();
            }
           
        }

        //public ActionResult ManageUser(string id)
        //{
        //    if (User.IsInRole("Administrator"))
        //    {
                //    var user = UserManager.
                //    using (var context = new ShopContext()) 
                //    {


                //        var model = new ManageUserViewModel
                //        {

                //FirstName = user.FirstName,
                //LastName = user.LastName,
                //Email = user.Email,
                //UserName = user.UserName,
                //LockoutEnabled = user.LockoutEnabled,
                //ProfilePicture = user.ProfilePicture,
                //LockoutEndDateUtc = user.LockoutEndDateUtc,
                //AccessFailedCounter = user.AccessFailedCount
                //        };
                //        return View(/*model*/);
                //    }
                //}
                //else
                //{
                //    return new HttpNotFoundResult();
                //}
           // }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            if (User.IsInRole("Administrator"))
            {
                return View();
            }
            else
            {
                return new HttpNotFoundResult();
            }
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            if (User.IsInRole("Administrator"))
            {
                return View();
            }
            else
            {
                return new HttpNotFoundResult();
            }
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (User.IsInRole("Administrator"))
            {
                try
                {
                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return new HttpNotFoundResult();
            }
          
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            if (User.IsInRole("Administrator"))
            {
                return View();
            }
            else
            {
                return new HttpNotFoundResult();
            }
         
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (User.IsInRole("Administrator"))
            {
                try
                {
                    // TODO: Add update logic here

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return new HttpNotFoundResult();
            }
           
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (User.IsInRole("Administrator"))
            {
                try
                {
                    // TODO: Add delete logic here

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return new HttpNotFoundResult();
            }
            
        }
    }
}
