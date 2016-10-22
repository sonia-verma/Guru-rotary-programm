using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace ExceptionContextCode.Controllers
{
    public class ProductController : Controller
    {
    
    // controller for enter details for product
      public ActionResult Create()
        {
            return View();
        }

// controller that work after submitting the details of product
        [HttpPost]
        [HandleError(ExceptionType = typeof(System.Data.DataException), View = "Error")]
        public ActionResult Create(Product product)
        {
            try
            {

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }

            }
            catch(Exception ex)
            {
               // dont forgot to create a logerror function in your project for exception catch
               // although this is not necessary here because we are handling this by filtercontext error
               CustomHandleErrorAttribute.LogErrors(ex);
                return RedirectToAction("Error");
           
            }

        }

       // exception method for filtercontext
        protected override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            var model = new HandleErrorInfo(filterContext.Exception, "Product", "Create");
            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };

        }
      }
   }
      
