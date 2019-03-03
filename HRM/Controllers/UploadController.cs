using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRM.Controllers
{
    public class UploadController : Controller
    {
        List<string> filenames = new List<string>();
        string filenamesstr = string.Empty;


        // GET: Upload
        public ActionResult SaveMulitple(IEnumerable<HttpPostedFileBase> files)
        {

            // The Name of the Upload component is "files"
            if (files != null)
            {
                foreach (var file in files)
                {
                    // Some browsers send file names with full path.
                    // We are only interested in the file name.
                    var fileName = Path.GetFileName(file.FileName);
                    var physicalPath = Path.Combine(Server.MapPath("~/Attachments/"), fileName);
                    filenames.Add(fileName);
                    filenamesstr += fileName + ";";
                    file.SaveAs(physicalPath);
                }
            }

            // Return an empty string to signify success
            return Json(new { Attachments = filenamesstr }, "text/plain");
        }

        public ActionResult SaveSingle(HttpPostedFileBase file)
        {
            var fileName = Path.GetFileName(file.FileName);


            string path = Server.MapPath("~/Attachments/");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var physicalPath = Path.Combine(path, fileName);

            file.SaveAs(physicalPath);

            return Json(new { Attachments = fileName }, "text/plain");
        }

        public ActionResult Remove(string[] fileNames)
        {
            // The parameter of the Remove action must be called "fileNames"

            if (fileNames != null)
            {
                foreach (var fullName in fileNames)
                {
                    var fileName = Path.GetFileName(fullName);
                    var physicalPath = Path.Combine(Server.MapPath("~/CategoryImage/"), fileName);

                    // TODO: Verify user permissions

                    if (System.IO.File.Exists(physicalPath))
                    {
                        // The files are not actually removed in this demo
                        System.IO.File.Delete(physicalPath);
                    }
                }
            }

            // Return an empty string to signify success
            return Content("");
        }

  


    }
}