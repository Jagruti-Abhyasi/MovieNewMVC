using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieNewMVC.Controllers
{
    public class PointsController : Controller
    {
        // GET: Points
        public ActionResult Index()
        {
            //string[] texts = System.IO.File.ReadAllLines(Server.MapPath("~/Points/BirthDateLabel.txt"));
            //ViewBag.Data = texts;
            //return View();
            string path = "~/Points/BirthDateLabel.txt";
            Console.WriteLine ("path = " + path);
            return View();
            //return File
            //return File(Stream, "text/plain",path);
            //return File("~/Points/BirthDateLabel.txt", "text/plain", "Birthdate.pdf");
            //return File("~/Points/BirthDateLabel.txt");
        }
    }
}