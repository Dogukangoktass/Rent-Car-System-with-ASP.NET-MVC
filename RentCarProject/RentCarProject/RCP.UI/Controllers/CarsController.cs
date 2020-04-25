using RCP.BL;
using System.Web.Mvc;

namespace RCP.UI.Controllers
{
    public class CarsController : Controller
    {
        // GET: Cars
        public ActionResult Cars()
        {
            CarsRepository carsRepository = new CarsRepository();
            var result = carsRepository.GetAll();
            return View(result);
        }

        // POST : Cars
        [HttpPost]
        public ActionResult Cars(int id)
        {
            return View();
        }

        // GET: CarDetail
        public ActionResult CarDetail(int id)
        {
            CarsRepository carsRepository = new CarsRepository();
            var result = carsRepository.GetById(id);
            if (result != null)
            {
                return View(result);
            }
            else
            {
                return View();
            }
        }
    }
}