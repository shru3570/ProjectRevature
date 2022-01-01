using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using ProjectDemo.Models;
using ExcelDataReader;

namespace ProjectDemo.Controllers
{
    public class ExcelController : Controller
    {
        // GET: Excel
        public ActionResult Index()
        {
            return View();
        }
        UserDb db = new UserDb();
        public ActionResult Import(HttpPostedFileBase excelfile)
        {
            if (excelfile==null ||excelfile.ContentLength==0)
            {
                ViewBag.Error = "Please select a ExcelFile<br>";
                return View("Index");
            }
            else
            {

                if (excelfile.FileName.EndsWith("xls")|| excelfile.FileName.EndsWith("xlsx"))
                {
                    string path = Server.MapPath("~/Content/" + excelfile.FileName);
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);
                    excelfile.SaveAs(path);
                    //Read data from excel file
                    List<Product> listproducts = new List<Product>();
                    int i = 0;
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    using (var stream = System.IO.File.Open(path, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader=ExcelReaderFactory.CreateReader(stream))
                        {
                            while (reader.Read())
                            {
                                if (i == 0)
                                {
                                    i++;
                                    continue;
                                }
                                Product p = new Product();
                                p.ProductName = reader.GetValue(0).ToString();
                                p.ProductAmount = Convert.ToInt32(reader.GetValue(1).ToString());
                                p.ProductQuantity = Convert.ToInt32(reader.GetValue(2).ToString());
                                listproducts.Add(p);
                                var data = db.Products.Where(x => x.ProductName == p.ProductName).SingleOrDefault();
                                if (data == null)
                                {
                                    db.Products.Add(p);

                                    db.SaveChanges();
                                }
                                data = null;
                                i++;
                           
                            }
                        }
                    }
             

                    ViewBag.ListProducts = listproducts;
                    return RedirectToAction("MultipleDelete","Products");
                }
                else
                {
                    
                    ViewBag.Error = "File Type Is Incorrect<br>";
                    return View("Index");
                }
                    
            }
           

        }
    }
}