using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication6.Controllers
{
    public class HomeController : Controller
    {
        //adding images
        public ActionResult AddImage()
        {
            Photo p1 = new Photo();
            return View(p1);
        }
        //adding images
        [HttpPost]
        public ActionResult AddImage(Photo model, HttpPostedFileBase image1)
        {
            var db = new CapstoneDemoEntities();
            if(image1!=null)
            {
                model.Photo1 = new byte[image1.ContentLength];
                image1.InputStream.Read(model.Photo1, 0, image1.ContentLength);

            }

            db.SaveChanges();
            db.Photos.Add(model);
            return View(model);
        }

        //showing image result
        public ActionResult ShowImage()
        {
            CapstoneDemoEntities db = new CapstoneDemoEntities();
            var item = (from d in db.Photos
                        select d).ToList();
            return View(item);
        }



    }
}