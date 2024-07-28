using Ccart.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ccart.Controllers
{
    
    public class productsController : Controller
    {
        Product pr = new Product();
        
        // GET: productsController
        public ActionResult Index()
        {
            
            List<Product> pro=pr.getAllproduct();
            return View(pro);
        }

        public ActionResult Welcome()
        {

            
            return View();
        }

        public ActionResult Help()
        {

           
            return View();
        }

        // GET: productsController/Details/5
        public ActionResult Details(int id)
        {
            Product pro = pr.getSingleproduct(id);
            return View(pro);
        }
        static int num = 22;
        // GET: productsController/Create
        public ActionResult Create()
        {
            pr.Id = num;
            num++;
            return View(pr);
        }

        // POST: productsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product pro)
        {
            try
            {
                pr.createproduct(pro);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: productsController/Edit/5
        public ActionResult Edit(int id)
        {
            Product pro = pr.getSingleproduct(id);
            return View(pro);
        }

        // POST: productsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product pro)
        {
            try
            {
                pr.updateProduct(pro);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: productsController/Delete/5
        public ActionResult Delete(int id)
        {
            Product pro = pr.getSingleproduct(id);
            Console.WriteLine("first");
            return View(pro);
        }

        // POST: productsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Console.WriteLine("before delete");
                pr.deleteProduct(id);
                Console.WriteLine("deleted After Controller");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
