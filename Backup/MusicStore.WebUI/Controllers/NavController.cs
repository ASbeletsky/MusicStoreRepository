using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MusicStore.Domain.Abstract;

namespace MusicStore.WebUI.Controllers
{
    //Контроллер навигации
    public class NavController : Controller
    {
        private IMusicInstrumentRepository repository;

        public NavController(IMusicInstrumentRepository repositoryParam)
        {
            repository = repositoryParam;
        }
        //Частичное представление списка категорий
        public PartialViewResult Menu(int category = 0)
        {
            ViewBag.SelectedCategory = category;                 
            return PartialView(repository.categories);
        }
        
        public PartialViewResult CitySelect()
        {
            IEnumerable<SelectListItem> cities = new SelectList(
                     repository.cities.Select(x => x).ToList(),
                     "Id",
                     "Name");
            return PartialView(cities);           
        }
    }
}
