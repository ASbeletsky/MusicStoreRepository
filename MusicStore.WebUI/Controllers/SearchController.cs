using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using MusicStore.WebUI.Models.Search;
using System.Text.RegularExpressions;

namespace MusicStore.WebUI.Controllers
{
    public class SearchController : Controller
    {
        private IMusicInstrumentRepository repository;
        public SearchController (IMusicInstrumentRepository repositoryParam)
        {
            repository = repositoryParam;
        }

        //Автодополнение при поиске
        public ActionResult Find(string term)
        {
            IEnumerable<Product> products = repository.musicInstruments;
            Regex searchTerm = new Regex(term, RegexOptions.IgnoreCase);
            products = products.Where((prod) => searchTerm.IsMatch(prod.General.Name));

            var results = products.Select(x => new
            {
                id = x.Id,
                label = x.General.Name,
                value = x.General.Name
            });
            return Json(results.ToList(), JsonRequestBehavior.AllowGet);
        }

        //Полный поиск с учетом категории
        public PartialViewResult Search()
        {
            SearchViewModel model = new SearchViewModel();
            model.Term = "Что нужно найти?";
            model.SelectedCategoryId = 1;
            model.Categories = new SelectList(
                repository.categories.Categories.Select(x => x).ToList(),
                "CategoryId", "CategoryName");
                               
            return PartialView(model);
        }
        //Результаты поиска
        public ViewResult SearchResult(SearchViewModel searchDetails)        
        {
            IEnumerable<Product> products = repository.musicInstruments;
            if(searchDetails.Term != null)
                 products = products.Where(x => x.General.Name.Contains(searchDetails.Term));            
            if (searchDetails.SelectedCategoryId > 0)
                products = products.Where(x => x.Category_Id == searchDetails.SelectedCategoryId);
            return View(products);
        }
           
    }
}
