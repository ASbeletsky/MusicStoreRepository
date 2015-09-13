using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using MusicStore.WebUI.Models.MusicInstruments;
using MusicStore.WebUI.Models.MusicInstruments.Filter;

namespace MusicStore.WebUI.Controllers
{
    public class MusicInstrumentsController : Controller
    {        
        private IMusicInstrumentRepository repository;
        public int pageSize = 4;

        public MusicInstrumentsController(IMusicInstrumentRepository repositoryParam)
        {
            repository = repositoryParam;
        }

        //представление главной страницы
        public ViewResult ShowListPage(int category = 0, int page = 1)
        {            
            ProductListPageViewModel model = new ProductListPageViewModel();
            ProductFilter filter = (ProductFilter)TempData["filter"];            
            ViewBag.Title = "Товары";   //заголовок

            IEnumerable<Product> fromCatagory = repository.musicInstruments //товары из выбраной категррии
                                         .Where(vm => category == 0 || vm.Category_Id == category).ToList();

            if (filter == null)
            {
                model.filter = InitializeFilter(category);
                model.productList = List(fromCatagory, category, page);
            }
            else
            {
                //Фильтрация
                model.filter = filter;
                model.productList = List(GoFilter(fromCatagory, filter),category,page);
            }
                
            return View(model);
        }

        //отобразить коллекцию муз инструментов
        public MusicInstrumentsListViewModel List(IEnumerable<Product> products, int category, int page )
        {
            ViewBag.SelectedCategory = category;

            if (products == null)
                products = repository.musicInstruments
                                         .Where(vm => category == 0 || vm.Category_Id == category).ToList();   
           
            MusicInstrumentsListViewModel model = new MusicInstrumentsListViewModel
            {
                Instruments =  products.OrderBy(vm => vm.Id)
                                       .Skip((page - 1) * pageSize)
                                       .Take(pageSize), 
                PagingInfo = new PagingInfo
                {
                    ItemsPerPage = pageSize,
                    CurrentPage = page,
                    TotalItems = (category == 0) ?
                        products.Count()
                    :
                        products.Where(m => m.Category_Id == category).Count()
                },
                CurrentCategory = category,

            };
            return model;
        }
        //Задать начальные значения фильтра
        private ProductFilter InitializeFilter(int cat)
        {
            IEnumerable<Product> products = repository.musicInstruments //товары из выбраной категррии
                                         .Where(vm => cat == 0 || vm.Category_Id == cat).ToList();
            ProductFilter filter = new ProductFilter()
            {
                category = cat,
                producers = products.Select(x => new ProducerVM
                {
                    Id = x.producer.Id,
                    Name = x.producer.Name,
                    IsChecked = false 
                }).GroupBy(x => x.Name).Select(x => x.First()).ToList() ,
                colors = products.Select(x => new ColorVM
                {
                    Id = x.color.Id,
                    Name = x.color.Name,
                    IsChecked = false
                }).GroupBy(x => x.Name).Select(x => x.First()).ToList(),
                minPrice = products.Min(x => x.General.Price),
                maxPrice = products.Max(x => x.General.Price)
            };
            return filter;
        }
               
        //Фильтрация товаров:
        private IEnumerable<Product> GoFilter(IEnumerable<Product> filtred, ProductFilter filter)
       {

            //По производителю:
           int[] targetProdIds = filter.producers.Where(x => x.IsChecked).Select(x => x.Id).ToArray();
           if(targetProdIds.Count() != 0)
                filtred = filtred.Where(prod => targetProdIds.Contains(prod.Producer_Id));

            //По цвету:
           int[] targetColIds = filter.colors.Where(x => x.IsChecked).Select(x => x.Id).ToArray();
           if (targetColIds.Count() != 0)
               filtred =  filtred.Where(prod => targetColIds.Contains(prod.Color_Id));
                     
            //По цене:
           filtred = filtred.Where(x => x.General.Price >= filter.minPrice);
           filtred = filtred.Where(x => x.General.Price <= filter.maxPrice);

           return filtred;
       }

        //Получение фильтра из формы
        [HttpPost]
        public RedirectToRouteResult Filter(ProductFilter thefilter, string ProducerStr = null)
        {
            TempData["filter"] = thefilter;
            return RedirectToAction("ShowListPage", "MusicInstruments", new
                {
                    category = thefilter.category
                });                                           
        }
        
        public RedirectToRouteResult FilterByProducerAndRedirect(string producerName, int cat)
        {
            ProductFilter thefilter = InitializeFilter(cat);
            int prodIndex = thefilter.producers.FindIndex(x => x.Name == producerName);
            thefilter.producers[prodIndex].IsChecked = true;
            TempData["filter"] = thefilter;
            return RedirectToAction("ShowListPage", "MusicInstruments", new
            {
                category = cat
            }); 

        }
    }
}
