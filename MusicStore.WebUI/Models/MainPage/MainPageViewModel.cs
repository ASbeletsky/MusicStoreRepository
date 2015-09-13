using System.Collections.Generic;
using MusicStore.Domain.Entities;
using MusicStore.WebUI.Models.Shared;

namespace MusicStore.WebUI.Models.MainPage
{
    public class MainPageViewModel
    {
        public IEnumerable<slides> SliderContent { get; set; }
        public ShowCatalogViewModel Catalog { get; set; }
        public IEnumerable<ProductViewModel> NewProducts { get; set; }
        public IEnumerable<ProductViewModel> PopularProducts { get; set; } 
    }
}