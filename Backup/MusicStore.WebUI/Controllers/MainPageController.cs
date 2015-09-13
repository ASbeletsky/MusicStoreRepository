using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MusicStore.Domain.Abstract;
using MusicStore.WebUI.Models.MainPage;
using MusicStore.WebUI.Models.Shared;
using MusicStore.Domain.Entities;

namespace MusicStore.WebUI.Controllers
{
    public class MainPageController : Controller
    {
       private IMusicInstrumentRepository repository;
       public MainPageController(IMusicInstrumentRepository repositoryParam)
        {
            repository = repositoryParam;
            ViewBag.Title = "Интернет магазин Music Store";
        }

       private enum ShowType { Popular = 1, New}

       //Представление слайдера контента:
       private IEnumerable<slides> GetContentSlider()
       {
           IEnumerable<slides> model = repository.slides.Select(x => x).OrderBy(x => x.Id);           
           return model;
       }

        //Представление всего каталога товаров:
       private ShowCatalogViewModel GetCatalog()
        {
            ShowCatalogViewModel model = new ShowCatalogViewModel();
            int TabsCount = repository.categories.GenericCategories.Count();
            int subTabsCount = 0;
            int currentCategory = 0;
            //Добавляем во вкладку:
            for (int tabIndex = 1; tabIndex <= TabsCount; tabIndex++ )
            {
                //имя текущей категории
                model.Tabs.Add(new Tab{
                    GenericCategoryName = repository.categories.GenericCategories.First(x => x.Id == tabIndex).Name                                                                                
                });
                subTabsCount = repository.categories.Categories.Where(x => x.GenericCategory_Id == tabIndex).Count();
                //Добавляем в подвкладку:
                for (int subTabIndex = 1; subTabIndex <= subTabsCount; subTabIndex++)
                {
                    currentCategory = tabIndex*10 + subTabIndex;
                    //имя  и id подкатегории
                    List<Product> ProductFromCategory = repository.musicInstruments.Where(x => x.Category_Id == currentCategory).ToList();
                    model.Tabs[tabIndex-1].SubTabs.Add(new SubTab{
                        SubCategoryName = repository.categories.Categories.First(x => x.CategoryId == currentCategory) 
                                                                          .CategoryName,
                        SubCategoryId = currentCategory,
                    //Путь к изображению
                        ImagePath = "/Content/Images/MainPage/product type " + currentCategory.ToString() + ".jpg",
                    //Список производителей
                        ListOfProducers = ProductFromCategory.Select(x => x.producer).OrderBy(x => x.Id).GroupBy(x => x.Name)
                                                                                     .Select(p => p.First().Name).ToList()
                    });
                }
            }
            return model;
        }

        //Представление товаров, в зависимости от типа:
       private IEnumerable<ProductViewModel> GetProducts(ShowType ProductType)
        {
            //Выборка всех категорий
            List<productcategory> allcat = repository.categories.Categories.ToList();
            //Выборка общей модели товары 
            IEnumerable<ProductViewModel> model = repository.musicInstruments
                                              .Select(x => new ProductViewModel
                                              {
                                                  Id = x.Id, IsNew = x.General.IsNew,
                                                  Name = x.General.Name,
                                                  Price = x.General.Price,
                                                  ImagePath = x.Image_path,
                                                  Reiting = x.General.Reiting,
                                                  Category = allcat.First(c => c.CategoryId == x.Category_Id)
                                              });
            //Формирование конкретной модели
            if (ProductType == ShowType.New)
            {
                model = model.Where(x => x.IsNew == true);
                ViewData["title"] = "Новинки";
            }
            if (ProductType == ShowType.Popular)
            {
                model = model.Where(x => x.Reiting > 4);
                ViewData["title"] = "Популярные товары";
            }
                                    
            return model;
        }
        //Полное представление главной страницы
        public ViewResult ShowMainPage()
        {
            ViewBag.Title = "MusicStore";
            MainPageViewModel model = new MainPageViewModel
            {
                SliderContent = GetContentSlider(),
                Catalog = GetCatalog(),
                NewProducts = GetProducts(ShowType.New),
                PopularProducts = GetProducts(ShowType.Popular)
            };
            return View(model);
        }
    }
}
