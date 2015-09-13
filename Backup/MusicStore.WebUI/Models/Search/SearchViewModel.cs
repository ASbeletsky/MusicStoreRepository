using System.Collections.Generic;
using System.Web.Mvc;

namespace MusicStore.WebUI.Models.Search
{
    public class SearchViewModel
    {
        public string Term { get; set; }
        public int SelectedCategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}