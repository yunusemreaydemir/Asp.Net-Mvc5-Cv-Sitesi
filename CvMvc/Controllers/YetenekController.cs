﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvMvc.Models.Entity; //
using CvMvc.Repositories; //

namespace CvMvc.Controllers
{
    public class YetenekController : Controller
    {
        GenericRepository<TblYeteneklerim> repo = new GenericRepository<TblYeteneklerim>();
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(TblYeteneklerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x => x.ID == id); //önce yeteneği bulup sonra sildirme işlemi yapılacak
            repo.TDelete(yetenek);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult  YetenekDuzenle(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            return View(yetenek);
        }
        [HttpPost]
        public ActionResult YetenekDuzenle(TblYeteneklerim t )
        {
            var y = repo.Find(x => x.ID == t.ID);
            y.Yetenek=t.Yetenek;
            y.Oran= t.Oran;
            repo.TUpdate(y);
            return RedirectToAction("Index"); //indexe yönlendir
        }
    }
}