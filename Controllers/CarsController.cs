using Cars.Data;
using Cars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cars.Controllers
{
    public class CarsController : Controller
    {
        // GET: Cars
        public ActionResult Index()
        {
            List<CarsModel> cars = new List<CarsModel>();
            CarsDAO carsDAO = new CarsDAO();

            return View("Index", carsDAO.FetchAll());
        }

        public ActionResult Details(int id)
        {
            CarsDAO carsDAO = new CarsDAO();
            CarsModel cars = carsDAO.FetchOne(id);

            return View("Details", cars);
        }

        public ActionResult Create()
        {
            return View("CarsForm");
        }
        
        public ActionResult ProcessCreate(CarsModel carsModel)
        {
            // save to the db
            CarsDAO carsDAO = new CarsDAO();
 
            carsDAO.CreateOrUpdate(carsModel);
            
            return View("Details", carsModel);
        }

        public ActionResult Edit(int id)
        {
            CarsDAO carsDAO = new CarsDAO();
            CarsModel cars = carsDAO.FetchOne(id);
            return View("CarsForm", cars);
        }

        public ActionResult Delete(int id)
        {
            CarsDAO carsDAO = new CarsDAO();
            carsDAO.Delete(id);

            List<CarsModel> cars = carsDAO.FetchAll();

            return View("Index", cars);
        }
    }
}