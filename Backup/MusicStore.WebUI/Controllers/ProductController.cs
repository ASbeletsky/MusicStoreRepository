using System.Linq;
using System.Web.Mvc;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using MusicStore.WebUI.Models.ProductDetail;

namespace MusicStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
       private IMusicInstrumentRepository repository;
       public ProductController(IMusicInstrumentRepository repositoryParam)
        {
            repository = repositoryParam;
        }
        //Представление конкретного товара
        public ActionResult Index(int id = -1)
        {
            Product current = repository.musicInstruments.First(x => x.Id == id);
            DetailProductViewModel model = current.MakeModel( new DetailProductViewModel());
            model.DelivaryCost = new decimal(35);
            ViewBag.Title = model.Characteristics[0].Properties["Name"].Value.ToString();
            return View(model);
        }

    }
}
