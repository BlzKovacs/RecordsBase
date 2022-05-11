using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TD_Proiect.Models;

namespace TD_Proiect.Controllers
{
    public class HomeController : Controller
    {
        private MusicDBEntities dB = new MusicDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(dB.Songs.ToList());
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude ="Id")] Song songToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            dB.Songs.Add(songToCreate);
            dB.SaveChanges();

            return RedirectToAction("Index");

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

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var songToEdit = (from s in dB.Songs
                              where s.Id == id
                              select s).First();

            return View(songToEdit);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Song songToEdit)
        {

            var originalSong = (from s in dB.Songs
                                where s.Id == songToEdit.Id
                                select s).First();

            if(!ModelState.IsValid)
                return View(originalSong);

            dB.Entry(originalSong).CurrentValues.SetValues(songToEdit);
            dB.SaveChanges();

            return RedirectToAction("Index");
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

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            var songToDelete = (from s in dB.Songs
                              where s.Id == id
                              select s).First();

            return View(songToDelete);


        }
        
        
        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(Song songToDelete)
        {

            var originalSong = (from s in dB.Songs
                                where s.Id == songToDelete.Id
                                select s).First();

            if (!ModelState.IsValid)
                return View(originalSong);

            dB.Songs.Remove(originalSong);
            dB.SaveChanges();

            return RedirectToAction("Index");
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
        
    }
}
