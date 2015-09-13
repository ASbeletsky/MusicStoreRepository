using System;
using System.Linq;
using System.Web.Mvc;
using MusicStore.Domain.Abstract;
using MusicStore.WebUI.Models;
using MusicStore.Domain.Entities;

namespace MusicStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IMusicInstrumentRepository repository;
        public CartController(IMusicInstrumentRepository repositoryParam)
        {
            repository = repositoryParam;
        }

        //Получить корзину из сеанса:
        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            //Если корзины в сеансе нет - создать
            if(cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        //Добавить:
        public RedirectToRouteResult AddToCart(int Id, string returnUrl)
        {
            //получение товара по Id
            Product product = repository.musicInstruments.Where(p => p.Id == Id)
                                                            .FirstOrDefault();
            if(product != null)
            {
                GetCart().AddLine(product, 1);
            }
            //Перенаправление на метод Index по Url - returnUrl
            return RedirectToAction("Index", new { returnUrl });
        }

        //Удалить:
        public RedirectToRouteResult RemoveFromCart(int ProductId, string returnUrl)
        {
            //получение товара по Id
            Product product = repository.musicInstruments.Where(p => p.Id == ProductId)
                                                            .FirstOrDefault();
            if (product != null)
            {
                GetCart().RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        //Отображение содержимого корзины:
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            { 
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        //Отображение страницы оформления заказа
        [HttpGet]
        public ActionResult Checkout()
        {
            OrderDetails model = new OrderDetails();
            model.Payment = new OrderDetails.PaymentVM();
            model.Address = new OrderDetails.AddressVM();
            model.TotalSum = (Decimal) GetCart().ComputeTotalSum() + model.DelivaryCost;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Checkout( OrderDetails orderDetails)
        {
            Cart cart = GetCart();
            orderDetails.Products = cart.Lines;
            repository.AddOrder(orderDetails);
            cart.Clear();
            return RedirectToAction("SuccessfullOrder");
        }

        public ViewResult SuccessfullOrder()
        {
            return View();
        }

    }
}
