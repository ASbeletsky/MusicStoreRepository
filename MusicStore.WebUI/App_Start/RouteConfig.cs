using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MusicStore.WebUI
{
    public class RouteConfig
    {
        
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Выводит главную страницу 
            routes.MapRoute("Home", "",
                new
                {
                    controller = "MainPage",
                    action = "ShowMainPage",
                }
            );
            
            //Выводит первую страницу списка товаров всех категорий
            routes.MapRoute(null,
               "",
               new
               {
                   controller = "MusicInstruments",
                   action = "ShowListPage",
                   filter = UrlParameter.Optional,
                   category = (string)null,
                   page = 1
               }
           );
       
            //Выводит указанную страницу, отображая товары всех категорий
            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { controller = "MusicInstruments", action = "ShowListPage", filter = UrlParameter.Optional, category = (string)null },
                constraints: new { page = @"\d+" }
              
            );
            //Отображает первую страницу элементов указанной категории 
            routes.MapRoute(null,
                "Category{category}",
                new { controller = "MusicInstruments", action = "ShowListPage", page = 1 }
            );
            //Отображает заданную страницу элементов указанной категории 
            routes.MapRoute(null,
                "Category{category}/Page{page}",
                new { controller = "MusicInstruments", action = "ShowListPage", filter = UrlParameter.Optional },
                new { page = @"\d+" }
            );

            routes.MapRoute("Successfull",
                "SuccessfullOrder",
                new { controller = "Cart", action = "SuccessfullOrder" }
            );

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}