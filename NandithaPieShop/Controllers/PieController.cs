using Microsoft.AspNetCore.Mvc;
using NandithaPieShop.Models;
using NandithaPieShop.ViewModel;

namespace NandithaPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        public PieController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public IActionResult List()
        {
            //got the pie data
            var pies = _pieRepository.AllPies;

            PieListViewModel pieListViewModel = new PieListViewModel();
            pieListViewModel.Pies = pies;
            pieListViewModel.CurrentCategory = "Cheese cakes";

            //passing data to view
            return View(pieListViewModel);
        }
        public ViewResult PieWeak()
        {
            //got the pie data
            var pies = _pieRepository.AllPies.Where(pie => pie.IsPieOfTheWeek);

            /* PieListViewModel pieListViewModel = new PieListViewModel();
             pieListViewModel.Pies = pies;
             pieListViewModel.CurrentCategory = "Cheese cakes";
 */
            //passing data to view
            return View(pies);
        }
        public IActionResult Categories()
        {
            //got the pie data
            var pies = _pieRepository.AllPies;

            PieListViewModel pieListViewModel = new PieListViewModel();
            pieListViewModel.Pies = pies;
            pieListViewModel.CurrentCategory = "Cheese cakes";

            //passing data to view
            return View(pieListViewModel);
        }
        public ViewResult Details(int id)
        {
            //got the pie data
            var pies = _pieRepository.AllPies.FirstOrDefault(pies => pies.PieId == id);

            //passing data to view
            return View(pies);
        }
        public ViewResult FruitPies()
        {
            // var categoryid = categoryRepostiory.AllCategories.Select(category => category.CategoryName == "Fruit pies");
            var pie = _pieRepository.FruitPies();
            return View(pie);

        }
        public ViewResult CheesePies()
        {
            var pie = _pieRepository.CheesePies();
            return View(pie);

        }
        public ViewResult SeasonalPies()
        {
            var pie = _pieRepository.SeasonalPies();
            return View(pie);

        }

        public ViewResult AddToCart(int id)
        {
            var pie = _pieRepository.AllPies.FirstOrDefault(pie => pie.PieId == id);
            return View(pie);
        }
        public ViewResult GetPieById(int id)
        {
            /* var category = categoryRepostiory.AllCategories.Where(category => category.CategoryName == "Seasonal pies");*/
            var pie = _pieRepository.GetPieById(id);
            return View(pie);

        }
    }
}