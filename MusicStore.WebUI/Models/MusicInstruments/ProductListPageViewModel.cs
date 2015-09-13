using MusicStore.WebUI.Models.MusicInstruments.Filter;

namespace MusicStore.WebUI.Models.MusicInstruments
{
    public class ProductListPageViewModel
    {
        public ProductFilter filter { get; set; }
        public MusicInstrumentsListViewModel productList { get; set; }
    }
}